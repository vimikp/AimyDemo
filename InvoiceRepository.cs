using AimyInvoiceDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AimyInvoiceDemo.Repository
{
    public class InvoiceRepository : IRepository<InvoiceViewModel, InvoiceDetailsViewModel, CreateInvoiceModel>
    {
        private List<InvoiceViewModel> GetListByParents(string name)
        {
            string strings = name;
            string[] split = strings.Split(new Char[] { ' ', '\n' });
            var tempFirst = split[0];
            var tempLast = split.LastOrDefault();

            using (AimyEntities _db = new AimyEntities())
            {
                var query =
                     from i in _db.Invoices
                     join il in _db.InvoiceLines on i.Id equals il.InvoiceId
                     join b in _db.Billings on i.BillingId equals b.Id
                     join u in _db.Users on b.UserId equals u.Id
                     join c in _db.Contacts on u.ContactId equals c.Id
                     join t in _db.Terms on b.TermId equals t.Id
                     join bs in _db.Booking_Spt on il.Booking_SptId equals bs.Id
                     join bo in _db.Bookings on bs.BookingId equals bo.Id
                     join ch in _db.Children on bo.ChildId equals ch.Id
                     where u.RoleId == 9 && t.SiteId == 256 && bo.BillingId == b.Id
                     && c.FirstName.Contains(tempFirst) && c.LastName.Contains(tempLast)

                     select new InvoiceViewModel
                     {
                         Id = i.Id,
                         BillingId = i.BillingId,
                         Date = i.PeriodStart,
                         ParentName = i.Billing.User.Contact.FirstName + "" + i.Billing.User.Contact.LastName,
                         Children = i.InvoiceLines.Select(r => r.Booking_Spt.Booking.Child.Name).Distinct().ToList(),
                         DueDate = i.PeriodEnd,
                         Paid = i.AmountPaid,
                         Due = i.AmountDue,
                         Total = i.TotalAmount,
                         Status = i.Lookup.Description
                     };

                return query.ToList();
            }

        }

        private List<InvoiceViewModel> GetListByChildren(string name)
        {
            using (AimyEntities _db = new AimyEntities())
            {
                var query =
                     from i in _db.Invoices
                     join il in _db.InvoiceLines on i.Id equals il.InvoiceId
                     join b in _db.Billings on i.BillingId equals b.Id
                     join u in _db.Users on b.UserId equals u.Id
                     join t in _db.Terms on b.TermId equals t.Id
                     join bs in _db.Booking_Spt on il.Booking_SptId equals bs.Id
                     join bo in _db.Bookings on bs.BookingId equals bo.Id
                     join ch in _db.Children on bo.ChildId equals ch.Id
                     where u.RoleId == 9 && t.SiteId == 256 && bo.BillingId == b.Id && ch.Name == name

                     select new InvoiceViewModel
                     {
                         Id = i.Id,
                         BillingId = i.BillingId,
                         Date = i.PeriodStart,
                         ParentName = i.Billing.User.Contact.FirstName + "" + i.Billing.User.Contact.LastName,
                         Children = i.InvoiceLines.Select(r => r.Booking_Spt.Booking.Child.Name).Distinct().ToList(),
                         DueDate = i.PeriodEnd,
                         Paid = i.AmountPaid,
                         Due = i.AmountDue,
                         Total = i.TotalAmount,
                         Status = i.Lookup.Description
                     };

                return query.ToList();
            }
        }

        private List<InvoiceViewModel> GetListByTerms(string name)
        {
            using (AimyEntities _db = new AimyEntities())
            {
                var query =
                     from i in _db.Invoices
                     join il in _db.InvoiceLines on i.Id equals il.InvoiceId
                     join b in _db.Billings on i.BillingId equals b.Id
                     join u in _db.Users on b.UserId equals u.Id
                     join t in _db.Terms on b.TermId equals t.Id
                     join bs in _db.Booking_Spt on il.Booking_SptId equals bs.Id
                     join bo in _db.Bookings on bs.BookingId equals bo.Id
                     join ch in _db.Children on bo.ChildId equals ch.Id
                     where t.SiteId == 256 && bo.BillingId == b.Id && t.Name == name

                     select new InvoiceViewModel
                     {
                         Id = i.Id,
                         BillingId = i.BillingId,
                         Date = i.PeriodStart,
                         ParentName = i.Billing.User.Contact.FirstName + "" + i.Billing.User.Contact.LastName,
                         Children = i.InvoiceLines.Select(r => r.Booking_Spt.Booking.Child.Name).Distinct().ToList(),
                         DueDate = i.PeriodEnd,
                         Paid = i.AmountPaid,
                         Due = i.AmountDue,
                         Total = i.TotalAmount,
                         Status = i.Lookup.Description
                     };
                return query.ToList();
            }

        }

        public InvoiceDetailsViewModel GetDetail(int id)
        {
            using (AimyEntities _db = new AimyEntities())
            {
                var query = _db.Invoices.Find(id);
                return new InvoiceDetailsViewModel
                {
                    Id = id,
                    Status = query.Lookup.Description,
                    Description = query.Description,
                    Reference = query.Reference,
                    To = query.Billing.User.Contact.FirstName + " " + query.Billing.User.Contact.LastName,
                    Address = query.Billing.User.Contact.Address,
                    Total = query.TotalAmount,
                    Date = DateTime.Now,
                    DueDate = DateTime.Now,
                    AmountDue = query.AmountDue,
                    AmountPaid = query.AmountPaid

                };
            }
        }

        public string Delete(int id)
        {
            string info = "Success";
            using (AimyEntities _db = new AimyEntities())
            {
                var query = _db.Invoices.Find(id);
                if (query == null)
                {
                    // info = "Invoice Already Deleted";
                        throw new ArgumentException("Invoice not found in Invoice Table",id.ToString());
                }
                else
                {
                    query.IsActive = false;
                    query.UpdatedBy = "intern@centralstationsoftware.co.nz";
                    query.UpdatedOn = DateTime.Now;
                    query.Billing.IsActive = false;
                    query.Billing.UpdatedBy = "intern@centralstationsoftware.co.nz";
                    query.Billing.UpdatedOn = DateTime.Now;

                    var invlines = _db.InvoiceLines.Where(i => i.InvoiceId == id).ToList();
                    foreach (var line in invlines)
                    {
                        line.IsActive = false;
                        line.UpdatedBy = "intern@centralstationsoftware.co.nz";
                        line.UpdatedOn = DateTime.Now;
                    }
                    _db.SaveChanges();
                    info = "Invoice Deleted Successfully";
                }            
            }
            return info;
        }

        public List<InvoiceViewModel> GetList(string searchtype, string searchname)
        {
            if (searchtype == "Parent")
            {
                return (GetListByParents(searchname));
            }
            if (searchtype == "Child")
            {
                return (GetListByChildren(searchname));
            }
            if (searchtype == "Term")
            {
                return (GetListByTerms(searchname));
            }
            else if(string.IsNullOrEmpty(searchtype) || string.IsNullOrEmpty(searchname) || searchtype == "Select" || searchname == "Select")
            {
                using (AimyEntities _db = new AimyEntities())
                {

                      var query = (from i in _db.Invoices
                                   join b in _db.Billings on i.BillingId equals b.Id
                                   join u in _db.Users on b.UserId equals u.Id
                                   join c in _db.Contacts on u.ContactId equals c.Id
                                   join ou in _db.Org_User on u.Id equals ou.UserId
                                   join o in _db.Orgs on ou.OrgId equals o.Id
                                   orderby i.Id descending
                                   where i.IsActive == true && ou.OrgId == 256
                                  select new InvoiceViewModel
                                  {
                                      Id = i.Id,
                                      BillingId = i.BillingId,
                                      Date = i.PeriodStart,
                                      ParentName = i.Billing.User.Contact.FirstName + "" + i.Billing.User.Contact.LastName,
                                      Children = i.InvoiceLines.Select(r => r.Booking_Spt.Booking.Child.Name).Distinct().ToList(),
                                      DueDate = i.PeriodEnd,
                                      Paid = i.AmountPaid,
                                      Due = i.AmountDue,
                                      Total = i.TotalAmount,
                                      Status = i.Lookup.Description
                                  }).Take(30);

                    return query.ToList();
                }
            }
            return null;
        }

        public List<int>GetParentId(string name)
        {
            string strings = name;
            string[] split = strings.Split(new Char[] { ' ', '\n' });
            var tempFirst = split[0];
            var tempLast = split.LastOrDefault();
            using (AimyEntities _db = new AimyEntities())
            {
                var q = (from b in _db.Billings
                        join u in _db.Users on b.UserId equals u.Id
                        join c in _db.Contacts on u.ContactId equals c.Id
                        join ou in _db.Org_User on u.Id equals ou.UserId
                        join o in _db.Orgs on ou.OrgId equals o.Id
                        where u.RoleId == 9 && c.FirstName.Contains(tempFirst) && c.LastName.Contains(tempLast) && ou.OrgId == 256
                        select b.UserId);
                return q.Distinct().ToList();
                
            }
        }


        public void Create(CreateInvoiceModel model)
        {
            using (AimyEntities _db = new AimyEntities())
            {
                var parent_name = model.ParentName;
                var getUserId = GetParentId(parent_name);
                var tempUserId = getUserId.FirstOrDefault();
                var billingList = new List<Billing>();

                Billing billing;
                billing = new Billing
                {
                    UserId = tempUserId,
                    SiteId = model.SiteId,
                    OriginalCost = model.TotalAmount,
                    EstimatedCost = model.TotalAmount,
                    IsActive = model.IsActive,
                    CreatedBy = model.CreatedBy,
                    UpdatedBy = model.UpdatedBy,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };
                billingList.Add(billing);
                _db.Billings.Add(billing);
                var billingId = billing.Id;
                var invoiceDetails = new Invoice
                {
                    BillingId = billingId,
                    Email = model.Email,
                    StatusId = model.StatusId,
                    Reference = model.Reference,
                    Description = model.Description,
                    IsActive = model.IsActive,
                    DueDate = model.DueDate,
                    PeriodEnd = model.DueDate,
                    PeriodStart = model.DueDate,
                    TotalAmount = model.TotalAmount,
                    InvoiceDate = model.InvoiceDate,
                    CreatedBy = model.CreatedBy,
                    UpdatedBy = model.UpdatedBy,
                    CreatedOn = model.CreatedOn,
                    UpdatedOn = model.UpdatedOn,
                    AmountDue = model.Due

                };
                _db.Invoices.Add(invoiceDetails);
                var invoiceId = invoiceDetails.Id;
                var lines = model.InvoiceLine;
 
                if (lines != null)
                {
                    var invoiceLines = new List<InvoiceLine>();

                    foreach (var line in lines)
                    {
                        var invoiceLine = new InvoiceLine
                        {
                            InvoiceId = invoiceId,
                            Amount = line.Amount,
                            IsActive = model.IsActive,
                            CreatedBy = model.CreatedBy,
                            UpdatedBy = model.UpdatedBy,
                            CreatedOn = line.CreatedOn,
                            UpdatedOn = line.UpdatedOn,
                            Description = line.Description,
                            Quantity = line.Quantity,
                            UnitPrice = line.UnitPrice

                        };
                        invoiceLines.Add(invoiceLine);
                        invoiceDetails.InvoiceLines.Add(invoiceLine);
                    }
                }
                _db.SaveChanges();
            }
        }
    }
}




   