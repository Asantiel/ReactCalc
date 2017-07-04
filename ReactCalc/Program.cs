using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, i'm Калькулятор");

            var x = 0d;
            var y = 0d;
            var calc = new Calc();
            var oper = "sum";

            if (args.Length >= 2)
            {
                x = ToNumber(args[0], 70);
                if (args.Length >= 3)
                {
                    y = ToNumber(args[1], 83);
                }
                oper = args.Last();
            }
            else
            {
                #region Ввод данных

                Console.WriteLine("Введите Х");
                var strx = Console.ReadLine();
                x = ToNumber(strx);

                Console.WriteLine("Введите Y");
                var stry = Console.ReadLine();
                y = ToNumber(stry, 99);

                Console.WriteLine("Введите операцию");
                oper = Console.ReadLine();

                #endregion
            }

            try
            {
                var result = calc.Execute(oper, new[] { x, y });

                Console.WriteLine(String.Format("{0} = {1}", calc.LastOperationName, result));
                // * 
                // sum = 5
                // Сумма = 5
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadKey();
        }

        /// <summary>
        /// Строку в инт
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="def">Если не удалось распарсить, то возвращаем это значение</param>
        /// <returns></returns>
        private static double ToNumber(string arg, double def = 100)
        {
            double x;
            if (!double.TryParse(arg, out x))
            {
                x = def;
            }

            return x;
        }
    }
}
