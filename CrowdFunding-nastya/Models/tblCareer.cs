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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class tblCareer
    {
        public int CareerId { get; set; }
        public string CareerTitle { get; set; }
        public string CareerThumbnailImage { get; set; }
        public string CareerDescription { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public Nullable<int> EditBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> PriorityId { get; set; }
        public Nullable<int> BlogTypeId { get; set; }

        public virtual tblBlogCategory tblBlogCategory { get; set; }
        public virtual tblBlogPriority tblBlogPriority { get; set; }
        public virtual tblBlogType tblBlogType { get; set; }
    }
}
