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
    
    public partial class UserAnnouncement
    {
        public int Id { get; set; }
        public Nullable<int> AnnouncementId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
    
        public virtual Announcement Announcement { get; set; }
        public virtual Userr Userr { get; set; }
    }
}