using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YaustinMusicShopOnline.Models;

namespace YaustinMusicShopOnline.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            
                return View();
           
        }
    }
}
