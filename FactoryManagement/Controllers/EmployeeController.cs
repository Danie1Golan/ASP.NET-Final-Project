using FactoryManagement.data;
using FactoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FactoryManagement.Controllers
{
    public class EmployeeController : Controller
    {
       

       
        private FactoryManagementDBContext _context;

        public EmployeeController(FactoryManagementDBContext context) 
        {
            _context = context;
        }






        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("FullName")))
            {
                return RedirectToAction("Index", "LogIn");

            }

            return View(_context.Employees);
        }
        public IActionResult Delete(int id)
        {

            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.EmployeeShifts.RemoveRange(employee.EmployeeShifts);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
       

        public IActionResult Update(int id)
        {
            ViewBag.departments = _context.Deparments;
            return View(_context.Employees.FirstOrDefault(d => d.Id == id));
        }

        [HttpPost]
        public IActionResult Update(int id, string firstName, string lastName, int startWorkYear, int departmentId)
        {
            if (HttpContext.Session.GetInt32("Id") != null)
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                if (employee != null)
                {
                    employee.FirstName = firstName;
                    employee.LastName = lastName;
                    employee.DepartmentID = departmentId;
                    employee.StartWorkYear = startWorkYear; 
                    _context.SaveChanges();
                }
             
               

            }
            return RedirectToAction("Index");
        }
        public IActionResult Search(int departmentId, string firstName, string lastName) {

            var empolyees = _context.Employees.AsQueryable();
            if (departmentId != 0) {
                empolyees = empolyees.Where(e => e.DepartmentID == departmentId);

            }
            else if (firstName != null)
            {
                empolyees = empolyees.Where(empolyees => empolyees.FirstName.Contains(firstName));
            }
            else if (lastName != null)
            {
                empolyees = empolyees.Where(empolyees => empolyees.LastName.Contains(lastName));
            }
            return View(empolyees);
        }
    }
}
