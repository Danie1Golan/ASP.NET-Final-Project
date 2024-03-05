using FactoryManagement.data;
using FactoryManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace FactoryManagement.Controllers
{
    public class LogInController : Controller
    { private readonly FactoryManagementDBContext _context;

        public LogInController(FactoryManagementDBContext factoryManagementDBContext)
        {
            _context = factoryManagementDBContext;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index (string username, string password)
        {
            if (username !=null && password !=null)
            {
             var user = _context.Users.FirstOrDefault (user => user.UserName == username && user.Password == password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("NumOfActions", user.NumOfActions);
                    HttpContext.Session.SetString("FullName", user.FullName);
                    HttpContext.Session.SetInt32("Id", user.Id);
                    return RedirectToAction ("Home");
                    


                }
                else
                {
                    ViewBag.error = "wrong password or username, please try again";

                }
               


            }
            return View();

           
        }
        public IActionResult Home ()
        {
            if (string.IsNullOrEmpty (HttpContext.Session.GetString("FullName")))
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult LogOut ()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
