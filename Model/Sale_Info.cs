//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Electronics_Store.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale_Info
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public Nullable<int> Model_Spec_FK { get; set; }
    
        public virtual Model_Specification Model_Specification { get; set; }

        public override string ToString()
        {
            return SaleDate.Value.ToString();
        }
    }
}