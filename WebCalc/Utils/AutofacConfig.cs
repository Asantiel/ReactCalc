using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using DomainModels.EF;
using DomainModels.Repository;
using System.Web.Mvc;


namespace WebCalc
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<ORRepository>().As<IORRepository>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
