namespace CinemAPI.Domain.Contracts.Models
{
    public class NewReservationSummery
    {
        public NewReservationSummery(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public NewReservationSummery(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }
    }
}
