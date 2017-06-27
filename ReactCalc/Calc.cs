using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactorialLibrary;
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

        public IList<IOperation> Operations { get; private set; }

        public Calc()
        {
            Operations = new List<IOperation>();
            Operations.Add(new SumOperation());
            Operations.Add(new MplOperation());
            Operations.Add(new DivOperation());

            //var dllName = Directory.GetCurrentDirectory() + "\\FactorialLibrary.dll";
            var dllName = "..\\..\\..\\AdditionalLib\\bin\\Debug\\AdditionalLib.dll";
            if (!File.Exists( dllName))
            {
                return;
            }

            // загружаем сборку
            var assembly = Assembly.LoadFrom(dllName);
            // получаем все тип/классы из неё
            var types = assembly.GetTypes();
            // перебираем типы
            foreach (var t in types)
            { 
                // находим тех, кто реализует интерфейс IOperation
                var interfs = t.GetInterfaces();
                if (interfs.Contains(typeof(IOperation)))
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
            //Operations.Add(new FactorialOperation());    
        }

        private double Execute(Func<IOperation, bool> selector, double[] args)
        {

            //находим операцию по имени
            IOperation oper = Operations.FirstOrDefault(selector);

            if (oper != null)
            {
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














        /// <summary>
        /// Сумма
        /// </summary>
        /// <param name="x">Слагаемое</param>
        /// <param name="y">Слагаемое</param>
        /// <returns>Число с плавающей точкой</returns>
        [Obsolete("Используйте Execute(SUM). Данная функция будет удалена в версии 4.0")]
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


        public double Pow(double x, double y)
        {
            return Math.Pow(x, y);
        }
    }
}
