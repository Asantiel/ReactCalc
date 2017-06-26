using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ReactCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;
            var calc = new Calc();

            if (args.Length == 2)
            {
                x = ToInt(args[0], 83);
                y = ToInt(args[1], 70);
            }
            else
            {
                #region Ввод данных
                Console.WriteLine("Введите Х");
                var strx = Console.ReadLine();

                if (!int.TryParse(strx, out x))
                {
                    x = 100;
                }

                Console.WriteLine("Введите Y");
                var stry = Console.ReadLine();

                if (!int.TryParse(stry, out y))
                {
                    y = 100;
                }
                #endregion
            }

            var result = calc.Sum(x, y);

            Console.WriteLine(string.Format("Сумма = {0}", result));
            Console.ReadKey();
        }


        private static int ToInt(string arg, int i = 100)
        {
            int x;
            if (!int.TryParse(arg, out x))
            {
                x = i;
            }

            return x;
        }
    }
}
