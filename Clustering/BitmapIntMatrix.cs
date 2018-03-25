using System;

using System.Drawing;

namespace Clustering
{
	public class BitmapIntMatrix
	{
		public int[] imgArray   // Изображение, представленное в виде линейного массива
		{
			get;
		}

		public int Height
		{
			get;
		}

		public int Width
		{
			get;
		}

		public BitmapIntMatrix(Image img)
		{
			Bitmap bmp = img as Bitmap;

			Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
			System.Drawing.Imaging.BitmapData bmpData =
				bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
				System.Drawing.Imaging.PixelFormat.Format32bppRgb);

			this.Width	= bmpData.Width;
			this.Height = bmpData.Height;

			// Получить адрес первого пикселя bmpData
			IntPtr ptr = bmpData.Scan0;

			imgArray = new int[bmpData.Width * bmpData.Height];

			// Копирование RGB-значений из bmpData в массив int[] array
			System.Runtime.InteropServices.Marshal.Copy(ptr, imgArray, 0, imgArray.Length);

			bmp.UnlockBits(bmpData);
		}

		public BitmapIntMatrix(int width, int height)
		{
			this.imgArray = new int[height * width];
			this.Height = height;
			this.Width = width;
		}

		// Организация доступа к пикселям изображения через координаты x и y
		public int this[int x, int y]
		{
			get
			{
				int index = x + this.Width * y;
				return imgArray[index];
			}
			set
			{
				int index = x + this.Width * y;
				imgArray[index] = value;
			}
		}

		public Image getImage()
		{
			Bitmap bmp = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

			Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

			System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(
				rect,
				System.Drawing.Imaging.ImageLockMode.ReadWrite,
				System.Drawing.Imaging.PixelFormat.Format32bppRgb
			);

			// Получить адрес первого пикселя bmpData
			IntPtr ptr = bmpData.Scan0;

			// Вычисление размера изображения в байтах
			int bytes = Math.Abs(bmpData.Stride) * bmp.Height;

			System.Runtime.InteropServices.Marshal.Copy(this.imgArray, 0, ptr, this.imgArray.Length);

			bmp.UnlockBits(bmpData);

			return bmp as Image;
		}
	}
}
