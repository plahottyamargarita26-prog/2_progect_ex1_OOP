using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛАБА_2_ООП
{
    public partial class MyMatrix
    {
        private double[,] data;
        public MyMatrix(MyMatrix other)
        {
            data = new double[other.Height, other.Width];

            for (int i = 0; i < other.Height; i++)
            {
                for (int j = 0; j < other.Width; j++)
                {
                    data[i, j] = other.data[i, j];
                }
            }
        }
        public MyMatrix(double[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            data = (double[,])array.Clone();
        }
        public MyMatrix(double[][] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Некоректний масив");
            }

            int width = array[0].Length;

            data = new double[array.Length, width];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null || array[i].Length != width)
                    throw new ArgumentException("Масив не є прямокутним");

                for (int j = 0; j < width; j++)
                {
                    data[i, j] = array[i][j];
                }
            }
        }
        public MyMatrix(string[] lines)
        {
            if (lines == null || lines.Length == 0)
            {
                throw new ArgumentException("Некоректні дані");
            }

            string[][] numbers = new string[lines.Length][];
            int width = -1;

            for (int i = 0; i < lines.Length; i++)
            {
                numbers[i] = lines[i].Split(
                    new char[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (width == -1)
                {
                    width = numbers[i].Length;
                }

                if (numbers[i].Length != width || width == 0)
                {
                    throw new ArgumentException("Матриця не є прямокутною");
                }
            }

            data = new double[lines.Length, width];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    data[i, j] = double.Parse(
                        numbers[i][j],
                        CultureInfo.InvariantCulture);
                }
            }
        }
        public MyMatrix(string text)
        {
            string[] lines = text.Split('\n');

            string[] firstRow = lines[0].Split(' ', '\t',
                StringSplitOptions.RemoveEmptyEntries);

            int width = firstRow.Length;

            data = new double[lines.Length, width];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] numbers = lines[i].Split(' ', '\t',
                    StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length != width)
                    throw new Exception("Матриця не прямокутна");

                for (int j = 0; j < width; j++)
                {
                    data[i, j] = double.Parse(numbers[j].Trim('\r'));
                }
            }
        }
        public int Height
        {
            get { return data.GetLength(0); }
        }

        public int Width
        {
            get { return data.GetLength(1); }
        }
        public int getHeight()
        {
            return Height;
        }

        public int getWidth()
        {
            return Width;
        }
        public double this[int row, int column]
        {
            get { return data[row, column]; }
            set { data[row, column] = value; }
        }
        public double getElement(int row, int column)
        {
            return data[row, column];
        }
        public void setElement(int row, int column, double value)
        {
            data[row, column] = value;
        }
        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    result += data[i, j].ToString(
                        "G", CultureInfo.InvariantCulture);

                    if (j < Width - 1)
                        result += "\t";
                }

                if (i < Height - 1)
                    result += "\n";
            }

            return result;
        }
    }
}
