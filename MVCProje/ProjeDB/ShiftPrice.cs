//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjeDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShiftPrice
    {
        public int Id { get; set; }
        public Nullable<int> ShiftId { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<bool> Active { get; set; }
    
        public virtual Shift Shift { get; set; }
    }
}