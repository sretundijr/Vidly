using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Steve" },
                new Customer { Id = 2, Name = "Christina" }
            };
        }

        // GET: Customers
        public ActionResult Index()
        {


            var viewModel = new CustomersViewModel
            {
                Customers = GetCustomers()
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            

            foreach (var customer in GetCustomers())
            {
                if (customer.Id == id)
                {
                    var selectedCustomer = new CustomersViewModel
                    {
                        SelectedCustomer = customer
                    };

                    return View(selectedCustomer);
                }
            }

            return RedirectToAction("Index");
        }
    }
}