using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            
            var viewModel = new CustomersViewModel() { Customers = customers };
            return View(viewModel);
        }

        private Customer FindCustomerById(int id)
        {
            Customer customer = null;
            var customers = _context.Customers.Include(c => c.MembershipType);

            foreach (var c in customers)
            {
                if (c.Id == id)
                    customer = c;
            }

            return customer;
        }

        public ActionResult Details(int id)
        {
            var customer = FindCustomerById(id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }
    }
}