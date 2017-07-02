using Autofac;
using MvvmContactList.Services;
using MvvmContactList.ViewModels;

namespace MvvmContactList
{
    public class DiContainer
    {
        static DiContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ContactsRepository>().As<IContactsRepository>().SingleInstance();
            builder.RegisterType<ContactsViewModel>();
            builder.RegisterType<UpdateViewModel>();
            builder.RegisterType<AddViewModel>();
            Container = builder.Build();
        }

        public static IContainer Container { get; }
    }
}