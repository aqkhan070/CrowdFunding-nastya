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
    
    public partial class tblMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMenu()
        {
            this.tblAccessLevels = new HashSet<tblAccessLevel>();
        }
    
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public Nullable<bool> isParent { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string FontAwesome { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> EditBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public string ElementId { get; set; }
        public Nullable<int> OrderBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccessLevel> tblAccessLevels { get; set; }
    }
}
