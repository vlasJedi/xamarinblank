using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Autofac;
using Xamarin.Forms;
using xamarinblank.Models;
using xamarinblank.Repositories;
using xamarinblank.ViewModels;

namespace xamarinblank
{
    public abstract class Bootstraper
    {
        protected ContainerBuilder ContainerBuilder { get; private set; }

        public Bootstraper()
        {
            Initialize();
            FinishInitialization();
        }

        protected virtual void Initialize()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();

            foreach (var type in currentAssembly.DefinedTypes
                         .Where(e => 
                             e.IsSubclassOf(typeof(Page)) ||
                             e.IsSubclassOf(typeof(ViewModel))))
            {
                ContainerBuilder.RegisterType(type.AsType());
            }

            ContainerBuilder.RegisterType<TodoItemRepository>().SingleInstance();
        }

        private void FinishInitialization()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}