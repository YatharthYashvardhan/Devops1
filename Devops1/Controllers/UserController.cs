using Devops1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Devops1.Controllers
{ 
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserInfo userInfo)
        {
            return View("Display", userInfo);
        }
    }
}
