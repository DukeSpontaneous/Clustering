namespace Clustering
{
	class ObjectParameters
	{
		public int Perimeter;		// Периметр
		public int Square;			// Площадь
		public double Compactness;  // Компактность

		public double Xmas;         // Координата X центра масс
		public double Ymas;         // Координата Y центра масс

		// Дискретные центральные моменты
		public double m20;
		public double m02;
		public double m11;

		public double Elongation;              // Удлинённость

		public ObjectParameters()
		{
			Perimeter = Square = 0;
			Compactness = Xmas = Ymas = Elongation = 0.0;
			m20 = m02 = m11 = Elongation = 0.0;
		}

		public ObjectParameters(ObjectParameters obj)
		{
			Perimeter = obj.Perimeter;
			Square = obj.Square;
			Compactness = obj.Compactness;
			Xmas = obj.Xmas;
			Ymas = obj.Ymas;
			m20 = obj.m20;
			m02 = obj.m02;
			m11 = obj.m11;
			Elongation = obj.Elongation;
		}
	}
}
