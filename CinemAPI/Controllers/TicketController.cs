using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Input.Ticket;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class TicketController : ApiController
    {
        private readonly INewTicket newTicket;

        public TicketController(INewTicket newTicket)
        {
            this.newTicket = newTicket;
        }

        [HttpPost]
        public IHttpActionResult Index(TicketRequestModel model)
        {
            if (model.Guid != null)
            {

            }

            NewTicketSummery summery = newTicket.New(new Ticket(
                model.ProjectionId,
                model.Row,
                model.Column
                ));

            if (summery.IsCreated)
            {
                return Ok(summery.Ticket);
            }
            else
            {
                return BadRequest(summery.Message);
            }
        }
    }
}