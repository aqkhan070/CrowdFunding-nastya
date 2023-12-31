//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrowdFunding_nastya.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public partial class tblProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProject()
        {
            this.tblTransactions = new HashSet<tblTransaction>();
        }
    
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Located { get; set; }
        public string PostCode { get; set; }
        public string FundraisingFor { get; set; }
        public string Phone { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string story { get; set; }
        public string Goal { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public Nullable<double> Value { get; set; }
        public Nullable<double> RaisedAmount { get; set; }
        public string Skills { get; set; }
        public string VerificationCodeTo { get; set; }
        public Nullable<int> PriorityId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> EditBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public bool isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    
        public virtual tblPriority tblPriority { get; set; }
        public virtual tblStatu tblStatu { get; set; }
        public virtual tblType tblType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTransaction> tblTransactions { get; set; }
        public virtual tblCategory tblCategory { get; set; }
    }
}
