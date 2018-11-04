using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Projection;

namespace CinemAPI.Domain
{
    public class NewProjectionCreation : INewProjection
    {
        private readonly IProjectionRepository projectionsRepo;

        public NewProjectionCreation(IProjectionRepository projectionsRepo)
        {
            this.projectionsRepo = projectionsRepo;
        }

        public NewProjectionSummary New(IProjectionCreation projection)
        {
            if (projection.AvailableSeatsCount < 0)
            {
                return new NewProjectionSummary(false, $"It sucks to eat popcorns, standing up ;) Cinema needs seats!");
            }

            projectionsRepo.Insert(new Projection(projection.MovieId, projection.RoomId, projection.StartDate, projection.AvailableSeatsCount));

            return new NewProjectionSummary(true);
        }
    }
}