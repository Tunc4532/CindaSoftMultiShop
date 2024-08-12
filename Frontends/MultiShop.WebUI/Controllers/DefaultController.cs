using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.directory1 = "ÇindaSoft";
            ViewBag.directory2 = "Anasayfa";
            ViewBag.directory3 = "Ürün Listesi";
            return View();
        }
    }
}
