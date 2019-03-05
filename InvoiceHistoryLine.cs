//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AimyInvoiceDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoiceHistoryLine
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public Nullable<int> Booking_SptId { get; set; }
        public Nullable<int> ItemCodeId { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> TrackingCodeId { get; set; }
        public string LineType { get; set; }
    
        public virtual Booking_Spt Booking_Spt { get; set; }
        public virtual InvoiceHistory InvoiceHistory { get; set; }
    }
}
