using FactoryManagement.data;
using FactoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace FactoryManagement.Controllers
{
    public class ShiftController : Controller
    {

        private FactoryManagementDBContext _context;

        public ShiftController(FactoryManagementDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Shifts);
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(DateTime date, int startTime, int endTime) {
        
        Shift shift = new Shift {Date = date, StartTime = startTime, EndTime = endTime };
        _context.Shifts.Add(shift);
           _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
