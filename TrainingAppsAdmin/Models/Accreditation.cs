//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingAppsAdmin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Accreditation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Accreditation()
        {
            this.AccreditationsTexts = new HashSet<AccreditationsText>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccreditationsText> AccreditationsTexts { get; set; }
    }
}
