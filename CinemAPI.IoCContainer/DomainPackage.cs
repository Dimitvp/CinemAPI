using CinemAPI.Domain;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.NewProjection;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace CinemAPI.IoCContainer
{
    public class DomainPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<INewProjection, NewProjectionCreation>();
            container.RegisterDecorator<INewProjection, NewProjectionMovieValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionUniqueValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionRoomValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionPreviousOverlapValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionNextOverlapValidation>();
        }
    }
}