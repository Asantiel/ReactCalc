using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc
{
    /// <summary>
    ///Калькулятор
    /// </summary>
    public class Calc
    {
        /// <summary>
        /// Сумма
        /// </summary>
        /// <param name="x">Слагаемое</param>
        /// <param name="y">Слагаемое</param>
        /// <returns>Число с плавающей точкой</returns>
        public double Sum(double x, double y)
        {
            return x + y;
        }

        /// <summary>
        /// Квадратный корень
        /// </summary>
        /// <param name="x">Квадрат числа</param>
        /// <returns>Число с плавающей точкой</returns>
        public double Sqrt(double x)
        {
            return Math.Sqrt(x);
        }


        /// <summary>
        /// Деление
        /// </summary>
        /// <param name="x">Числитель</param>
        /// <param name="y">Знаменатель</param>
        /// <returns>Число с плавающей точкой</returns>
        public double Div(double x, double y)
        {
            return x / y;
        }

        /// <summary>
        /// Умножение
        /// </summary>
        /// <param name="x">Множитель</param>
        /// <param name="y">Множитель</param>
        /// <returns>Число с плавающей точкой</returns>
        public double Mpl(double x, double y)
        {
            return x * y;
        }

        
        //public void Act(string com, double x, double y = 1)
        //{
        //    switch (com) {
        //        case "+":
        //            Console.WriteLine(Convert.ToString(Sum(x, y)));
        //            break;
        //        case "sqrt":
        //            Console.WriteLine(Convert.ToString(Sqrt(x)));
        //            break;
        //        case "/":
        //            Console.WriteLine(Convert.ToString(Div(x, y)));
        //            break;
        //        case "*":
        //            Console.WriteLine(Convert.ToString(Mpl(x, y)));
        //            break;
        //        default:
        //            Console.WriteLine("Ошибка в введённых аргументах");
        //            break;
        //    }
        //}

        //public void Help()
        //{
        //    Console.WriteLine("+ - сложение");
        //    Console.WriteLine("sqrt - квадратный корень");
        //    Console.WriteLine("/ - деление");
        //    Console.WriteLine("* - умножение");

        //}
    }
}
