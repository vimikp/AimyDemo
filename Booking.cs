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
    
    public partial class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            this.Booking_Spt = new HashSet<Booking_Spt>();
        }
    
        public int Id { get; set; }
        public int BillingId { get; set; }
        public Nullable<int> ItemCodeId { get; set; }
        public int GuardianId { get; set; }
        public int ProgramCategoryId { get; set; }
        public int SiteId { get; set; }
        public int ChildId { get; set; }
        public Nullable<int> TrackingCatOptId { get; set; }
        public Nullable<int> BookingTypeId { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> WhenBooked { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public byte[] Version { get; set; }
        public Nullable<int> EnrolmentId { get; set; }
    
        public virtual Billing Billing { get; set; }
        public virtual Child Child { get; set; }
        public virtual Enrolment Enrolment { get; set; }
        public virtual Lookup Lookup { get; set; }
        public virtual Org Org { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking_Spt> Booking_Spt { get; set; }
        public virtual User User { get; set; }
    }
}
