using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using EF = DomainModels.EF;
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
            builder.RegisterType<EF.UserRepository>().As<IUserRepository>();
            builder.RegisterType<EF.ORRepository>().As<IORRepository>();
            builder.RegisterType<EF.OperationRepository>().As<IOperationRepository>();
            builder.RegisterType<EF.LikeRepository>().As<ILikeRepository>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
