namespace DQC.Comics.WebAPI.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using DQC.Comics.WebAPI.Models;

    public class HeroesController : ApiController
    {
        private ComicsDbContext db = new ComicsDbContext();

        // GET: api/Heroes
        public IQueryable<Hero> GetHeroes()
        {
            return this.db.Heroes;
        }

        // GET: api/Heroes/5
        [ResponseType(typeof(Hero))]
        public IHttpActionResult GetHero(int id)
        {
            Hero hero = this.db.Heroes.Find(id);
            if (hero == null)
            {
                return this.NotFound();
            }

            return this.Ok(hero);
        }

        // PUT: api/Heroes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHero(int id, Hero hero)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != hero.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(hero).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.HeroExists(id))
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

        // POST: api/Heroes
        [ResponseType(typeof(Hero))]
        public IHttpActionResult PostHero(Hero hero)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Heroes.Add(hero);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = hero.Id }, hero);
        }

        // DELETE: api/Heroes/5
        [ResponseType(typeof(Hero))]
        public IHttpActionResult DeleteHero(int id)
        {
            Hero hero = this.db.Heroes.Find(id);
            if (hero == null)
            {
                return this.NotFound();
            }

            this.db.Heroes.Remove(hero);
            this.db.SaveChanges();

            return this.Ok(hero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HeroExists(int id)
        {
            return this.db.Heroes.Count(e => e.Id == id) > 0;
        }
    }
}
