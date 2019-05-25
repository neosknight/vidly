﻿using System;
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

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            
            var viewModel = new CustomersViewModel() { Customers = customers };
            return View(viewModel);
        }

        private Customer FindCustomerById(int id)
        {
            Customer customer = null;

            foreach (var c in _context.Customers)
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