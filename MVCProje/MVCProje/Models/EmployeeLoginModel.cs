using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProje.Models
{
    public class EmployeeLoginModel
    {
        public int Id { get; set; }
        public string Employeename { get; set; }
        public List<Ds> SNameDate { get; set; }

    }

    public class Ds
    {

        public DateTime Date { get; set; }
        public string SName { get; set; }

    }



}