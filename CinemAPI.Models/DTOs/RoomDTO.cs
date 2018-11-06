using CinemAPI.Models.Contracts.Room;

namespace CinemAPI.Models.DTOs
{
    public class RoomDTO : IRoom
    {
        public int Id {get; set; }

        public int CinemaId { get; set; }

        public int Number { get; set; }

        public short SeatsPerRow { get; set; }

        public short Rows { get; set; }
    }
}
