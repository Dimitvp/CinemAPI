using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Movie;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Ticket;
using System;

namespace CinemAPI.Domain.NewTicket
{
    public class NewTicketProjectionValidation : INewTicket
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly INewTicket newTicket;
        private readonly IMovieRepository movieRepo;


        public NewTicketProjectionValidation(IProjectionRepository projectionRepo, INewTicket newTicket, IMovieRepository movieRepo)
        {
            this.projectionRepo = projectionRepo;
            this.movieRepo = movieRepo;
            this.newTicket = newTicket;
        }

        public NewTicketSummery New(ITicketRequest ticket)
        {
            IProjection projection = projectionRepo.GetById(ticket.ProjectionId);

            if (projection == null)
            {
                return new NewTicketSummery(false, $"Projection with id {ticket.ProjectionId} does not exist");
            }

            IMovie movie = movieRepo.GetById(projection.MovieId);
            var now = DateTime.UtcNow;
            var projectionEnd = projection.StartDate.AddMinutes(movie.DurationMinutes);

            if (projection.StartDate <= now || projectionEnd <= now)
            {
                return new NewTicketSummery(false, $"Projection:{projection.Id} already started or finished!");
            }

            return newTicket.New(ticket);
        }
    }
}
