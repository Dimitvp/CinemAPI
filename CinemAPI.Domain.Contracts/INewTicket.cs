using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Domain.Contracts
{
    public interface INewTicket
    {
        NewTicketSummery New(ITicketRequest Ticket);
    }
}
