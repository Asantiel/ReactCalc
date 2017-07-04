using ReactCalc.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace ReactCalc
{
    /// <summary>
    /// Калькулятор
    /// </summary>
    public class Calc
    {

        public string LastOperationName { get; set; }

        public Calc()
        {
            Operations = new List<IOperation>();

            var currentAssembly = Assembly.GetAssembly(typeof(IOperation));
            GetOperations(currentAssembly);

            // директория с расширениями
            var extsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Extensions");

            if (!Directory.Exists(extsDirectory))
                return;

            var exts = Directory.GetFiles(extsDirectory, "*.dll");

            foreach (var dllName in exts)
            {
                var assembly = Assembly.LoadFrom(dllName);
                GetOperations(assembly);
            }

        }

        private void GetOperations(Assembly assembly)
        {
            // получаем всем типы/классы из нее
            var types = assembly.GetTypes();
            // перебираем типы
            var searchInterface = typeof(IOperation);
            foreach (var t in types)
            {
                if (t.IsAbstract || t.IsInterface)
                    continue;

                // находим тех, кто реализует интерфейc IOperation
                var interfs = t.GetInterfaces();
                if (interfs.Contains(searchInterface))
                {
                    // создаем экземпляр найденного класса
                    var instance = Activator.CreateInstance(t) as IOperation;
                    if (instance != null)
                    {
                        // добавляем его в наш список операций
                        Operations.Add(instance);
                    }
                }
            }
        }

        public IList<IOperation> Operations { get; private set; }

        private double Execute(Func<IOperation, bool> selector, double[] args)
        {
            // находим операцию по имени
            var oper = Operations.FirstOrDefault(selector);

            if (oper != null)
            {

                var displayOper = oper as IDisplayOperation;

                LastOperationName = displayOper != null
                    ? displayOper.DisplayName
                    : oper.Name;

                // вычисляем результат 
                var result = oper.Execute(args);
                // отдаем пользователю
                return result;
            }

            throw new NotSupportedException("Не найдена запрашиваемая операция");
        }

        public double Execute(string name, double[] args)
        {
            return Execute(i => i.Name == name, args);
        }

        public double Execute(long code, double[] args)
        {
            return Execute(i => i.Code == code, args);
        }

        public double Execute(Func<double[], double> fun, double[] args)
        {
            return fun(args);
        }

        public static double ToNumber(string arg, double def = 0)
        {
            double x;
            if (!double.TryParse(arg, out x))
            {
                x = def;
            }

            return x;
        }

        /// <summary>
        /// Сумма
        /// </summary>
        /// <param name="x">Слагаемое</param>
        /// <param name="y">Слагаемое</param>
        /// <returns>Целое число</returns>
        [Obsolete("Используйте Execute('sum', new[]{x, y}). Данная функция будет удалена в версии 4.0")]
        public double Sum(double x, double y)
        {
            return Execute("sum", new[] { x, y });
        }

        public double Divide(double x, double y)
        {
            return x / y;
        }

        public double Sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        public double Pow(double x, double y)
        {
            return Math.Pow(x, y);
        }

    }
}
