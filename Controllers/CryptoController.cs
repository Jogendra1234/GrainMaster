using System.Web.Mvc;
using GrainMaster.BuisnessLogic;
using GrainMaster.Models;

namespace GrainMaster.Controllers
{
    public class CryptoController : Controller
    {
        public ViewResult GetCrypto()
        {
            return View(Crypto.Get());
        }
    }
}