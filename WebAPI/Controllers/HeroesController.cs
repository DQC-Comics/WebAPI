namespace DQC.Comics.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using DQC.Comics.WebAPI.Models;

    public class HeroesController : ApiController
    {
        private ComicsDbContext db = new ComicsDbContext();

        // GET: api/Heroes
        public IEnumerable<ApiHeroLimited> GetHeroes()
        {
            return this.db.Heroes.ToList().Select(_ => _.ToApiHeroLimited());
        }

        // GET: api/Heroes?query=text
        public IEnumerable<ApiHeroLimited> PostHeroes(ApiHeroSearch search)
        {
            // TODO: implement query logic
            var rnd = new Random();
            return this.db.Heroes.ToList().Select(_ => _.ToApiHeroLimited()).OrderByDescending(_ => rnd.Next());
        }

        // GET: api/Heroes/5
        [ResponseType(typeof(ApiHeroLimited))]
        public IHttpActionResult GetHero(int id)
        {
            var hero = this.db.Heroes.Find(id);
            if (hero == null)
            {
                return this.NotFound();
            }

            return this.Ok(hero.ToApiHeroLimited());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
