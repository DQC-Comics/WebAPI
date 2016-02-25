namespace DQC.Comics.WebAPI.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using DQC.Comics.WebAPI.Models;

    public class SkillsController : ApiController
    {
        private ComicsDbContext db = new ComicsDbContext();

        // GET: api/Skills
        public IQueryable<Skill> GetSkills()
        {
            return this.db.Skills;
        }

        // GET: api/Skills/5
        [ResponseType(typeof(Skill))]
        public IHttpActionResult GetSkill(int id)
        {
            Skill skill = this.db.Skills.Find(id);
            if (skill == null)
            {
                return this.NotFound();
            }

            return this.Ok(skill);
        }

        // PUT: api/Skills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkill(int id, Skill skill)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != skill.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(skill).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.SkillExists(id))
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

        // POST: api/Skills
        [ResponseType(typeof(Skill))]
        public IHttpActionResult PostSkill(Skill skill)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Skills.Add(skill);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = skill.Id }, skill);
        }

        // DELETE: api/Skills/5
        [ResponseType(typeof(Skill))]
        public IHttpActionResult DeleteSkill(int id)
        {
            Skill skill = this.db.Skills.Find(id);
            if (skill == null)
            {
                return this.NotFound();
            }

            this.db.Skills.Remove(skill);
            this.db.SaveChanges();

            return this.Ok(skill);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkillExists(int id)
        {
            return this.db.Skills.Count(e => e.Id == id) > 0;
        }
    }
}