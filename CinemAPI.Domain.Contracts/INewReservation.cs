using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservetion;

namespace CinemAPI.Domain.Contracts
{
    public interface INewReservation
    {
        NewReservationSummery New(IReservationRequest reservation);
    }
}
