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
    
    public partial class UserCompany
    {
        public int Id { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Userr Userr { get; set; }
    }
}
