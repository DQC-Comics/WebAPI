namespace DQC.Comics.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using DQC.Comics.WebAPI.Hubs;
    using DQC.Comics.WebAPI.Models;

    public class BookingsController : ApiControllerWithHub<BookingsHub>
    {
        private ComicsDbContext db = new ComicsDbContext();

        // GET: api/Bookings
        public IEnumerable<ApiBooking> GetBookings()
        {
            return this.db.Bookings.ToList().Select(BookingExtensions.ToApiBooking);
        }

        // GET: api/Bookings/5
        [ResponseType(typeof(ApiBooking))]
        public IHttpActionResult GetBooking(int id)
        {
            DbBooking booking = this.db.Bookings.Find(id);
            if (booking == null)
            {
                return this.NotFound();
            }

            return this.Ok(booking.ToApiBooking());
        }

        // PUT: api/Bookings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBooking(int id, ApiBooking booking)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != booking.Id)
            {
                return this.BadRequest();
            }

            var persistedBooking = this.db.Bookings.Find(id);
            if (persistedBooking == null)
            {
                return this.NotFound();
            }

            persistedBooking.Status = booking.Status;
            this.db.SaveChanges();

            this.Hub.Clients.All.bookingUpdated(persistedBooking.ToApiBooking());
            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Bookings
        [ResponseType(typeof(ApiBooking))]
        public IHttpActionResult PostBooking(ApiBooking booking)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var persistedBooking = booking.ToDbBooking();
            persistedBooking.Heroes = booking.Heroes.Select(_ => this.db.Heroes.Find(_.Id)).Where(_ => _ != null).ToList();

            var hero = persistedBooking.Heroes.FirstOrDefault();
            if (hero != null)
            {
                persistedBooking.DebitHours = Math.Max((persistedBooking.EndTime - persistedBooking.StartTime).TotalHours, 0);
                persistedBooking.ActualHours = persistedBooking.DebitHours;
                persistedBooking.TotalDebitPrice = persistedBooking.DebitHours * hero.DebitPrice;
                persistedBooking.TotalInternalPrice = persistedBooking.ActualHours * hero.InternalPrice;
            }

            this.db.Bookings.Add(persistedBooking);
            this.db.SaveChanges();

            this.Hub.Clients.All.bookingCreated(persistedBooking.ToApiBooking());
            return this.CreatedAtRoute("DefaultApi", new { id = persistedBooking.Id }, persistedBooking.ToApiBooking());
        }

        // DELETE: api/Bookings/5
        [ResponseType(typeof(ApiBooking))]
        public IHttpActionResult DeleteBooking(int id)
        {
            DbBooking booking = this.db.Bookings.Find(id);
            if (booking == null)
            {
                return this.NotFound();
            }

            this.db.Bookings.Remove(booking);
            this.db.SaveChanges();

            return this.Ok(booking);
        }

        // POST: api/Bookings
        [ResponseType(typeof(ApiBooking))]
        [Route("api/Bookings/{id}/ratings")]
        public IHttpActionResult PostBookingRatings(int id, ApiBookingRating rating)
        {
            var persistedBooking = this.db.Bookings.Find(id);
            if (persistedBooking == null)
            {
                return this.NotFound();
            }

            persistedBooking.CustomerRating = rating.Rating;
            this.db.SaveChanges();

            this.Hub.Clients.All.bookingUpdated(persistedBooking.ToApiBooking());
            return this.Ok(persistedBooking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingExists(int id)
        {
            return this.db.Bookings.Count(e => e.Id == id) > 0;
        }
    }
}
