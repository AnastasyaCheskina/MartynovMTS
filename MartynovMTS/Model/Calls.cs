//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MartynovMTS.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calls
    {
        public int IdCall { get; set; }
        public int IdClient { get; set; }
        public int IdServices { get; set; }
        public System.DateTime DateTimeCall { get; set; }
        public int DurationCallInSec { get; set; }
        public int IdStatus { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Services Services { get; set; }
        public virtual Statuses Statuses { get; set; }
    }
}
