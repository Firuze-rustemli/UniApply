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
    
    public partial class Acount_value
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> acount_plan_id { get; set; }
        public string data_icon { get; set; }
    
        public virtual acount_plan acount_plan { get; set; }
    }
}