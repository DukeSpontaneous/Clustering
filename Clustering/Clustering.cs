using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using System.Windows.Forms;

namespace Clustering
{
	// Представляет методы класстеризации изображения
	public class Clustering
	{
		// Словарь списков пикселей, составляющих объекты
		private Dictionary<int, List<Point>> domainsPixelTable = new Dictionary<int, List<Point>>();

		// Словарь параметров объектов
		private Dictionary<int, ObjectParameters> domainsParametersTable = new Dictionary<int, ObjectParameters>();

		// 2D-карта отдельных областей изображения
		public BitmapIntMatrix domainsMap;
		
		public Clustering(Image img, int clustersCount)
		{
			// Различение объектов (отдельных белых областей) на чёрно-белом изображении
			differentiationOfConnectedDomains(img);

			// Вычисление параметров объектов на изображении
			foreach (KeyValuePair<int, List<Point>> domain in this.domainsPixelTable)
			{
				this.domainsParametersTable[domain.Key] = сalculateParameters(this.domainsMap, domain.Value);
			}

			// Класстеризация объектов методом k-средних
			List<int>[] clusters = kMeansClustering(clustersCount, this.domainsParametersTable);

			if (clusters == null)
				return;

			// Закрашивание каждого кластера уникальным цветом
			int colorsCount = clusters.Length;

			int colorStep = (unchecked((int)(0xFFFFFFFF - 0xFF000033)) / colorsCount);

			int color = unchecked((int)(0xFF000033));

			for (int i = 0; i < clusters.Length; ++i)
			{
				for (int j = 0; j < clusters[i].Count; ++j)
				{
					for (int k = 0; k < domainsPixelTable[clusters[i][j]].Count; ++k)
					{
						Point target = domainsPixelTable[clusters[i][j]][k];
						domainsMap[target.X, target.Y] = color;
					}
				}

				color += colorStep;
			}
		}

		// Разметка отдельных доменов уникальными численными значениями и 
		// формирование массивов, состоящих из непересекающихся множеств пикселей.
		private BitmapIntMatrix differentiationOfConnectedDomains(Image img)
		{
			this.domainsMap = new BitmapIntMatrix(img);

			int blackColor = unchecked((int)(0xFF000000));
			int whiteColor = unchecked((int)(0xFFFFFFFF));

			for (int i = 0; i < domainsMap.Width; ++i)
			{
				domainsMap[i, 0] = blackColor;
				domainsMap[i, domainsMap.Height - 1] = blackColor;
			}
			for (int j = 0; j < domainsMap.Height; ++j)
			{
				domainsMap[0, j] = blackColor;
				domainsMap[domainsMap.Width - 1, j] = blackColor;
			}
			
			// Переменная отметки сплошной залитой области (объекта)
			int domainMarkCounter = 0;
			// Списки групп объектов, состоящих в соседстве-4
			List<List<int>> groupsNeighbors = new List<List<int>>();

			// Построчный проход заливки слева направо, сверху вниз
			for (int y = 1; y < domainsMap.Height; ++y)
			{
				for (int x = 1; x < domainsMap.Width; ++x)
				{
					int target = domainsMap[x, y], top = domainsMap[x, y - 1], left = domainsMap[x - 1, y];

					if (target != blackColor)
					{
						if (left != blackColor)
						{
							domainsMap[x, y] = left;

							if (!domainsPixelTable.ContainsKey(left))
								domainsPixelTable[left] = new List<Point>();

							domainsPixelTable[left].Add(new Point(x, y));

							// Если верхний и левый отличны от чёрного и не равны
							if ((top != left) && (top != blackColor))
							{
								int leftGroupIndex = -1;
								int topGroupIndex = -1;

								// Поиск групп, которым принадлежат объекты
								for (int i = 0; i < groupsNeighbors.Count; ++i)
								{
									if (groupsNeighbors[i].Contains(left))
										leftGroupIndex = i;

									if (groupsNeighbors[i].Contains(top))
										topGroupIndex = i;

									// Если обе группы найдены
									if ((leftGroupIndex != -1) && (topGroupIndex != -1))
										break;
								}

								// Если таких групп нет, то нужно создать новую группу
								if ((leftGroupIndex == -1) && (topGroupIndex == -1))
								{
									groupsNeighbors.Add(new List<int> { left, top });
								}
								// Если они в одной группе
								else if(leftGroupIndex == topGroupIndex)
								{
									continue;
								}
								// Если нет группы левого объекта, то добавить его в группу верхнего
								else if (leftGroupIndex == -1)
								{
									groupsNeighbors[topGroupIndex].Add(left);
								}
								// Если нет группы верхнего объекта, то добавить его в группу левого
								else if (topGroupIndex == -1)
								{
									groupsNeighbors[leftGroupIndex].Add(top);
								}
								// Если если они принадлежат двум разным группам, то необходимо объединить их
								else
								{
									groupsNeighbors[topGroupIndex].AddRange(groupsNeighbors[leftGroupIndex]);
									groupsNeighbors.RemoveAt(leftGroupIndex);
								}
							}
						}
						else if (top != blackColor)
						{
							domainsMap[x, y] = top;

							if (!domainsPixelTable.ContainsKey(top))
								domainsPixelTable[top] = new List<Point>();

							domainsPixelTable[top].Add(new Point(x, y));
						}
						else if (target == whiteColor)
						{
							if (++domainMarkCounter == blackColor)
							{
								++domainMarkCounter;
							}

							domainsMap[x, y] = domainMarkCounter;

							domainsPixelTable[domainMarkCounter] = new List<Point>();

							domainsPixelTable[domainMarkCounter].Add(new Point(x, y));

							// Если предворительный счётчик объектов достиг предельного значения UInt32
							if (domainMarkCounter == int.MaxValue)
							{
								throw new Exception("Переполнение счётчика числа объектов на изображении.");
							}
						}
					}
				}
			}

			// Если есть группы объектов, состоящих в соседстве-4,
			// то необходимо произвести их слияние
			if (groupsNeighbors.Count > 0)
			{
				foreach (List<int> groupNeighbors in groupsNeighbors)
				{
					do
					{
						int lastNeighbor = groupNeighbors.Last();

						domainsPixelTable[groupNeighbors[0]].AddRange(domainsPixelTable[lastNeighbor]);
						domainsPixelTable.Remove(lastNeighbor);
						groupNeighbors.Remove(lastNeighbor);
					}
					while (groupNeighbors.Count > 1);

					// Перекрашивание карты объектов
					foreach (Point pixel in domainsPixelTable[groupNeighbors[0]])
					{
						domainsMap[pixel.X, pixel.Y] = groupNeighbors[0];
					}

					groupNeighbors.Clear();
				}
			}
		
			MessageBox.Show(domainsPixelTable.Count.ToString());

			return domainsMap;
		}

