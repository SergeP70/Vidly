using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        // Niet meer nodig, via Edit
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes, 
                Customer= new Customer()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int? id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = _context.MembershipTypes,
                Customer = (customer == null) ? new Customer() : customer
            };

            
            return View("CustomerForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes
                };
                return View("CustomerForm", viewModel);

            }

            if (customer.Id==0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDB.Birthdate = customer.Birthdate;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.Name = customer.Name;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}