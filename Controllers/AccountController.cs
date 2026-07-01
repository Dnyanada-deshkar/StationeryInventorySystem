using System.Web.Mvc;
using System.Web.Security;
using StationeryInventorySystem.Models;

namespace StationeryInventorySystem.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Login()
        {
            ViewBag.Error = TempData["Error"];
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Username == "admin" &&
                model.Password == "admin123")
            {
                FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                return RedirectToAction("Index", "Dashboard");
            }

            TempData["Error"] = "Invalid username or password.";
            return RedirectToAction("Login");
        }


        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();

            return RedirectToAction("Login");

        }

    }
}