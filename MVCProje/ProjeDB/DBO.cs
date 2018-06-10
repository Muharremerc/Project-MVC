using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeDB
{
    public class DBO
    {
        private static DBO ProjeDB;

        private DBO()
        {
        }

        public static DBO GetInstance()
        {
            if (ProjeDB == null)
            {
                DBO ProjeDB = new DBO();
                return ProjeDB;
            }
            else
            {
                return ProjeDB;
            }
        }

        public Employee AddEmpOrUpda(Employee _emp)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    if (_emp.Id == 0)
                    {
                        var emp = new Employee();
                        emp.Name = _emp.Name;
                        emp.Surname = _emp.Surname;
                        emp.UserName = _emp.UserName;
                        emp.Password = _emp.Password;
                        emp.CardNumber = _emp.CardNumber;
                        db.Employees.Add(emp);
                        db.SaveChanges();
                        return emp;
                    }
                    else
                    {
                        var emp = db.Employees.FirstOrDefault(z => z.Id == _emp.Id);
                        emp.Name = _emp.Name;
                        emp.Surname = _emp.Surname;
                        emp.UserName = _emp.UserName;
                        emp.Password = _emp.Password;
                        emp.CardNumber = _emp.CardNumber;
                        db.SaveChanges();
                        return emp;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Employee getEmployee(int _id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var st = db.Employees.FirstOrDefault(z => z.Id == _id);
                    return st;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int delEmpClaim(int id)
        {
            try
            {
                using (var db= new ProjeEntities())
                {
                    var ec = db.EmployeeClaims.Where(x => x.EmployeeId == id).ToList();
                    foreach (var item in ec)
                    {
                        if(item.ClaimTypeId==1)
                        {
                            var a = db.ClaimOthers.Where(x => x.EmployeeClaimId == item.Id).FirstOrDefault();
                            db.ClaimOthers.Remove(a);
                        }
                        if(item.ClaimType.Id== 2)
                        {
                            var a = db.ClaimHolidays.Where(x => x.EmployeeClaimId == item.Id).FirstOrDefault();
                            db.ClaimHolidays.Remove(a);

                        }
                        db.EmployeeClaims.Remove(item);
                       
                    }
                    var numberofdel = db.SaveChanges();
                    return numberofdel;

                }
            }
            catch (Exception exe)
            {

                throw;
            }
        }

        public int delEmpShift(int id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var es = db.EmployeeShifts.Where(x => x.EmployeeId == id).ToList();
                    foreach (var item in es)
                    {
                        db.EmployeeShifts.Remove(item);
                    }
                    var numberofdel = db.SaveChanges();
                    return numberofdel;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int delEmpLog(int id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var el = db.LoginEmployees.Where(x => x.EmployeeId == id).ToList();
                    foreach (var item in el)
                    {
                        db.LoginEmployees.Remove(item);
                    }
                    var numberofdel = db.SaveChanges();
                    return numberofdel;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee delEmployee(int id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var emp = db.Employees.Where(x => x.Id == id).FirstOrDefault();
                    if(emp != null)
                    {
                        delEmpClaim(id);
                        delEmpShift(id);
                        delEmpLog(id);
                        db.Employees.Remove(emp);
                        db.SaveChanges();
                      
                    }

                    return emp;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public ClaimHoliday addHoliday(int claimId, string _start, string _finish)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    ClaimHoliday ch = new ClaimHoliday();
                    ch.EmployeeClaimId = claimId;
                    ch.FinishDate = Convert.ToDateTime(_finish);
                    ch.StartDate = Convert.ToDateTime(_start);
                    ch.Accept = false;
                    db.ClaimHolidays.Add(ch);

                    db.SaveChanges();
                    return ch;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ClaimHoliday getCholidaybyId(int _id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var ch = db.ClaimHolidays.FirstOrDefault(x => x.EmployeeClaimId == _id);
                    return ch;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ClaimOther getCOtherbyId(int _id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var ch = db.ClaimOthers.FirstOrDefault(x => x.EmployeeClaimId == _id);
                    return ch;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public ClaimOther addClaimOther(string details, int claimId)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    ClaimOther co = new ClaimOther();
                    co.Details = details;
                    co.EmployeeClaimId = claimId;
                    db.ClaimOthers.Add(co);
                    db.SaveChanges();
                    return co;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public EmployeeClaim addEmpClaim(int typeId, int empId)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    EmployeeClaim ec = new EmployeeClaim();
                    ec.EmployeeId = empId;
                    ec.ClaimTypeId = typeId;
                    
                    db.EmployeeClaims.Add(ec);
                    db.SaveChanges();
                    return ec;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Shift AddShift(string Name,string cardname)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    Shift s = new Shift();
                    s.Name = Name;
                    s.ShiftNumber = cardname;
                    db.Shifts.Add(s);
                    db.SaveChanges();
                    return s;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ShiftPrice AddShiftPrice(int id, string price)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    ShiftPrice sp = new ShiftPrice();
                    sp.ShiftId = id;
                    sp.Price = Convert.ToInt16(price);
                    db.ShiftPrices.Add(sp);
                    db.SaveChanges();
                    return sp;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public CompanyShift addCompanyShift(int compnayid, int shiftid)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    CompanyShift cs = new CompanyShift();
                    cs.ShiftId = shiftid;
                    cs.CompanyId = compnayid;
                    db.CompanyShifts.Add(cs);
                    db.SaveChanges();
                    return cs;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public Employee AddNewEmployee(string name, string surname, string username, string password, string cardId, int companyid)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    Employee emp = new Employee();
                    emp.Name = name;
                    emp.Surname = surname;
                    emp.UserName = username;
                    emp.Password = password;
                    emp.CompanyId = companyid;
                    emp.CardNumber = cardId;
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return emp;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Employee UpdaEmp(Employee _emp)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var tempemp = db.Employees.Where(x => x.Id == _emp.Id).FirstOrDefault();
                    tempemp.Name = _emp.Name;
                    tempemp.Surname = _emp.Surname;
                    tempemp.Password = _emp.Password;
                    tempemp.UserName = _emp.UserName;
                    tempemp.CompanyId = _emp.CompanyId;
                    tempemp.CardNumber = _emp.CardNumber;

                    db.SaveChanges();
                    return tempemp;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Announcement AddAnn(string name)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    Announcement a = new Announcement();
                    a.Name = name;
                    db.Announcements.Add(a);
                    db.SaveChanges();
                    return a;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public CompanyAnnouncement AddAnnCompany(int idAnn, int companyid)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    CompanyAnnouncement ca = new CompanyAnnouncement();
                    ca.AnnouncementId = idAnn;
                    ca.CompanyId = companyid;
                    db.CompanyAnnouncements.Add(ca);
                    db.SaveChanges();
                    return ca;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public ShiftPrice getPrice(int id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var s = db.ShiftPrices.Where(x => x.ShiftId == id).FirstOrDefault();

                    return s;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DsDbo> getEmpLogin(int id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    List<DsDbo> dss = new List<DsDbo>();
                    
                    
                    var list = db.LoginEmployees.Where(x => x.EmployeeId == id).ToList();
                   
                    foreach (var item in list)
                    {
                        DsDbo nesne = new DsDbo();
                        nesne.Date = Convert.ToDateTime(item.Date);
                        nesne.SName = item.Shiftname;
                        dss.Add(nesne);

                    }
                   
                    return dss;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public string returnshiftcardname()
        {
            try
            {
                RFID.NFCReader n = new RFID.NFCReader();
                n.Connect();

                var a = n.Watch();
                n.Disconnect();

                return a;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public class EmployeeLoginModel
    {
        public int Id { get; set; }
        public string Employeename { get; set; }
        public List<DsDbo> SNameDate { get; set; }

    }
        public class DsDbo
        {
            public DateTime Date { get; set; }
            public string SName { get; set; }

        }


        public Company AddCompamy(string cname)
        {
            try
            {
                using (var db =new ProjeEntities())
                {
                    Company c = new Company();
                    c.Name = cname;
                    db.Companies.Add(c);
                    db.SaveChanges();
                    return c;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Userr AddUser(string name, string surname, string username, string password)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    Userr u = new Userr();
                    u.Name = name;
                    u.Surname = surname;
                    u.UserName = username;
                    u.Password = password;
                    db.Userrs.Add(u);
                    db.SaveChanges();
                    return u;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int delUserAnn(int id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {

                    var ua = db.UserAnnouncements.Where(z => z.AnnouncementId == id).ToList();
                    foreach (var item in ua)
                    {
                        db.UserAnnouncements.Remove(item);
                        
                    }
                    var number = db.SaveChanges();
                    return number;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int delAnnCom(int id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {

                    var ca = db.CompanyAnnouncements.Where(z => z.AnnouncementId == id).FirstOrDefault();
                    
                        db.CompanyAnnouncements.Remove(ca);
                    var number = db.SaveChanges();
                    return number;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Boolean returnTrue(int id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var other = db.ClaimHolidays.FirstOrDefault(x => x.Id == id);
                    other.Accept = true;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Boolean returnFalse(int id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var other = db.ClaimHolidays.FirstOrDefault(x => x.Id == id);
                    other.Accept = false;
                    db.SaveChanges();
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
