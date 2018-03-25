using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace Clustering
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Show the Dialog.
			// If the user clicked OK in the dialog and
			// a file was selected, open it.

			if (openImageDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				using (var stream = new System.IO.FileStream(openImageDialog.FileName, System.IO.FileMode.Open))
				{
					try
					{ pictureBoxInput.Image = Image.FromStream(stream); }
					catch
					{
						MessageBox.Show("Ошибка: недопустимый формат файла.");
						return;
					}
				}
			}
		}

		private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.pictureBoxOutput.Image != null)
			{
				// Show the Dialog.
				// If the user clicked OK in the dialog and
				// a file was selected, open it.
				if (saveImageDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					Dictionary<string, System.Drawing.Imaging.ImageFormat> extensions = new Dictionary<string, System.Drawing.Imaging.ImageFormat> {
						{".bmp", System.Drawing.Imaging.ImageFormat.Bmp },
						{".gif", System.Drawing.Imaging.ImageFormat.Gif },
						{".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg },
						{".png", System.Drawing.Imaging.ImageFormat.Png }
					};

					System.Drawing.Imaging.ImageFormat ex;

					if (extensions.ContainsKey(System.IO.Path.GetExtension(saveImageDialog.FileName)))
						ex = extensions[System.IO.Path.GetExtension(saveImageDialog.FileName)];
					else
						ex = System.Drawing.Imaging.ImageFormat.Png;

					this.pictureBoxOutput.Image.Save(saveImageDialog.FileName, ex);
				}
			}
			else
			{
				MessageBox.Show("Ошибка: отсутствует обработанное изображение.");
			}
		}

		private void сохранитьСтатистикуToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.pictureBoxOutput.Image != null)
			{
				// Show the Dialog.
				// If the user clicked OK in the dialog and
				// a file was selected, open it.
				if (saveStatisticsDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					// Загрузка параметров из формы
					int clustNumber;
					byte coreRank;
					byte threshold = (byte)this.trackBarThreshold.Value;

					if ( ! int.TryParse(this.textBoxClustNumber.Text, out clustNumber))
					{
						MessageBox.Show("Недопустимое значение поля \"Число кластеров\"!");
						this.textBoxClustNumber.Text = 1.ToString();
						return;
					}
					if ( ! byte.TryParse(this.textBoxFilterCoreRank.Text, out coreRank) || (coreRank % 2) == 0 || coreRank < 3)
					{
						MessageBox.Show("Ядро min-фильтра должно быть нечётным числом больше 3!");
						this.textBoxFilterCoreRank.Text = 3.ToString();
						return;
					}

					Image img = this.pictureBoxInput.Image;

					// Бинаризация изображения
					img = ImageProcessing.GrayscaleAndBinarization(img, threshold);

					// Фильтрация изображения min-фильтром

					img = ImageProcessing.MinFilterInt(img, coreRank);

					Clustering classes = new Clustering(img, clustNumber);

					img = classes.domainsMap.getImage();

					this.pictureBoxOutput.Image = img;

					// Печать статистики

					File.WriteAllLines(saveStatisticsDialog.FileName, classes.getStatistics());
				}
			}
			else
			{
				MessageBox.Show("Ошибка: отсутствует обработанное изображение.");
			}
		}

		private void выходToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void применитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.pictureBoxInput.Image != null)
			{
				// Загрузка параметров из формы
				int clustNumber;
				byte coreRank;
				byte threshold = (byte)this.trackBarThreshold.Value;

				if ( ! int.TryParse(this.textBoxClustNumber.Text, out clustNumber))
				{
					MessageBox.Show("Недопустимое значение поля \"Число кластеров\"!");
					this.textBoxClustNumber.Text = 1.ToString();
					return;
				}

				if ( ! byte.TryParse(this.textBoxFilterCoreRank.Text, out coreRank) || (coreRank % 2) == 0 || coreRank < 3)
				{
					MessageBox.Show("Ядро min-фильтра должно быть нечётным числом больше 3!");
					this.textBoxFilterCoreRank.Text = 3.ToString();
					return;
				}


				Image img = this.pictureBoxInput.Image;

				// Бинаризация изображения
				img = ImageProcessing.GrayscaleAndBinarization(img, threshold);

				// Фильтрация изображения min-фильтром

				img = ImageProcessing.MinFilterInt(img, coreRank);

				Clustering classes = new Clustering(img, clustNumber);

				img = classes.domainsMap.getImage();

				this.pictureBoxOutput.Image = img;
			}
			else
			{
				MessageBox.Show("Ошибка: отсутствует целевое изображение.");
			}
		}

		private void trackBarThreshold_Scroll(object sender, EventArgs e)
		{
			this.textBoxThreshold.Text = this.trackBarThreshold.Value.ToString();
		}

		private void textBoxClustNumber_TextChanged(object sender, EventArgs e)
		{
			int test;
			bool isSuccess = int.TryParse(this.textBoxClustNumber.Text, out test);

			if ( ! isSuccess || test > 500)
			{
				MessageBox.Show("Недопустимое значение поля \"Число кластеров\"!");
				this.textBoxClustNumber.Text = 1.ToString();
			}
		}

		private void textBoxFilterCoreRank_TextChanged(object sender, EventArgs e)
		{
			byte test;
			bool isSuccess = byte.TryParse(this.textBoxFilterCoreRank.Text, out test);

			int x = test % 2;

			if ( ! isSuccess || (test % 2) == 0 || test < 3)
			{
				MessageBox.Show("Ядро min - фильтра должно быть нечётным числом больше 3!");
				this.textBoxFilterCoreRank.Text = 3.ToString();
			}
		}
	}
}
