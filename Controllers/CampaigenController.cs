using GrainMaster.BuisnessLogic;
using GrainMaster.Models;
using System.Web.Mvc;

namespace GrainMaster.Controllers
{
    
    public class CampaigenController : Controller
    {
        [HttpPost]
        public ActionResult InsertCampaigen(CampaigenModel cryptoModel)
        {
            return Json(Campaigen.SaveCampaigen(cryptoModel), JsonRequestBehavior.AllowGet);

        }

        public ViewResult GetCampaigen()
        {
            return View(Campaigen.Get());
        }

        public ActionResult Delete(int id)
        {
            Campaigen.DeleteCamp(id);
            ViewBag.Messsage = "Record Deleted Successfully!!";
            return RedirectToAction("GetCampaigen");
        }
    }
}