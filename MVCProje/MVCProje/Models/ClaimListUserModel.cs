using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProje.Models
{

        public class ClaimListUserModel
        {
            public List<EmployeeClaimHolidayList> HolidayClaim { get; set; }
            public List<EmployeeClaimOtherList> OtherClaim { get; set; }

        }
        public class EmployeeClaimOtherList
        {
            public string Name { get; set; }
            public string Details { get; set; }
            public Boolean Check { get; set; }


        }

        public class EmployeeClaimHolidayList
        {
        public int Id { get; set; }
        public string Name { get; set; }
            public DateTime Start { get; set; }

            public DateTime Finish { get; set; }

            public Boolean Check { get; set; }


        }
    
    }
