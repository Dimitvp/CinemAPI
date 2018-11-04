using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Input.Projection;
using System;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class ProjectionController : ApiController
    {
        private readonly INewProjection newProj;
        private readonly IProjectionRepository projectionRepo;

        public ProjectionController(INewProjection newProj, IProjectionRepository projectionRepo)
        {
            this.newProj = newProj;
            this.projectionRepo = projectionRepo;
        }

        [HttpPost]
        public IHttpActionResult Index(ProjectionCreationModel model)
        {
            NewProjectionSummary summary = newProj.New(new Projection(model.MovieId, model.RoomId, model.StartDate, model.AvailableSeatsCount));

            if (summary.IsCreated)
            {
                return Ok();
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult SeatsCount(int id)
        {
            IProjection projection = projectionRepo.GetById(id);

            if (projection.StartDate <= DateTime.UtcNow)
            {
                return BadRequest("Check the timeline Dummy :) It looks like you missed that one!");
            }

            if (projection.AvailableSeatsCount == 0)
            {
                return Ok($"Next time be faster. Available Seats:{projection.AvailableSeatsCount}");
            }

            return Ok($"It looks like it is your lucky day. Available Seats: {projection.AvailableSeatsCount}");
        }
        //[HttpPost]
        //public IHttpActionResult Create(ProjectionCreationModel model)
        //{
        //    NewProjectionSummary summary = newProj.New(new Projection(model.MovieId, model.RoomId, model.StartDate, model.AvailableSeatsCount));

        //    if (summary.IsCreated)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest(summary.Message);
        //    }
        //}
    }
}