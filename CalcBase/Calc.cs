using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactCalc.Models;
using System.Reflection;
using System.IO;

namespace ReactCalc
{
    /// <summary>
    ///Калькулятор
    /// </summary>
    public class Calc
    {

        public string LastOperationName { get; set; }

        public IList<IOperation> Operations { get; private set; }

        public Calc()
        {
            Operations = new List<IOperation>();
            Assembly ass = Assembly.GetAssembly(typeof(Calc));
            Type[] types = ass.GetTypes();
            OperAdd(types);

            //директория с расширениями
            var extsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Extensions");
            if (!Directory.Exists(extsDirectory))
                return;

            var exts = Directory.GetFiles(extsDirectory, "*.dll");

            foreach (var dllName in exts)
            {
                GetOperation(dllName);
            }

        }

        private void OperAdd(Type[] types)
        {
            var searchInterface = typeof(IOperation);
            // перебираем типы
            foreach (var t in types)
            {
                if (t.IsInterface || t.IsAbstract) continue; 
                // находим тех, кто реализует интерфейс IOperation
                var interfs = t.GetInterfaces();
                if (interfs.Contains(searchInterface))
                {
                    // создаём экземпляр найденного класса
                    var instance = Activator.CreateInstance(t) as IOperation;
                    if (instance != null)
                    {
                        // добавляем его в наш список операций
                            Operations.Add(instance);
                    }
                }
            }
        }

        private void GetOperation(string dllName)
        {

            if (!File.Exists(dllName))
            {
                return;
            }

            // загружаем сборку
            var assembly = Assembly.LoadFrom(dllName);
            // получаем все тип/классы из неё
            var types = assembly.GetTypes();

            OperAdd(types);
        }

        private double Execute(Func<IOperation, bool> selector, double[] args)
        {

            //находим операцию по имени
            var oper = Operations.FirstOrDefault(selector);

            if (oper != null)
            {
                var displayOper = oper as IDisplayOperation;

                LastOperationName = displayOper != null 
                    ? LastOperationName = displayOper.DisplayName 
                    : LastOperationName = oper.Name;

                //вычисляем результат
                var result = oper.Execute(args);
                //отдаём пользователю
                return result;
            }

            throw new NotSupportedException("Не найдена запрашиваемая операция");


            //return Operations;
        }
        
        public double Execute(long code, double[] args)
        {
            return Execute(i => i.Code == code, args);
        }

        public double Execute(string name, double[] args)
        {
            return Execute(i => i.Name == name, args);
        }


        public double Execute(Func<double[], double> fun, double[] args)
        {
            return fun(args);
        }

        public static double ToDouble(string arg)
        {
            double x;
            if (!double.TryParse(arg, out x))
            {
                Console.WriteLine("Введённый вами аргумент не верен.");
                //Environment.Exit(0);

            }

            return x;
        }












        /// <summary>
        /// Сумма
        /// </summary>
        /// <param name="x">Слагаемое</param>
        /// <param name="y">Слагаемое</param>
        /// <returns>Число с плавающей точкой</returns>
        [Obsolete("Используйте Execute('+'). Данная функция будет удалена в версии 4.0")]
        public double Sum(double x, double y)
        {
            return x + y;
        }

        /// <summary>
        /// Квадратный корень
        /// </summary>
        /// <param name="x">Квадрат числа</param>
        /// <returns>Число с плавающей точкой</returns>
        [Obsolete("Используйте Execute('sqrt'). Данная функция будет удалена в версии 4.0")]
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
        [Obsolete("Используйте Execute('/'). Данная функция будет удалена в версии 4.0")]
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
        [Obsolete("Используйте Execute('*'). Данная функция будет удалена в версии 4.0")]
        public double Mpl(double x, double y)
        {
            return x * y;
        }

        [Obsolete("Используйте Execute(pow). Данная функция будет удалена в версии 4.0")]
        public double Pow(double x, double y)
        {
            return Math.Pow(x, y);
        }
    }
}
