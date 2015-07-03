using System.Web.Mvc;
using BankAccountsManagementSystem.DataAccessLayer;

namespace BankAccountsManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}