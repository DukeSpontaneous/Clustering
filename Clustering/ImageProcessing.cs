using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using System.Windows.Forms;

namespace Clustering
{
	static class ImageProcessing
	{
		// Перевод в оттенки серого и пороговая бинаризация
		public static Image GrayscaleAndBinarization(Image img, byte threshold)
		{
			BitmapColorMatrix bcm = new BitmapColorMatrix(img);

			int width = bcm.Width;
			int height = bcm.Height;

			double value;

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Color pixel = bcm[x, y];

					value = 0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B;

					if (value >= (double)threshold)
						bcm[x, y] = Color.FromArgb(255, 255, 255);
					else
						bcm[x, y] = Color.FromArgb(0, 0, 0);
				}
			}

			return bcm.getImage();
		}

		// Int32 min-фильтр, анализирующий 32-разрядное значение содержания пикселя
		public static Image MinFilterInt(Image img, byte coreRank)
		{
			if (coreRank < 3 || coreRank % 2 == 0)
			{
				MessageBox.Show("Недопустимое значение размерности ядра фильтра: значение не может быть меньше 3, или чётным числом.");
				return img;
			}
			
			BitmapIntMatrix bimOriginal = new BitmapIntMatrix(img);
			BitmapIntMatrix bimResult = new BitmapIntMatrix(img.Width, img.Height);

			for (int x = 0; x < img.Width; ++x)
			{
				int
					start_x_area	= x - coreRank / 2,
					end_x_area		= x + coreRank / 2;

				if (start_x_area < 0)
					start_x_area = 0;
				if (end_x_area >= img.Width)
					end_x_area = img.Width;

				for (int y = 0; y < img.Height; ++y)
				{

					int
						start_y_area = y - coreRank / 2,
						end_y_area = y + coreRank / 2;

					if (start_y_area < 0)
						start_y_area = 0;
					if (end_y_area >= img.Height)
						end_y_area = img.Height;

					int[] area = new int[(end_x_area - start_x_area + 1) * (end_y_area - start_y_area + 1)];
					int counter = 0;

					// Сбор значений из области, покрываемой ядром
					for (int x_m = start_x_area; x_m < end_x_area; ++x_m)
					{
						for (int y_m = start_y_area; y_m < end_y_area; ++y_m)
						{
							area[counter] = bimOriginal[x_m, y_m];
							++counter;
						}
					}

					// Выбор наименьшего из найденных значений
					int min = int.MaxValue;
					for (int i = 0; i < area.Length; ++i)
					{
						if (area[i] < min)
							min = area[i];
					}

					bimResult[x, y] = min;
				}
			}

			return bimResult.getImage();
		}

	}
}
