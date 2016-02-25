namespace DQC.Comics.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using DQC.Comics.WebAPI.Models;

    public class SkillsController : ApiController
    {
        private ComicsDbContext db = new ComicsDbContext();

        // GET: api/Skills
        public IEnumerable<ApiSkill> GetSkills()
        {
            return this.db.Skills.ToList().Select(_ => _.ToApiSkill());
        }

        // GET: api/Skills/5
        [ResponseType(typeof(ApiSkill))]
        public IHttpActionResult GetSkill(int id)
        {
            DbSkill skill = this.db.Skills.Find(id);
            if (skill == null)
            {
                return this.NotFound();
            }

            return this.Ok(skill.ToApiSkill());
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