//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCProductAssignment
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customers_Table
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public Nullable<int> proId { get; set; }
    
        public virtual ProductTable ProductTable { get; set; }
    }
}
