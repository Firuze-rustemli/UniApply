//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplyUni.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class acount_plan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public acount_plan()
        {
            this.Acount_value = new HashSet<Acount_value>();
        }
    
        public int id { get; set; }
        public string title { get; set; }
        public Nullable<decimal> price { get; set; }
        public string descriptin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acount_value> Acount_value { get; set; }
    }
}
