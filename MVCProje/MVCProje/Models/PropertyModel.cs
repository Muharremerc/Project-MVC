using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProje.Models
{
    public class PropertyModel
    {
        public List<AnnouncementType> AnnList { get; set; }
        public List<ShiftType> ShiftList { get; set; }
    }
    public class ShiftType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public string CardName { get; set; }


    }

    public class AnnouncementType
    {

        public int Id    { get; set; }
         public string Name { get; set; }      
}
}