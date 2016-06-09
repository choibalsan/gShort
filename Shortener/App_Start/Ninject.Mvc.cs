using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Shortener.Models.Interfaces;
using Shortener.Models.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;


namespace Ninject.Http
{
    /// <summary>
    /// Resolves Dependencies Using Ninject
    /// </summary>
    public class NinjectResolver : IDependencyResolver
    {
        public IKernel Kernel { get; private set; }
        public NinjectResolver(params NinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);
        }

        public NinjectResolver(Assembly assembly)
        {
            Kernel = new StandardKernel();
            Kernel.Load(assembly);
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
    }


    // List and Describe Necessary Modules
    public class NinjectModules
    {
        //Return Lists of Modules in the Application
        public static NinjectModule[] Modules
        {
            get
            {
                //Return Modules you want to use for DI
                return new[] { new MainModule() };
            }
        }

        //Main Module For Application. 
        public class MainModule : NinjectModule
        {
            public override void Load()
            {
                //TODO: Bind to Concrete Types Here
                Kernel.Bind<IShortenerService>().To<ShortenerService>().InRequestScope();
            }
        }
    }


    /// <summary>
    /// Its job is to Register Ninject Modules and Resolve Dependencies Manually (If need be)
    /// </summary>
    public class NinjectContainer
    {
        private static NinjectResolver _resolver;

        //Register Ninject Modules
        public static void RegisterModules(NinjectModule[] modules)
        {
            _resolver = new NinjectResolver(modules);
            DependencyResolver.SetResolver(_resolver);
        }

        public static void RegisterAssembly()
        {
            _resolver = new NinjectResolver(Assembly.GetExecutingAssembly());

            //This is where the actual hookup to the MVC Pipeline is done.
            DependencyResolver.SetResolver(_resolver);
        }

        //Manually Resolve Dependencies
        public static T Resolve<T>()
        {
            return _resolver.Kernel.Get<T>();
        }
    }
}
