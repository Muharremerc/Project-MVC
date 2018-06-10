using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjeDB;

namespace MVCProje.Models
{
    public class DetailsAndTitle
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }

    }
    public class AnnouncementsModel
    {
        public Userr UserName { get; set; }
        public List<DetailsAndTitle> DetailsAndTitle { get; set; }

    }
}