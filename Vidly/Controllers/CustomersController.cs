using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            
            return View(customers);
        }

        // GET: Customers/Details/1
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);


        }

        private IEnumerable<Customer> GetCustomers()
        {
            //return null;
            return new List<Customer>
            {
                new Customer { Id = 0, Name= "Serge Pille"},
                new Customer { Id = 1, Name= "Emilie Pille"},
                new Customer { Id = 2, Name= "Arthur Pille"},
                new Customer { Id = 3, Name= "Annelies Nys"},
                new Customer { Id = 4, Name= "Peter Verdonck"},
                new Customer { Id = 5, Name= "Bart Pattyn"},

            };

        }
    }
}