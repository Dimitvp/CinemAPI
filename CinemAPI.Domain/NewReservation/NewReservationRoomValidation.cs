using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservetion;
using CinemAPI.Models.Contracts.Room;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationRoomValidation : INewReservation
    {
        private readonly INewReservation newReserv;
        private readonly IRoomRepository roomRepo;

        public NewReservationRoomValidation(INewReservation newReserv, IRoomRepository roomRepo)
        {
            this.newReserv = newReserv;
            this.roomRepo = roomRepo;
        }

        public NewReservationSummery New(IReservationRequest reservation)
        {
            IRoom room = roomRepo.GetRowsAndSeatsPerRow(reservation.ProjectionId);

            if (reservation.Row <= 0 || reservation.Column <= 0 || reservation.Row > room.Rows || reservation.Column > room.SeatsPerRow)
            {
                return new NewReservationSummery(false, $"This seat doesn`t exist. This room has Rows: {room.Rows} and Seats per row: {room.SeatsPerRow}");
            }

            return newReserv.New(reservation);
        }
    }
}