		// Вычисление параметров объекта, которые будут
		// использованы для последующей его класстеризации.
		private ObjectParameters сalculateParameters(BitmapIntMatrix ba, List<Point> objectPoints)
		{
			ObjectParameters parameters = new ObjectParameters();

			parameters.Square = objectPoints.Count;

			int blackColor = unchecked((int)(0xFF000000));

			foreach (Point objectPoint in objectPoints)
			{
				int x = objectPoint.X, y = objectPoint.Y;

				int top = ba[x, y + 1], bottom = ba[x, y - 1],
					right = ba[x + 1, y], left = ba[x - 1, y];

				// Если есть чёрный сосед-4
				if (top == blackColor || bottom == blackColor ||
					right == blackColor || left == blackColor)
				{
					parameters.Perimeter++;
				}

				parameters.Xmas += x;
				parameters.Ymas += y;
			}

			parameters.Xmas /= parameters.Square;
			parameters.Ymas /= parameters.Square;

			foreach (Point objectPoint in objectPoints)
			{
				int x = objectPoint.X, y = objectPoint.Y;

				parameters.m02 += Math.Pow((y - parameters.Ymas), 2);
				parameters.m20 += Math.Pow((x - parameters.Xmas), 2);
				parameters.m11 += (x - parameters.Xmas) * (y - parameters.Ymas);
			}

			parameters.Compactness = Math.Pow((parameters.Perimeter), 2) / parameters.Square;

			double a1 = parameters.m20 + parameters.m02;
			double a2 = Math.Sqrt(
				Math.Pow((parameters.m20 - parameters.m02), 2) +
				4 * Math.Pow(parameters.m11, 2)
				);

			if ((a1 - a2) != 0)
				parameters.Elongation = (a1 + a2) / (a1 - a2);
			else
				parameters.Elongation = 1;

			return parameters;
		}

		// Вычисление расстояния между двумя объектами ObjectParameters в многомерном пространстве,
		// выбрав из параметров лишь те, которые нужны для решения конкретной задачи классификации
		private double сalculateDistance(ObjectParameters obj1, ObjectParameters obj2)
		{
			double per	= Math.Pow(obj1.Perimeter	- obj2.Perimeter,	2);
			double sq	= Math.Pow(obj1.Square		- obj2.Square,		2);
			double el	= Math.Pow(obj1.Elongation	- obj2.Elongation,	2);
			double comp = Math.Pow(obj1.Compactness - obj2.Compactness, 2);

			// Усиление компоненты Elongation, контростно отличающей ложки в данной задаче, улучшит результаты
			return Math.Sqrt(per + sq + el * el + comp);
		}

		// Вычисление квадрата расстояния между двумя объектами ObjectParameters
		private double сalculateSquareDistance(ObjectParameters obj1, ObjectParameters obj2)
		{
			double per	= Math.Pow(obj1.Perimeter	- obj2.Perimeter,	2);
			double sq	= Math.Pow(obj1.Square		- obj2.Square,		2);
			double el	= Math.Pow(obj1.Elongation	- obj2.Elongation,	2);
			double comp = Math.Pow(obj1.Compactness - obj2.Compactness, 2);

			// Усиление компоненты Elongation, контростно отличающей ложки в данной задаче, улучшит результаты
			return (per + sq +  el * el + comp);
		}

