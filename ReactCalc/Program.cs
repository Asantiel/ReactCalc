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
            double x = 0;
            double y = 1;
            string com = "";
            string result = "";
            var calc = new Calc();

            try
            {
                Console.WriteLine("Введите команду");
                com = Console.ReadLine();
                Console.WriteLine("Введите X");
                x = ToDouble(Console.ReadLine());
                Console.WriteLine("Введите Y");
                y = ToDouble(Console.ReadLine());
                var res = calc.Execute(com, new[] { x, y });

                Console.WriteLine(res);

                Console.ReadKey();
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
           
        }


        private static double ToDouble(string arg)
        {
            double x;
            if (!double.TryParse(arg, out x))
            {

                Console.WriteLine("Введённый вами аргумент не верен. Приложение будет закрыто.");
                Console.ReadKey();
                Environment.Exit(0);

            }

            return x;
        }

        
    }
}
