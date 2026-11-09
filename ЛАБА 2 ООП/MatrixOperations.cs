using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛАБА_2_ООП
{

    public partial class MyMatrix
    {
        // Додавання матриць
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            if (a.Height != b.Height || a.Width != b.Width)
            {
                throw new ArgumentException("Розміри матриць не збігаються");
            }
            double[,] result = new double[a.Height, a.Width];
            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < a.Width; j++)
                {
                    result[i, j] = a.data[i, j] + b.data[i, j];
                }
            }
            return new MyMatrix(result);
        }
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.Width != b.Height)
            {
                throw new ArgumentException("Неможливо помножити матриці");
            }
            double[,] result = new double[a.Height, b.Width];

            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    for (int k = 0; k < a.Width; k++)
                    {
                        result[i, j] += a.data[i, k] * b.data[k, j];
                    }
                }
            }
            return new MyMatrix(result);
        }
        private double[,] GetTransponedArray()
        {
            double[,] result = new double[Width, Height];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    result[j, i] = data[i, j];
                }
            }
            return result;
        }
        public MyMatrix GetTransponedCopy()
        {
            return new MyMatrix(GetTransponedArray());
        }
        public void TransponeMe()
        {
            data = GetTransponedArray();
        }
    }

}