		// Генерация стартового набора центроидов методом k-средних++
		private List<ObjectParameters> kMeansPPSelectionStartingCentroids(int clustersCount, Dictionary<int, ObjectParameters> objParametrs)
		{
			List<ObjectParameters> objects = new List<ObjectParameters>(objParametrs.Values);

			// Если число кластеров больше, чем число объектов, то каждый из них станет центроидом
			if (objects.Count < clustersCount)
				return objects;

			List<ObjectParameters> centroids = new List<ObjectParameters>();
			Random rand = new Random();

			centroids.Add(
				objects[rand.Next(0, objects.Count - 1)]);

			double distSquareSum;
			// Массив квадратов расстояний объектов до ближайшего центроида [obj]
			double[] minSquareDistances = new double[objects.Count];
			for (int i = 0; i < minSquareDistances.Length; ++i)
			{
				minSquareDistances[i] = double.MaxValue;
			}

			double target;
			while (centroids.Count < clustersCount)
			{
				distSquareSum = 0;
				double squareDistance;
				// Вычисление квадрата дистанции между объектами и очередным найденным центроидом
				for (int i = 0; i < objects.Count; ++i)
				{					
					squareDistance = сalculateSquareDistance(objects[i], centroids.Last());

					if (squareDistance < minSquareDistances[i])
					{
						minSquareDistances[i] = squareDistance;
					}

					distSquareSum += minSquareDistances[i];
				}

				// Выбор нового центроида
				target = rand.NextDouble() * distSquareSum;

				distSquareSum = 0;
				for (int i = 0; i < objects.Count; ++i)
				{
					distSquareSum += minSquareDistances[i];

					// Новый центроид найден
					if (target < distSquareSum)
					{
						centroids.Add(objects[i]);
						break;
					}
				}
			}

			return centroids;
		}

		// Класстеризация объектов методом k-средних
		private List<int>[] kMeansClustering(int clustersCount, Dictionary<int, ObjectParameters> objParametrs)
		{
			if (objParametrs.Count < 1)
			{
				MessageBox.Show("Ошибка: не найдено ни одного объекта.");
				return null;
			}

			List<ObjectParameters> objects = new List<ObjectParameters>(objParametrs.Values);

			// Выбор стартового набора центь центроидов кластеров методом k-средних++
			List<ObjectParameters> centroids = kMeansPPSelectionStartingCentroids(clustersCount, objParametrs);

			// Список кластеров, содержащий набор объектов, принадлежищих каждому из них
			List<int>[]
				clusters	= new List<int>[centroids.Count],
				oldClusters = new List<int>[centroids.Count];

			for (int i = 0; i < clusters.Length; ++i)
			{
				clusters[i]		= new List<int>();
			}

			while (true)
			{
				for (int i = 0; i < clusters.Length; ++i)
				{
					oldClusters[i] = new List<int>(clusters[i]);
					clusters[i].Clear();
				}

				// Формирование кластеров
				foreach (KeyValuePair<int, ObjectParameters> obj in objParametrs)
				{
					int selectedCentroid = 0;
					double minDistance = double.MaxValue;

					// Объект выбирает центроид кластера, которому он принадлежит
					double distance;
					for (int i = 0; i < centroids.Count; ++i)
					{
						distance = сalculateDistance(obj.Value, centroids[i]);
						if (distance < minDistance)
						{
							minDistance = distance;
							selectedCentroid = i;
						}
					}

					// После того, как кластер выбран, метка объекта добавляется в его список
					clusters[selectedCentroid].Add(obj.Key);
				}

				for (int i = 0; i < clusters.Length; ++i)
				{
					if ( ! clusters[i].SequenceEqual(oldClusters[i]))
					{
						break;
					}
					// Если все объекты идентичны
					else if (i == (clusters.Length - 1))
					{
						// Выход из бесконечного цикла кластеризации
						return clusters;
					}
				}

				// Для каждого полученного класстера перерассчитываются центроиды
				for (int i = 0; i < clusters.Length; ++i)
				{
					centroids[i] = new ObjectParameters();

					foreach (int objMark in clusters[i])
					{
						centroids[i].Perimeter		+= objParametrs[objMark].Perimeter;
						centroids[i].Square			+= objParametrs[objMark].Square;
						centroids[i].Compactness	+= objParametrs[objMark].Compactness;
						centroids[i].Elongation		+= objParametrs[objMark].Elongation;
					}

					if (clusters[i].Count != 0)
					{
						centroids[i].Perimeter		/= clusters[i].Count;
						centroids[i].Square			/= clusters[i].Count;
						centroids[i].Compactness	/= clusters[i].Count;
						centroids[i].Elongation		/= clusters[i].Count;
					}
				}
			}

			// Циклический перерассчёт до тех пор, пока результаты не усреднятся
		}

		public List<string> getStatistics()
		{
			List<string> result = new List<string>();

			result.Add("per		sq		el		comp");

			foreach (ObjectParameters str in this.domainsParametersTable.Values)
			{
				result.Add(
					str.Perimeter.ToString()	+ '	' +
					str.Square.ToString()		+ "		" +
					str.Elongation.ToString()	+ "		" +
					str.Compactness.ToString()
					);
			}

			return result;
		}
	}
}
