using CinemAPI.Models.Contracts.Projection;
using System;
using System.ComponentModel.DataAnnotations;

namespace CinemAPI.Models
{
    public class Projection : IProjection, IProjectionCreation
    {
        //private int availableSeatsCount;

        public Projection()
        {
        }

        public Projection(int movieId, int roomId, DateTime startdate, int availableSeatsCount)
        {
            this.MovieId = movieId;
            this.RoomId = roomId;
            this.StartDate = startdate;
            this.AvailableSeatsCount = availableSeatsCount;
        }

        public long Id { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public DateTime StartDate { get; set; }

        [Range(0,int.MaxValue, ErrorMessage = "It sucks to eat popcorns, standing up ;) Cinema needs seats!")]
        public int AvailableSeatsCount
        {
            get;
            //{
            //    return this.availableSeatsCount;
            //}
            set;
            //{
            //    if (value < 0)
            //    {
            //        throw new ArgumentException("Projection with no available seats is not accepted!");
            //    };
            //    this.availableSeatsCount = value;
            //}
        }
    }
}