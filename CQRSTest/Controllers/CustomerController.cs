using System;
using System.Linq;
using System.Web.Mvc;
using CQRSTest.Models;

namespace CQRSTest.Controllers
{
    using CQRSTest.CQRS;
    using CQRSTest.CrossCutting.DomainEvents;
    using CQRSTest.Models.WriteModel;

    public class CustomerController
        :
        Controller,
        IPublish<UserWantsToCreateCustomer>,
        IPublish<UserWantsToChangeCustomerName>,
        IPublish<UserWantsToRemoveCustomer>
    {
        private CustomerSummaryContext db = new CustomerSummaryContext();

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View(db.CustomerSummaries.ToList());
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(Guid id)
        {
            var customersummary = db.CustomerSummaries.Find(id);
            if (customersummary == null)
            {
                return HttpNotFound();
            }
            return View(customersummary);
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(UserWantsToCreateCustomer userWantsToCreateCustomer)
        {
            if (ModelState.IsValid)
            {
                this.Publish(userWantsToCreateCustomer);
                return RedirectToAction("Index");
            }

            return View(userWantsToCreateCustomer);
        }

        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(Guid id)
        {
            var customersummary = db.CustomerSummaries.Find(id);
            if (customersummary == null)
            {
                return HttpNotFound();
            }

            return View(customersummary);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(UserWantsToChangeCustomerName userWantsToChangeCustomerName)
        {
            if (ModelState.IsValid)
            {
                this.Publish(userWantsToChangeCustomerName);
                return RedirectToAction("Index");
            }

            return View(userWantsToChangeCustomerName);
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(Guid id)
        {
            var customersummary = db.CustomerSummaries.Find(id);
            if (customersummary == null)
            {
                return HttpNotFound();
            }
            return View(customersummary);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            this.Publish(new UserWantsToRemoveCustomer { CustomerId = id });
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}