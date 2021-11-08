using GrainMaster.BuisnessLogic;
using System.Web.Mvc;

namespace GrainMaster.Controllers
{
    public class DealController : Controller
    {
        // GET: Deal
        public ActionResult GetDeal()
        {
            return View(Deal.Get());
        }
    }
}