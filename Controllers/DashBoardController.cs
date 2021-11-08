using System.Web.Mvc;

namespace GrainMaster.Controllers
{
    
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Dashboard()
        {
            return View(PortFolio.GetAll());
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult StaticNonAuth()
        {
            return View();
        }

        public ActionResult UserEdit()
        {
            return View();
        }
    }
}