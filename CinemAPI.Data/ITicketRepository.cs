using CinemAPI.Models.Contracts.Ticket;
using System.Collections.Generic;

namespace CinemAPI.Data
{
    public interface ITicketRepository
    {
        ITicket GetRestInfo(long id);

        ITicket Insert(ITicketCreation ticket);

    }
}
