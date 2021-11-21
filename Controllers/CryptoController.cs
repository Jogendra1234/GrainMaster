using System.Web.Mvc;
using GrainMaster.BuisnessLogic;
using GrainMaster.Models;

namespace GrainMaster.Controllers
{
    public class CryptoController : Controller
    {

        [HttpPost]
        public ActionResult InsertCampaigen(CryptoModel cryptoModel)
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