using Newbay.DALIZAADA.Repositories;
using Newbay.ModelsIZAADA;
using System.Collections.Generic;
using System.Web.Http;


namespace Newbay.WEBAPIIZAADA.Controllers
{
    public class WingController : ApiController
    {
        private IWingRepository repo;

        public WingController()
        {
            repo = new WingRepository();
        }

        public IEnumerable<Wing> get() => repo.GetAll();

        public Wing get(int id) => repo.GetById(id);

        public int post(Wing wing) => repo.Create(wing);

        public IHttpActionResult put(Wing wing)
        {
            repo.Update(wing);
            return Ok();
        }

        public IHttpActionResult delete(int id)
        {
            repo.Delete(id);
            return Ok();
        }
    }
}