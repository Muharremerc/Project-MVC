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
    
    public partial class ClaimHoliday
    {
        public int Id { get; set; }
        public Nullable<int> EmployeeClaimId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<bool> Accept { get; set; }
    
        public virtual EmployeeClaim EmployeeClaim { get; set; }
    }
}
