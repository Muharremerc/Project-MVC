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
    
    public partial class EmployeeShift
    {
        public int Id { get; set; }
        public Nullable<int> ShiftId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<System.DateTime> Start { get; set; }
        public Nullable<System.DateTime> Finish { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
