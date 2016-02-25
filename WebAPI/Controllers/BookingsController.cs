namespace DQC.Comics.WebAPI.Controllers
{
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
        public IQueryable<Booking> GetBookings()
        {
            return this.db.Bookings;
        }

        // GET: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public IHttpActionResult GetBooking(int id)
        {
            Booking booking = this.db.Bookings.Find(id);
            if (booking == null)
            {
                return this.NotFound();
            }

            return this.Ok(booking);
        }

        // PUT: api/Bookings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBooking(int id, Booking booking)
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
        [ResponseType(typeof(Booking))]
        public IHttpActionResult PostBooking(Booking booking)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Bookings.Add(booking);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = booking.Id }, booking);
        }

        // DELETE: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public IHttpActionResult DeleteBooking(int id)
        {
            Booking booking = this.db.Bookings.Find(id);
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