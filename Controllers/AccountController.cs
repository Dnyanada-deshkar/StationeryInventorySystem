using System.Web.Mvc;
using StationeryInventorySystem.Models;

namespace StationeryInventorySystem.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == "admin" &&
                    model.Password == "admin123")
                {
                    return RedirectToAction("Index", "Dashboard");
                }

                ViewBag.Error = "Invalid Username or Password";
            }

            return View(model);
        }
    }
}