using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Domain.Contracts.Models
{
    public class NewTicketSummery
    {
        public NewTicketSummery(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public NewTicketSummery(bool isCreated, ITicket ticket)
        {
            this.IsCreated = isCreated;
            this.Ticket = ticket;
        }


        public NewTicketSummery(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }

        public ITicket Ticket { get; }
    }
}
