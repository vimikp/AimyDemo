using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AimyInvoiceDemo.Models
{
    public class InvoiceDetailsViewModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public string To { get; set; }
        public int ToId { get; set; }
        public string Address { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal? Total { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal? TaxableAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal? GstIncluded { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Date { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DueDate { get; set; }

        public decimal? AmountDue { get; set; }
        public decimal? AmountPaid { get; set; }


    }
   
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DueDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal? Total { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public decimal? Due { get; set; }
        public decimal? Paid { get; set; }
        public string ParentName { get; set; }
        public List<string> Children { get; set; }
        public int? BillingId { get; set; }
        public string Status { get; set; }
 
    }

  
    public class CreateInvoiceModel
    {
        public int Id { get; set; }
        public string ParentName { get; set; }
        public int TotalAmount { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Due Date Required")]
        public DateTime DueDate { get; set; }
        public string XeroInvoiceCode { get; set; }
        public string InvoiceType { get; set; }
        public int UserId { get; set; }
        public int SiteId { get; set; }
        public int OriginalCost { get; set; }
        public int EstimatedCost { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Email { get; set; }
        public int StatusId { get; set; }
        public decimal? Due { get; set; }
        public string Reference { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedOn { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDate { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime PeriodStart { get; set; }
        public IEnumerable<InvoiceLine> InvoiceLine { get; set; }

    }
}
