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
            kernel.Bind<IManageStuRepository>().To<ManageStuRepository>().InSingletonScope();
            kernel.Bind<ITypeOfWorkRepository>().To<TypeOfWorkRepository>().InSingletonScope();
            kernel.Bind<IManageTestPaperRepository>().To<ManageTestPaperRepository>().InSingletonScope();
            kernel.Bind<IManageTestPaper1Repository>().To<ManageTestPaper1Repository>().InSingletonScope();
            kernel.Bind<IQuestionBankRepository>().To<QuestionBankRepository>().InSingletonScope();
            kernel.Bind<IQuestionBank1Repository>().To<QuestionBank1Repository>().InSingletonScope();
            kernel.Bind<IStuGradeRepository>().To<StuGradeRepository>().InSingletonScope();
            kernel.Bind<IArrangeTestGameRepository>().To<ArrangeTestGameRepository>().InSingletonScope();
            kernel.Bind<ILetterRepository>().To<LetterRepository>().InSingletonScope();
            kernel.Bind<IOrganizationUserRepository>().To<OrganizationUserRepository>().InSingletonScope();
            kernel.Bind<IManageStu1Repository>().To<ManageStu1Repository>().InSingletonScope();
            kernel.Bind<IBoardRepository>().To<BoardRepository>().InSingletonScope();
            return kernel;
        }
    }
}