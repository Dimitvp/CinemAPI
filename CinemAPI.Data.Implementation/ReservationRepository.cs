using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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

        public IReservation Insert(IReservationCreation reserv)
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
            //List<Projection> results = (from p in db.Projections
            //                            where p.Id == reserv.ProjectionId
            //                            select p).ToList();

            //foreach (Projection p in results)
            //{
            //    p.AvailableSeatsCount--;
            //}

            db.Projections
                .Where(p => p.Id == reserv.ProjectionId)
                .ToList()
                .ForEach(x => x.AvailableSeatsCount--);

            db.SaveChanges();
                return newReserv;
        }

        public void CancelReservation(IReservationRequest reserv)
        {
            DateTime now = DateTime.UtcNow;

             db.Reservations
                .Where(r => DbFunctions.DiffMinutes(r.ProjectionStartDate, now) < 10 &&
                            DbFunctions.DiffMonths(r.ProjectionStartDate, now) == 0 &&
                            DbFunctions.DiffDays(r.ProjectionStartDate, now) == 0 &&
                            DbFunctions.DiffHours(r.ProjectionStartDate, now) == 0)
                .ToList()
                .ForEach(x => x.IsActive = false);

            var expiredReservations = db.Reservations
                .Where(r => r.IsActive == false)
                .ToList()
                .Count();

            if (expiredReservations > 0)
            {
                var forDeletion = db.Reservations
                .Where(r => r.IsActive == false)
                .ToList();

                foreach (var res in forDeletion)
                {
                    db.Reservations.Remove(res);
                }

                db.Projections
                .Where(p => p.Id == reserv.ProjectionId)
                .ToList()
                .ForEach(x => x.AvailableSeatsCount += expiredReservations);
            }
            
            db.SaveChanges();
        }

        public IReservation GetReservationByGuid(string guid)
        {
            return db.Reservations
                .Where(r => r.Guid == guid && r.IsActive == true)
                .FirstOrDefault();
        }
    }
}
