using FactoryManagement.data;
using FactoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace FactoryManagement.Controllers
{

    public class DepartmentController : Controller

    {
        private readonly FactoryManagementDBContext _context;

        public DepartmentController(FactoryManagementDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("FullName")))
            {
                return RedirectToAction("Index", "LogIn");

            }


            return View(_context.Deparments);

        }
        public IActionResult Delete(int id)
        {

            var department = _context.Deparments.FirstOrDefault(x => x.Id == id);
            if (department != null)
            {
                _context.Deparments.Remove(department);
                _context.SaveChanges();
             
            }
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(string name)
        {
            if (HttpContext.Session.GetInt32("Id") != null)
            {
                
                Department deparment = new Department {Name = name, ManagerId = HttpContext.Session.GetInt32("Id") ?? 1 };
                _context.Deparments.Add(deparment);
                _context.SaveChanges(); 
              
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)

        {
            return View(_context.Deparments.FirstOrDefault(d => d.Id == id));
        }

        [HttpPost]
        public IActionResult Update(string name, int id)
        {
            if (HttpContext.Session.GetInt32("Id") != null)
            {

                Department deparment = _context.Deparments.FirstOrDefault(_context => _context.Id == id);
                deparment.Name = name;
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

    }
}
