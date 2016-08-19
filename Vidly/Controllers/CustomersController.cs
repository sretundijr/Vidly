﻿using System.Data.Entity;
using System.Linq;
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

        //private List<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { Id = 1, Name = "Steve" },
        //        new Customer { Id = 2, Name = "Christina" }
        //    };
        //}

        public ActionResult New()
        {
            var membershipType = _context.MembershipType.ToList();

            var viewModel = new CustomerFormViewModel
            {
                //new customer created to eliminate the id validation error
                Customer = new Customer(),
                MembershipTypes = membershipType
            };

            return View("CustomerForm", viewModel);
        }

        //this method posts the form to server
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //used with validation
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0)
            {
                _context.Customer.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customer.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomersViewModel
            {
                SelectedCustomer = customer
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            
            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };

            //mvc will look for an edit action unless overriden with new
            return View("CustomerForm", viewModel);
        }
    }
}