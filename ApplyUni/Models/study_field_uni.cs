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
    
    public partial class study_field_uni
    {
        public int id { get; set; }
        public Nullable<int> uni_id { get; set; }
        public Nullable<int> study_field_id { get; set; }
    
        public virtual study_field study_field { get; set; }
        public virtual University University { get; set; }
    }
}
