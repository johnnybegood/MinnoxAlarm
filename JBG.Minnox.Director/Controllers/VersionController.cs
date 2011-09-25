using System.Reflection;
using System.Web.Mvc;

namespace JBG.Minnox.Director.Controllers
{
    public class VersionController : Controller
    {
        //
        // GET: /Version/

        [HttpGet]
        public JsonResult Index()
        {
            return Json("1.0.0.0", JsonRequestBehavior.AllowGet);
        }

    }
}
