using CinemAPI.Domain;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.NewProjection;
using CinemAPI.Domain.NewReservation;
using CinemAPI.Domain.NewTicket;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace CinemAPI.IoCContainer
{
    public class DomainPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            //Projection Containers
            container.Register<INewProjection, NewProjectionCreation>();
            container.RegisterDecorator<INewProjection, NewProjectionMovieValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionUniqueValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionRoomValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionPreviousOverlapValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionNextOverlapValidation>();

            //Reservation Containers
            container.Register<INewReservation, NewReservationCreation>();
            container.RegisterDecorator<INewReservation, NewReservationSeatsValidation>();
            container.RegisterDecorator<INewReservation, NewReservationRoomValidation>();
            container.RegisterDecorator<INewReservation, NewReservationProjectionValidation>();
            container.RegisterDecorator<INewReservation, NewReservationValidation>();

            //Ticket Containers
            container.Register<INewTicket, NewTicketCreation>();
            container.RegisterDecorator<INewTicket, NewTicketProjectionValidation>();
            container.RegisterDecorator<INewTicket, NewTicketReservationValidation>();
        }
    }
}