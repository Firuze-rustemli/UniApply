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
    
    public partial class rank_to_rait
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rank_to_rait()
        {
            this.University = new HashSet<University>();
        }
    
        public int id { get; set; }
        public Nullable<int> raiting_id { get; set; }
        public Nullable<int> ranking_id { get; set; }
    
        public virtual ranking_rating ranking_rating { get; set; }
        public virtual Uni_ranking Uni_ranking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<University> University { get; set; }
    }
}