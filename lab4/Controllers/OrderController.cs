using lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace lab4.Controllers
{
    public class OrderController : Controller
    {
        OrderContext _context;
        public OrderController(OrderContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Orders> orders = _context.Orders.Include(prop => prop.Price).Include(prop => prop.Number);
            return View(orders);
        }

        public IActionResult Create()
        {
            ViewBag.Users = new SelectList(_context.Users, "Id", "Name");
            ViewBag.Services = new SelectList(_context.Services, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Orders order)
        {
            if (order.UserID != 0 && order.ServiceID != 0)
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Persons = new SelectList(_context.Users, "Id", "Name");
            ViewBag.Books = new SelectList(_context.Services, "Id", "Name");

            return View(order);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _context.Orders.Include(p => p.Price).Include(p => p.Number).First(p => p.ID == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteP(int? id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
