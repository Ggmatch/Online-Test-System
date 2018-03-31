using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using System.Web.Http.Services;
using WebApiContrib.IoC.Ninject;
using AdministratorSystem.Models;
using Ninject.Extensions.ChildKernel;

namespace AdministratorSystem.Infrastructure
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectResolver() : this(new StandardKernel())
        {

        }
        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }
        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        public void Dispose()
        {

        }
        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
        }
        private IKernel AddRequestBindings(IKernel kernel)
        {
            kernel.Bind<IAdministratorRepository>().To<AdministratorRepository>().InSingletonScope();
            return kernel;
        }
    }
}