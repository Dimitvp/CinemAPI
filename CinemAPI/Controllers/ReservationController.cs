using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Input.Reservation;
using System;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly INewReservation newReserv;

        public ReservationController(INewReservation newReserv)
        {
            this.newReserv = newReserv;
        }

        [HttpPost]
        public IHttpActionResult Index(ReservationRequestModel model)
        {
            NewReservationSummery summery = newReserv.New(new Reservation(
                model.ProjectionId, 
                model.Row, 
                model.Column
                ));

            if (summery.IsCreated)
            {
                return Ok(summery.ReservationTicket);
            }
            else
            {
                return BadRequest(summery.Message);
            }
        }
    }
}