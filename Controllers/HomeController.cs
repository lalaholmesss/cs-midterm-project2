using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApplication.Models;
using RestaurantApplication.Data;
using Newtonsoft.Json;

namespace RestaurantApplication.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult Menu() {
            var items = _context.MenuItems.ToList();
            return View(items);
        }

        public IActionResult Order() {
            var menuItems = _context.MenuItems.ToList();

            var order = new Order {
                OrderItems = new List<OrderItem>()
            };

            ViewData["MenuItems"] = menuItems;
            return View(order);
        }

        [HttpPost]
        public IActionResult SubmitOrder(Order order, string OrderItemsJson) {
            var orderItems = JsonConvert.DeserializeObject<List<OrderItem>>(OrderItemsJson);

            _context.Orders.Add(order);
            _context.SaveChanges();

            decimal totalPrice = 0;
            foreach (var item in orderItems) {
                var menuItem = _context.MenuItems.FirstOrDefault(mi => mi.Id == item.MenuItemId);
                if (menuItem != null) {
                    var newOrderItem = new OrderItem {
                        OrderId = order.Id,
                        MenuItemId = menuItem.Id,
                        Quantity = item.Quantity,
                        Price = menuItem.Price
                    };
                    _context.OrderItems.Add(newOrderItem);

                    totalPrice += newOrderItem.Price * newOrderItem.Quantity;
                }
            }
            _context.SaveChanges();

            order.TotalPrice = totalPrice;

            _context.Orders.Update(order);
            _context.SaveChanges();

            ViewData["OrderSuccess"] = true;
            ViewData["MenuItems"] = _context.MenuItems.ToList();
            return View("Order", new Order());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
