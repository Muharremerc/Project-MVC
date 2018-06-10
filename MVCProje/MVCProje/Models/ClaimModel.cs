using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProje.Models
{
    public class ClaimModel
    {
        public List<ClaimType> ClaimTypeModel { get; set; }
        public List<ClaimHoliday> ClaimHolidayModel { get; set; }
        public List<ClaimOther> ClaimOtherModel { get; set; }
        public List<EmployeeClaim> EmployeeClaimModel { get; set; }
    }


    public class ClaimType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ClaimHoliday
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int EmployeeClaimId { get; set; }

        public Boolean  Accept { get; set; }
    }

    public class ClaimOther
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public int EmployeeClaimId { get; set; }
    }

    public class EmployeeClaim
    {
        public int Id { get; set; }
        public int ClaimTypeId { get; set; }
        public int EmployeeId { get; set; }

    }

}