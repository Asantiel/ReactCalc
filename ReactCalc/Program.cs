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

            //if (args.Length >= 2)
            //{
            //    com = args[0];
            //    x = ToDouble(args[1]);
            //    y = ToDouble(args[2]);
            //}
            //else
            //{
            //    Console.WriteLine("Справка появляется при любой ошибке при вводе аргументов (например, help).");
            //    Console.WriteLine("Для выхода из приложения используйте команду exit");
            //    Console.WriteLine("Введите команду:");
            //    com = Console.ReadLine();
            //}

            
            //if (com == "sqrt")
            //{
            //    Console.WriteLine("Введите x:");
            //    x = ToDouble(Console.ReadLine());

            //    result = string.Format("Квадратный корень: {0}", calc.Sqrt(x));
            //} 
            //else if (com == "+" || com == "/" || com == "*") 
            //{
            //    Console.WriteLine("Введите x:");
            //    x = ToDouble(Console.ReadLine());

            //    Console.WriteLine("Введите y:");
            //    y = ToDouble(Console.ReadLine());

            //    switch (com)
            //    {
            //        case "+":
            //            result = string.Format("Сумма: {0}", calc.Sum(x, y));
            //            break;

            //        case "/":
            //            if (y != 0)
            //            {
            //                result = string.Format("Отношение: {0}", calc.Div(x, y));
            //            }
            //            else
            //            {
            //                result = "На ноль делить нельзя!";
            //            }
                        
            //            break;

            //        case "*":
            //            result = string.Format("Произведение: {0}", calc.Mpl(x, y));
            //            break;
            //    }
            //}
            //else if (com == "exit")
            //{
            //    return;
            //}
            //else
            //{
            //    Console.WriteLine("Вы вызвали справку либо допустили ошибку при вводе параметров.");
            //    Console.WriteLine("+ - сложение");
            //    Console.WriteLine("* - умножение");
            //    Console.WriteLine("/ - деление");
            //    Console.WriteLine("sqrt - квадратный корень");
            //    Console.WriteLine("exit - выход из приложения");
            //    Main(args);
            //}
            try
            {
                com = Console.ReadLine();
                x = ToDouble(Console.ReadLine());
                y = ToDouble(Console.ReadLine());
                var res = calc.Execute(com, new[] { x, y });

                Console.WriteLine(res);

                Main(args);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }


        private static double ToDouble(string arg)
        {
            double x;
            if (!double.TryParse(arg, out x))
            {

                Console.WriteLine("Введённый вами аргумент не верен. Приложение будет закрыто.");
                Environment.Exit(0);

            }

            return x;
        }

        
    }
}
