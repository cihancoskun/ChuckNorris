using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using App.Domain.RepositoryInterfaces;
using App.Infrastructure.Logging;
using App.Infrastructure.Repository;

using Castle.Facilities.TypedFactory;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace App.Web.NedSet._Configuration
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }

            return (IController)_kernel.Resolve(controllerType);
        }
    }

    public class ClassSelector : DefaultTypedFactoryComponentSelector
    {
        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            return (string)arguments[0];
        }
    }

    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().Unless(x => x.Name == "BaseController").LifestyleTransient());
        }
    }

    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient(),
                //Component.For<IUserService>().ImplementedBy<UserService>().LifestyleTransient(),
                //Component.For<ITagService>().ImplementedBy<TagService>().LifestyleTransient(),
                //Component.For<IInformationService>().ImplementedBy<InformationService>().LifestyleTransient(),
                //Component.For<IMailService>().ImplementedBy<Imap4>().Named(ConstHelper.Imap4).LifestyleTransient(),
                //Component.For<IMailService>().ImplementedBy<Pop3>().Named(ConstHelper.Pop3).LifestyleTransient(),
                //Component.For<ISpidyaService>().ImplementedBy<SpidyaService>().LifestyleTransient(),
                //Component.For<ISpidyaServiceForWebApi>().ImplementedBy<SpidyaServiceForWebApi>().LifestyleTransient(),
                //Component.For<IQueueService>().ImplementedBy<QueueService>().LifestyleSingleton(),
                //Component.For<IFormsAuthenticationService>().ImplementedBy<FormsAuthenticationService>().LifestylePerWebRequest(),
                Component.For<ILoggingService>().ImplementedBy<LoggingService>().LifestyleTransient()
                //Component.For<IFeedbackService>().ImplementedBy<FeedbackService>().LifestyleTransient(),
                //Component.For<IMailServiceFactory>().AsFactory(new ClassSelector())
                );
        }
    }
}
