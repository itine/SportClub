//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainer()
        {
            this.Trainings = new HashSet<Training>();
        }
    
        public int TrainerId { get; set; }
        public string TrainerFIO { get; set; }
        public Nullable<System.DateTime> DateBirth { get; set; }
        public string Achievements { get; set; }
        public int SportsType { get; set; }
    
        public virtual Sport Sport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Training> Trainings { get; set; }
    }
}
