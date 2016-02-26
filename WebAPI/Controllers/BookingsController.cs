namespace DQC.Comics.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using DQC.Comics.WebAPI.Models;

    public class BookingsController : ApiController
    {
        private ComicsDbContext db = new ComicsDbContext();

        // GET: api/Bookings
        public IEnumerable<ApiBooking> GetBookings()
        {
            return this.db.Bookings.ToList().Select(_ => _.ToApiBooking());
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

            this.db.Entry(booking).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.BookingExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

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

            var presistedBooking = booking.ToDbBooking();
            this.db.Bookings.Add(presistedBooking);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = presistedBooking.Id }, presistedBooking.ToApiBooking());
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
