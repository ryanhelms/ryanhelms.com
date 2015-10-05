using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryPattern_RepoInterfaces;
using Repository_Database;

namespace RepositoryPattern.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerRepository _CustomerRepo;

        public CustomerController(ICustomerRepository customerRepo)
        {
            _CustomerRepo = customerRepo;
        }

        //
        // GET: /Customer/
        public ActionResult Index()
        {
            List<Customer> model = (List<Customer>)_CustomerRepo.SelectAll();
            return View(model);
        }

        public ActionResult Insert(Customer obj)
        {
            _CustomerRepo.Insert(obj);
            _CustomerRepo.Save();
            return View();
        }

        public ActionResult Edit(string id)
        {
            Customer existing = _CustomerRepo.SelectByID(id);
            return View(existing);
        }


        public ActionResult ConfirmDelete(string id)
        {
            Customer existing = _CustomerRepo.SelectByID(id);
            return View(existing);
        }

        public ActionResult Delete(string id)
        {
            _CustomerRepo.Delete(id);
            _CustomerRepo.Save();
            return View();
        }

    }
}