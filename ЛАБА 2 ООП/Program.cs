using System.Globalization;

namespace ЛАБА_2_ООП
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyMatrix a = new MyMatrix(new double[,]{{ 1, 2, 3 },{ 4, 5, 6 }});
            MyMatrix b = new MyMatrix(new double[,]{{ 1, 2, 3 },{ 4, 5, 6 }});

            Console.WriteLine("Матриця A:");
            Console.WriteLine(a);

            Console.WriteLine("Додавання:");
            Console.WriteLine(a + b);

            MyMatrix c = new MyMatrix(new double[,]{{ 1, 2 },{ 3, 4 },{ 5, 6 }});

            Console.WriteLine("Множення:");
            Console.WriteLine(a * c);
            Console.WriteLine("Транспонована копія:");
            Console.WriteLine(a.GetTransponedCopy());
            Console.WriteLine("Початкова матриця:");
            Console.WriteLine(a);
            a.TransponeMe();
            Console.WriteLine("Матриця після TransponeMe:");
            Console.WriteLine(a);
        }
    }
}
