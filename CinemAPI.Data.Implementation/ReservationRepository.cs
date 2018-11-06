using System;
using System.Collections.Generic;
using System.Linq;
using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservetion;
using CinemAPI.Models.DTOs;

namespace CinemAPI.Data.Implementation
{
    public class ReservationRepository : IReservatioRepository
    {
        private readonly CinemaDbContext db;

        public ReservationRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<IReservation> GetRowsColsById(long id)
        {
            return db.Reservations
                .Where(r => r.ProjectionId == id)
                .SelectMany(x => new List<ReservationDTO>() {
                    new ReservationDTO
                    {
                        Row = x.Row,
                        Column = x.Column
                    }})
                .ToList();
        }

        public IReservation GetRestInfo(long id)
        {
            return db.Projections
                .Where(p => p.Id == id)
                .Select(s => new ReservationDTO
                {
                    ProjectionStartDate = s.StartDate,
                    MovieName = s.Movie.Name,
                    RoomNum = s.Room.Number,
                    CinemaName = s.Room.Cinema.Name
                })
                .Single();
        }

        public IReservationTicket Insert(IReservationCreation reserv)
        {
            Reservation newReserv = new Reservation(
                reserv.ProjectionId, 
                reserv.Guid, 
                reserv.ProjectionStartDate, 
                reserv.MovieName, 
                reserv.CinemaName, 
                reserv.RoomNum, 
                reserv.Row, 
                reserv.Column, 
                reserv.IsActive);

            db.Reservations.Add(newReserv);
            db.Projections.Where(p => p.Id == reserv.ProjectionId).Select(p => p.AvailableSeatsCount - 1);
            db.SaveChanges();

            return newReserv;
        }

        public void CancelReservation(IReservationRequest reserv)
        {
            DateTime now = DateTime.UtcNow;

            db.Reservations.Where(r => now > r.ProjectionStartDate.AddMinutes(-10)).Select(r => r.IsActive == false);
            db.Projections.Where(p => p.Id == reserv.ProjectionId).Select(p => p.AvailableSeatsCount + 1);
            db.SaveChanges();
        }
    }
}
