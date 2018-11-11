using CinemAPI.Models.Contracts.Ticket;
using System.Collections.Generic;

namespace CinemAPI.Data
{
    public interface ITicketRepository
    {
        IEnumerable<ITicket> GetRowsColsById(long id);

        ITicket GetRestInfo(long id);

        ITicket Insert(ITicketCreation ticket);
    }
}
