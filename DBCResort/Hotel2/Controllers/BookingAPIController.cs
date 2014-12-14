using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Hotel2.Models;

namespace Hotel2.Controllers
{
    public class BookingAPIController : ApiController
    {
        private DBCResortEntities db = new DBCResortEntities();



        //get rooms
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public IQueryable<int> GetRooms()
        {
            return  (from room in db.Rooms
                    
                    select  room.idRoom );
        }

        //get news
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public IQueryable GetNews()
        {
           /* var lista = new List<Object>();
            var x = (from news in db.News select new {news.Place, news.Text});
            lista.Add(x);
            return lista.AsQueryable();
           */
            return (from news in db.News


                    select new { news.Place, news.Text });
        }



        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult enterbooking(int room, DateTime sdate, DateTime edate, int numguests)
        {




            Reservation m = new Reservation();
            m.idRoom = room;
            m.idGuest = 1;
            m.idEmpoyee = 1;
            m.ReservationDate = DateTime.Now;
            m.StartDate = sdate;
            m.EndDate = edate;
            m.NumOfGuests = numguests;


            db.Reservations.Add(m);
            db.SaveChanges();

            return Ok("Uspjesno rezervisano!");

        }

        // PUT api/BookingAPI/5
        public HttpResponseMessage PutReservation(int id, Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != reservation.idReservation)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(reservation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/BookingAPI
        public HttpResponseMessage PostReservation(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, reservation);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = reservation.idReservation }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/BookingAPI/5
        public HttpResponseMessage DeleteReservation(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Reservations.Remove(reservation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, reservation);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}