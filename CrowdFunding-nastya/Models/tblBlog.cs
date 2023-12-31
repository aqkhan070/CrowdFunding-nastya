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

    public partial class tblBlog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblBlog()
        {
            this.tblBlogAttachedFiles = new HashSet<tblBlogAttachedFile>();
        }
    
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string ThumbnailImage { get; set; }
        [AllowHtml]
        public string BlogDescription { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime PublishDate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public Nullable<int> EditBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> PriorityId { get; set; }
        public Nullable<int> BlogTypeId { get; set; }
        public Nullable<int> AttachedFileId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblBlogAttachedFile> tblBlogAttachedFiles { get; set; }
        public virtual tblBlogAttachedFile tblBlogAttachedFile { get; set; }
        public virtual tblPriority tblPriority { get; set; }
        public virtual tblType tblType { get; set; }
        public virtual tblCategory tblCategory { get; set; }
    }
}
