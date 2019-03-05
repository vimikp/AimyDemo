using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AimyInvoiceDemo.Models;



namespace AimyInvoiceDemo.Controllers
{
    public class InvoiceController : Controller
    {

        // GET: Invoice
        public ActionResult Index(string _term = null, string _parent = null, string _child = null)
        {

            using (AimyEntities _db = new AimyEntities())
            {
                var query = _db.Invoices
                                          .Select(y => new InvoiceViewModel
                                          {
                                              Id = y.Id,
                                              BillingId = y.BillingId,
                                              Date = y.PeriodStart,
                                              ParentName = y.Billing.User.Contact.FirstName + "" + y.Billing.User.Contact.LastName,
                                              Children = y.InvoiceLines.Select(r => r.Booking_Spt.Booking.Child.Name).Distinct().ToList(),
                                              DueDate = y.PeriodEnd,
                                              Paid = y.AmountPaid,
                                              Due = y.AmountDue,
                                              Total = y.TotalAmount,
                                              EmailStatus = y.EmailStatus
                                          })
                                           .Take(10);
                return View(query.ToList());
            }
        }

        public JsonResult GetInvoiceList(string term, string type, string search)
        {
            if (!String.IsNullOrEmpty(term))
            {

            }
            var transactionOptions = new System.Transactions.TransactionOptions();

            //set it to read uncommited
            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;

            //create the transaction scope, passing our options in


            using (AimyEntities _db = new AimyEntities())
            {

                //using (var transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, transactionOptions))
                //{

                //var query = from inv1 in db.Invoices  where (inv1.Id < 10) select
                //.Where(i => i.Billing.Term.Name.Contains("Term"))

                var query = _db.Invoices
                                          .Where(i => i.Billing.Term.SiteId == 256)
                                          .Select(y => new InvoiceViewModel
                                          {
                                              Id = y.Id,
                                              BillingId = y.BillingId,
                                              Date = y.PeriodStart,
                                              ParentName = y.Billing.User.Contact.FirstName + "" + y.Billing.User.Contact.LastName,
                                              Children = y.InvoiceLines.Select(r => r.Booking_Spt.Booking.Child.Name).Distinct().ToList(),
                                              DueDate = y.PeriodEnd,
                                              Paid = y.AmountPaid,
                                              Due = y.AmountDue,
                                              Total = y.TotalAmount,
                                              EmailStatus = y.EmailStatus
                                          })
                                           .Take(10);



                //foreach(var q in query)
                //{
                //    Console.WriteLine(q.Status);
                //}

                return Json(query.ToList(), JsonRequestBehavior.AllowGet);

                //var typeofq = query.GetType();
                //var strq = query.ToString();
                //transactionScope.Complete();
            }

            // return View();
            // return View(query.ToList());
            //}
        }
        public ActionResult GetParents(string name)
        {
            
            //var tokens = name.Split(" ");
            using (AimyEntities _db = new AimyEntities())
            {

                var query = _db.Invoices.Where(i => i.Billing.User.RoleId == 9 && i.Billing.Term.SiteId == 256);
            }
            return View();
        }

        public JsonResult GetChildren(string name)
        {
            using (AimyEntities _db = new AimyEntities())
            {

                // var query = _db.InvoiceLines.Where(i => i.Booking_Spt.Booking.Child.Name == name);

                var q =
                     from i in _db.Invoices
                     join il in _db.InvoiceLines on i.Id equals il.InvoiceId
                     join b in _db.Billings on i.BillingId equals b.Id
                     join u in _db.Users on b.UserId equals u.Id
                     join t in _db.Terms on b.TermId equals t.Id
                     join bs in _db.Booking_Spt on il.Booking_SptId equals bs.Id
                     join bo in _db.Bookings on bs.BookingId equals bo.Id
                     join ch in _db.Children on bo.ChildId equals ch.Id
                     where u.RoleId == 9 && t.SiteId == 256 && bo.BillingId == b.Id && ch.Name == "Bruce Wayn"
                     select new { i.Id, i.BillingId, ch.Name };

                return Json(q.ToList(), JsonRequestBehavior.AllowGet);


            }
          //  return View();

        }
        [HttpGet]
        public JsonResult GetTerms(string name)
        {
            using (AimyEntities _db = new AimyEntities())
            {

                var query = _db.Terms.Where(t => t.IsActive && t.SiteId == 256 && t.Name.Contains(name));


                return Json(query.ToList(), JsonRequestBehavior.AllowGet);
            }

        }

