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
    using System.ComponentModel;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Payment = new HashSet<Payment>();
        }
    
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public Nullable<int> user_country_id { get; set; }
        public Nullable<int> study_field_id { get; set; }
        public Nullable<int> user_study_cont_id { get; set; }
        public Nullable<int> degree_level_id { get; set; }
        public Nullable<int> finance_plan_id { get; set; }
        public Nullable<int> budget_id { get; set; }
        public Nullable<int> citizinship_id { get; set; }
        public string adress { get; set; }
        public string postcode { get; set; }
    
        public virtual Bugdet Bugdet { get; set; }
        public virtual citizinship citizinship { get; set; }
        public virtual Country Country { get; set; }
        public virtual Country Country1 { get; set; }
        public virtual degree_level degree_level { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual study_field study_field { get; set; }
        public virtual user_finance_plan user_finance_plan { get; set; }
    }
}
