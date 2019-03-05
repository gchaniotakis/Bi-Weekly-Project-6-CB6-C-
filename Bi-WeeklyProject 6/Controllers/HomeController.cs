using Bi_WeeklyProject_6.Models;
using System.Web.Mvc;

namespace Bi_WeeklyProject_6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            User loggedUser = Session["user"] as User;
            return View(loggedUser);
        }
        public ActionResult Complete()
        {
            User loggedUser = Session["user"] as User;
            loggedUser.Role += 1;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}