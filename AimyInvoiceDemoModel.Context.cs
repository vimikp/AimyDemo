﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AimyEntities : DbContext
    {
        public AimyEntities()
            : base("name=AimyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ArchivedInvoiceAttendance> ArchivedInvoiceAttendances { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Booking_Spt> Booking_Spt { get; set; }
        public virtual DbSet<BookingAudit> BookingAudits { get; set; }
        public virtual DbSet<BookingDefinition> BookingDefinitions { get; set; }
        public virtual DbSet<BookingHistoryLookup> BookingHistoryLookups { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Child_Condition> Child_Condition { get; set; }
        public virtual DbSet<Child_Contact> Child_Contact { get; set; }
        public virtual DbSet<ChildDiscount> ChildDiscounts { get; set; }
        public virtual DbSet<ChildNote> ChildNotes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactGroup> ContactGroups { get; set; }
        public virtual DbSet<CSS_BillingPlan> CSS_BillingPlan { get; set; }
        public virtual DbSet<CSS_BillingPlanDetails> CSS_BillingPlanDetails { get; set; }
        public virtual DbSet<CSS_BillingRule> CSS_BillingRule { get; set; }
        public virtual DbSet<CSS_Invoice> CSS_Invoice { get; set; }
        public virtual DbSet<CSS_InvoiceLine> CSS_InvoiceLine { get; set; }
        public virtual DbSet<CSS_Lookup> CSS_Lookup { get; set; }
        public virtual DbSet<CssInvoice> CssInvoices { get; set; }
        public virtual DbSet<CssInvoiceLine> CssInvoiceLines { get; set; }
        public virtual DbSet<CssLookup> CssLookups { get; set; }
        public virtual DbSet<DefaultBillingDiscount> DefaultBillingDiscounts { get; set; }
        public virtual DbSet<DefaultTerm> DefaultTerms { get; set; }
        public virtual DbSet<DeletingInvoiceQueue> DeletingInvoiceQueues { get; set; }
        public virtual DbSet<DynamicField> DynamicFields { get; set; }
        public virtual DbSet<DynamicFieldValue> DynamicFieldValues { get; set; }
        public virtual DbSet<Enrolment> Enrolments { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<Guardian_Child> Guardian_Child { get; set; }
        public virtual DbSet<HeadCount> HeadCounts { get; set; }
        public virtual DbSet<IdentityRole> IdentityRoles { get; set; }
        public virtual DbSet<IdentityUser> IdentityUsers { get; set; }
        public virtual DbSet<IdentityUserClaim> IdentityUserClaims { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceExtraCharge> InvoiceExtraCharges { get; set; }
        public virtual DbSet<InvoiceHistory> InvoiceHistories { get; set; }
        public virtual DbSet<InvoiceHistoryLine> InvoiceHistoryLines { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
        public virtual DbSet<InvoicePayment> InvoicePayments { get; set; }
        public virtual DbSet<InvoiceSettingAudit> InvoiceSettingAudits { get; set; }
        public virtual DbSet<InvoiceTransactionAudit> InvoiceTransactionAudits { get; set; }
        public virtual DbSet<LocalPayment> LocalPayments { get; set; }
        public virtual DbSet<LongTermAvailability> LongTermAvailabilities { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Notification_User> Notification_User { get; set; }
        public virtual DbSet<Org> Orgs { get; set; }
        public virtual DbSet<Org_Child> Org_Child { get; set; }
        public virtual DbSet<Org_Contact> Org_Contact { get; set; }
        public virtual DbSet<Org_TermsConditions> Org_TermsConditions { get; set; }
        public virtual DbSet<Org_User> Org_User { get; set; }
        public virtual DbSet<OrgAcceptedTermsAndCondition> OrgAcceptedTermsAndConditions { get; set; }
        public virtual DbSet<OrgBillingPlan> OrgBillingPlans { get; set; }
        public virtual DbSet<OrgDesign> OrgDesigns { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentBatch> PaymentBatches { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<QuickBooksInvoiceQueue> QuickBooksInvoiceQueues { get; set; }
        public virtual DbSet<RooParent> RooParents { get; set; }
        public virtual DbSet<RooPayment> RooPayments { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Site_PaymentOption> Site_PaymentOption { get; set; }
        public virtual DbSet<Site_Program_Term> Site_Program_Term { get; set; }
        public virtual DbSet<SiteDPSDetail> SiteDPSDetails { get; set; }
        public virtual DbSet<SiteGroup> SiteGroups { get; set; }
        public virtual DbSet<SiteGroup_Booking_Spt> SiteGroup_Booking_Spt { get; set; }
        public virtual DbSet<Term> Terms { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<User_Child> User_Child { get; set; }
        public virtual DbSet<User_Contact> User_Contact { get; set; }
        public virtual DbSet<XeroContact> XeroContacts { get; set; }
        public virtual DbSet<XeroCSSInvoiceQueue> XeroCSSInvoiceQueues { get; set; }
        public virtual DbSet<XeroCSSInvoiceUpdateQueue> XeroCSSInvoiceUpdateQueues { get; set; }
        public virtual DbSet<XeroEditInvoiceQueue> XeroEditInvoiceQueues { get; set; }
        public virtual DbSet<XeroInvErrorQueue> XeroInvErrorQueues { get; set; }
        public virtual DbSet<XeroInvoice> XeroInvoices { get; set; }
        public virtual DbSet<XeroInvoiceLine> XeroInvoiceLines { get; set; }
        public virtual DbSet<XeroInvoiceQueue> XeroInvoiceQueues { get; set; }
        public virtual DbSet<Delete_AttendanceData> Delete_AttendanceData { get; set; }
        public virtual DbSet<Query> Queries { get; set; }
    }
}
