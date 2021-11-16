using System.Web.Mvc;
using GrainMaster.BuisnessLogic;

namespace GrainMaster.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ViewResult Get(string CName)
        {
            return View(News.GetNewsDetail(CName));
        }
        public ViewResult GetAll()
        {
            return View("../News/Get",News.GetAllNews());
        }
    }
}