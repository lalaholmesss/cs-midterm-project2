using Microsoft.AspNetCore.Mvc;
using RestaurantApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Linq;
using RestaurantApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace RestaurantApplication.Controllers {
    public class StaffController : Controller {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password) {
            var staff = _context.Staffs.FirstOrDefault(s => s.Username == username && s.Password == password);

            if (staff != null) {
                HttpContext.Session.SetInt32("StaffId", staff.Id);
                return RedirectToAction("Dashboard");
            }

            ViewData["LoginError"] = "Invalid username or password.";
            return View();
        }


        public IActionResult Dashboard() {
            var staffId = HttpContext.Session.GetInt32("StaffId");
            if (staffId == null) {
                return RedirectToAction("Login");
            }

            var orders = _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .ToList();

            return View(orders);
        }

        [HttpPost]
        public IActionResult MarkAsDone(int id) {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null) {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }

        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
