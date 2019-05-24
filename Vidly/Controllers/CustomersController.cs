using System;
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
        List<Customer> Customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "John Smith" },
            new Customer { Id = 2, Name = "Jane Doe" }
        };

        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new CustomersViewModel() { Customers = Customers };
            return View(viewModel);
        }

        private Customer FindCustomerById(int id)
        {
            Customer customer = null;

            foreach (var c in Customers)
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