        public IList<string> GetParentOptions()
        {
            AimyEntities _db = new AimyEntities();

            var query = from i in _db.Invoices
                        join b in _db.Billings on i.BillingId equals b.Id
                        join u in _db.Users on b.UserId equals u.Id
                        join c in _db.Contacts on u.ContactId equals c.Id
                        join t in _db.Terms on b.TermId equals t.Id
                        where u.RoleId == 9 && t.SiteId == 256
                        select c.FirstName + " " + c.LastName;

            var q = query.Distinct();
            return q.ToList();
        }
        public IList<string> GetChildrenOptions()
        {
            AimyEntities _db = new AimyEntities();
            var q =
                     from i in _db.Invoices
                     join il in _db.InvoiceLines on i.Id equals il.InvoiceId
                     join b in _db.Billings on i.BillingId equals b.Id
                     join u in _db.Users on b.UserId equals u.Id
                     join t in _db.Terms on b.TermId equals t.Id
                     join bs in _db.Booking_Spt on il.Booking_SptId equals bs.Id
                     join bo in _db.Bookings on bs.BookingId equals bo.Id
                     join ch in _db.Children on bo.ChildId equals ch.Id
                     where u.RoleId == 9 && t.SiteId == 256 && bo.BillingId == b.Id
                     select ch.Name;
            var query = q.Distinct();
            return query.ToList();
            // return new List<string>{"3", "4"};
        }
        public IList<string> GetTermOptions()
        {
            AimyEntities _db = new AimyEntities();
            var query = _db.Terms.Where(t => t.SiteId == 256)
                    .Select(t => t.Name);
            return query.ToList();
            //return new List<string>{"5", "6"};
        }
        public ActionResult getselectOPtions(int id)
        {
            if (id == 1)
                return Json(GetParentOptions(), JsonRequestBehavior.AllowGet);
            if (id == 2)
                return Json(GetChildrenOptions(), JsonRequestBehavior.AllowGet);
            if (id == 3)
                return Json(GetTermOptions(), JsonRequestBehavior.AllowGet);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var model = new InvoiceDetailsViewModel();
            using (AimyEntities _db = new AimyEntities())
            {
                var query = _db.Invoices.Find(id);

                var mod = new InvoiceDetailsViewModel
                {
                    Id = id,
                    Status = query.Lookup.Description,
                    Description = query.Description,
                    Reference = query.Reference,
                    To = query.Billing.User.Contact.FirstName + " " + query.Billing.User.Contact.LastName,
                    // ToId = 
                    Address = query.Billing.User.Contact.Address,
                    Total = query.TotalAmount,
                    //TaxableAmount = 
                    //GstIncluded = 
                    Date = DateTime.Now,
                    DueDate = DateTime.Now,
                    AmountDue = query.AmountDue,
                    AmountPaid = query.AmountPaid

                };

                model = mod;
            }
            return View(model);
        }
        public ActionResult create()
        {

            return View();
        }

        [HttpGet]
        public JsonResult postNewInvocie(string id = null)
        {
            var q1 = "abc";
            return Json(q1.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult postNewInvoice(CreateInvoiceModel invoice)
        {
            using (AimyEntities _db = new AimyEntities())
            {
                var billingsSaved = new List<Billing>();

                Billing billing;

                billing = new Billing
                {
                    UserId = invoice.UserId,
                    SiteId = invoice.SiteId,
                    OriginalCost = invoice.TotalAmount,
                    EstimatedCost = invoice.TotalAmount,
                    IsActive = invoice.IsActive,
                    CreatedBy = invoice.CreatedBy,
                    UpdatedBy = invoice.UpdatedBy,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now

                };

                billingsSaved.Add(billing);
                _db.Billings.Add(billing);
                var billingId = billing.Id;

                var invoiceDetails = new Invoice
                {

                    BillingId = billingId,
                    Email = invoice.Email,
                    StatusId = invoice.StatusId,
                    Reference = invoice.ParentName,
                    Description = invoice.Description,
                    DueDate = invoice.DueDate,
                    PeriodEnd = invoice.DueDate,
                    PeriodStart = invoice.DueDate,
                    TotalAmount = invoice.TotalAmount,
                    InvoiceDate = DateTime.Now, //test
                    CreatedBy = invoice.CreatedBy,
                    UpdatedBy = invoice.UpdatedBy,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now

                };
                _db.Invoices.Add(invoiceDetails);
                _db.SaveChanges();
            }
            return Json(q.ToList(), JsonRequestBehavior.AllowGet);

        }
    }
}

  
