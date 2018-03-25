using System;

using System.Drawing;

namespace Clustering
{
	public class BitmapColorMatrix
	{
		public byte[] imgArray   // Изображение, представленное в виде линейного массива
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

		public int stride
		{
			get;
		}	 // Ширина одной строки в байтах
		
		public BitmapColorMatrix(Image img)
		{
			Bitmap bmp = img as Bitmap;

			Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
			System.Drawing.Imaging.BitmapData bmpData =
				bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
				System.Drawing.Imaging.PixelFormat.Format24bppRgb);

			this.Width	= bmpData.Width;
			this.Height = bmpData.Height;

			this.stride = bmpData.Stride;

			// Получить адрес первого пикселя bmpData
			IntPtr ptr = bmpData.Scan0;
			
			imgArray = new byte[Math.Abs(bmpData.Stride) * bmpData.Height];

			// Копирование RGB-значений из bmpData в массив int[] array
			System.Runtime.InteropServices.Marshal.Copy(ptr, imgArray, 0, imgArray.Length);

			bmp.UnlockBits(bmpData);
		}

		public BitmapColorMatrix(int width, int height)
		{
			this.imgArray = new byte[height * width * 3];
			this.Height = height;
			this.Width = width;

			this.stride = width * 3;
		}

		// Организация доступа к пикселям изображения через координаты x и y
		public Color this[int x, int y]
		{
			// ПЕРЕПРОВЕРИТЬ!!!

			get
			{
				int index = 3 * x + stride * y;
				return Color.FromArgb(
					imgArray[index + 0],
					imgArray[index + 1],
					imgArray[index + 2]); // точный формат не помню !!!
			}
			set
			{
				var index = 3 * x + stride * y;
				imgArray[index + 0] = value.R;
				imgArray[index + 1] = value.G;
				imgArray[index + 2] = value.B;
			}
			
		}

		public Image getImage()
		{
			Bitmap bmp = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

			Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

			System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(
				rect,
				System.Drawing.Imaging.ImageLockMode.ReadWrite,
				System.Drawing.Imaging.PixelFormat.Format24bppRgb
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
