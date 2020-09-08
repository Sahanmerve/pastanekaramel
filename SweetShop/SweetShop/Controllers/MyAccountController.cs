using BLL;
using Entity;
using Entity.MyViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetShop.Controllers
{
    public class MyAccountController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: MyAccount
        public ActionResult Index()
        {
            string uid = User.Identity.GetUserId();
            Customer customer = _uw.db.Users.Find(uid);
            MyAccountViewModel model = new MyAccountViewModel();
            model.Email = customer.Email;
            model.PhoneNumber = customer.PhoneNumber;

            return View(customer);
        }
        [HttpPost]
        public ActionResult Index(Customer c)
        {
            UserStore<Customer> store = new UserStore<Customer>(UnitOfWork.Create());
            UserManager<Customer> manager = new UserManager<Customer>(store);

            string uid = User.Identity.GetUserId();
            Customer customer = manager.FindById(uid);
            customer.Email = c.Email;
            customer.PhoneNumber = c.PhoneNumber;
            customer.NameSurname = c.NameSurname;
            customer.Gender = c.Gender;
            customer.Adress = c.Adress;
            manager.Update(customer);
            return View(c);
        }
    }
}