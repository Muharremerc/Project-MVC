using ProjeDB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RFID;
namespace MVCProje.Controllers
{
    public class UserController : Controller
    {
        
        // GET: Home
        public ActionResult Index()
        {

            try
            {
                using (ProjeEntities pe = new ProjeEntities())
                {
                    
                    var cus = Session["UserCompany"] as UserCompany;
                    List<Employee> EmployeeList = pe.Employees.Where(x => x.CompanyId == cus.Company.Id).ToList();
                    ViewBag.EmployeeList = EmployeeList;
                    return View();
                }

            }
            catch (Exception)
            {

                throw;
            }


           
        }
        [HttpGet]
        public ActionResult Design(Employee employee)
        {
            try
            {
                using (ProjeEntities pe = new ProjeEntities())
                {
                    Employee emp = pe.Employees.FirstOrDefault(x => x.Id == employee.Id);
                    List<EmployeeShift> lshift = pe.EmployeeShifts.Include("Shift").Where(x => x.EmployeeId == emp.Id).ToList();
                    List<EmployeeClaim> lclaim = pe.EmployeeClaims.Include("ClaimType").Include("ClaimOthers").Include("ClaimHolidays").Where(x => x.EmployeeId == emp.Id).ToList();


                    foreach (var cl in lclaim)
                    {
                        foreach (var info in cl.ClaimOthers)
                        {

                         
                                   
                         }
                    }



                    ViewBag.Shift = lshift;

                    ViewBag.Claim = lclaim;
                    return View(emp);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public ActionResult Property()
        {


            var cus = Session["UserCompany"] as UserCompany;
            Models.PropertyModel pm = new Models.PropertyModel();
            List<Models.ShiftType> sl = new List<Models.ShiftType>();
            List<Models.AnnouncementType> al = new List<Models.AnnouncementType>();
            var dbo = ProjeDB.DBO.GetInstance();

            using (ProjeEntities db = new ProjeEntities())
            {

                var shift = db.Companies.Include("CompanyShifts").Include("CompanyShifts.Shift").Where(x => x.Id == cus.CompanyId).ToList();
                foreach (var item in shift)
                {
                    foreach (var item2 in item.CompanyShifts)
                    {
                        var p = dbo.getPrice(item2.Shift.Id);
                        Models.ShiftType s = new Models.ShiftType();
                        s.Id = item2.Shift.Id;
                        s.Name = item2.Shift.Name;
                        s.Price =(int)p.Price;
                        s.CardName = item2.Shift.ShiftNumber;
                        sl.Add(s);
                    }
                }

                var ann = db.Companies.Include("CompanyAnnouncements").Include("CompanyAnnouncements.Announcement").Where(z => z.Id == cus.CompanyId).ToList();
             
                foreach (var item in ann)
                {
                    foreach (var item2 in item.CompanyAnnouncements)
                    {
                        Models.AnnouncementType a = new Models.AnnouncementType();
                        a.Id = item2.Announcement.Id;
                        a.Name = item2.Announcement.Name;
                        al.Add(a);
                            
                    }
                }

                pm.ShiftList = sl;
                pm.AnnList = al;

                return View(pm);
           }
           

        }



        public JsonResult DelEmp(int id)
        {
            using (var db = new ProjeEntities())
            {
                var dbo = DBO.GetInstance();
                var cus = Session["UserCompany"] as UserCompany;
                var delClaim = dbo.delEmployee(id);
                db.SaveChanges();
                return Json("");
            }
        }



        [HttpGet]
        public ActionResult AddEmployee(int id)
        {
            var dbo = DBO.GetInstance();
            var emp = dbo.getEmployee(id);
            Employee emp2 = new Employee();
            if(emp != null)
            {
                return View(emp);
            }
            else
                return View(emp2);
        }

        public JsonResult AddNewEmployee(string name,string surname, string username, string password, string cardId,int id)
        {
            var db = DBO.GetInstance();
            var cus = Session["UserCompany"] as UserCompany;
            if (id==0)
            {
           
            db.AddNewEmployee(name, surname, username, password, cardId, (int)cus.CompanyId);
            }
            else
            {
                Employee emp = new Employee();
                emp.Name = name;
                emp.Surname = surname;
                emp.Password = password;
                emp.UserName = username;
                emp.CardNumber = cardId;
                emp.CompanyId = (int)cus.CompanyId;
                emp.Id = id;
                db.UpdaEmp(emp);
            }
            return Json("");
        }

        public JsonResult ReadCard()
        {
            RFID.NFCReader rf = new RFID.NFCReader();
            rf.Connect();
            var _ıd=rf.GetCardUID();
            rf.Disconnect();
            return Json(_ıd);
        }

        public JsonResult ReadCardName()
        {
            
            RFID.NFCReader rf = new RFID.NFCReader();
            rf.Connect();
            var _ıd = rf.GetReadersList()[0];
            rf.Disconnect();
            return Json(_ıd);

        }

        public JsonResult sentvalue(int id)
        {
            var db = DBO.GetInstance();
            var st = db.getEmployee(id);
            Models.EmployeeModel emp = new Models.EmployeeModel();
            emp.Id = st.Id;
            emp.Name = st.Name;
            emp.Surname = st.Surname;
            emp.Username = st.UserName;
            emp.Password = st.Password;
            emp.CardId = st.CardNumber;
            return Json(emp);

        }

        public JsonResult updEmp(string name, string surname, string username, string password, string cardId)
        {
            Employee emp = new Employee();
            emp.Name = name;
            emp.Surname = surname;
            emp.UserName = username;
            emp.Password = password;
            emp.CardNumber = cardId;
            return Json("");

        }






        [HttpPost]
        public JsonResult AddShift(string name, string price,string cardname)
        {
            try
            {
                using (ProjeEntities pe = new ProjeEntities())
                {
                    var ch = pe.Shifts.Where(x => x.ShiftNumber == cardname).FirstOrDefault();
                    if (ch == null)
                    {
                        var cus = Session["UserCompany"] as UserCompany;
                        var lshift = pe.CompanyShifts.Include("Shift").Where(x => x.CompanyId == cus.Company.Id).ToList();

                        var dbo = ProjeDB.DBO.GetInstance();
                        var sh = dbo.AddShift(name, cardname);
                        var shp = dbo.AddShiftPrice(sh.Id, price);
                        var cs = dbo.addCompanyShift((int)cus.CompanyId, sh.Id);
                        return Json("True");
                    }
                    else
                        return Json("False");
                }
            }
            catch (Exception)
            {

                throw;
            }

           
        }

        public JsonResult AddAnn(string name)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var cus = Session["UserCompany"] as UserCompany;
                    var dbo = ProjeDB.DBO.GetInstance();
                    var a = dbo.AddAnn(name);
                    var ca = dbo.AddAnnCompany(a.Id,(int)cus.CompanyId);
                    return Json("");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult DelAnn(int id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var cus = Session["UserCompany"] as UserCompany;
                    var dbo = ProjeDB.DBO.GetInstance();

                    var ua = dbo.delUserAnn(id);
                    var c = dbo.delAnnCom(id);
                    var a = db.Announcements.FirstOrDefault(x => x.Id == id);
                    db.Announcements.Remove(a);
                    db.SaveChanges();
                    
                    return Json("");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }




        public ActionResult returnAddShift()
        {
            try
            {
                using (var db = new ProjeEntities())
                {

                    return PartialView("_returnAddShift");
                }
            }
            catch (Exception)
            {

                throw;
            }



        }
        public ActionResult returnAddAnn()
        {
            try
            {
                using (var db = new ProjeEntities())
                {

                    return PartialView("_returnAddAnn");
                }
            }
            catch (Exception)
            {

                throw;
            }



        }

        public JsonResult DelShift(int _id)
        {
            try
            {
                using (var pe = new ProjeEntities())
                {

                    var s = pe.Shifts.FirstOrDefault(x => x.Id == _id);
                    var empS = pe.EmployeeShifts.Where(x => x.ShiftId == s.Id).ToList();

                    foreach (var item in empS)
                    {

                        pe.EmployeeShifts.Remove(item);

                    }
                    pe.SaveChanges();


                    var sp = pe.ShiftPrices.FirstOrDefault(x => x.ShiftId == s.Id);
                    var cs = pe.CompanyShifts.FirstOrDefault(x => x.ShiftId == s.Id);

                    pe.ShiftPrices.Remove(sp);
                    pe.CompanyShifts.Remove(cs);
                    pe.SaveChanges();
                    pe.Shifts.Remove(s);
                    pe.SaveChanges();
                     return Json("Del");
                }
            }
            catch (Exception)
            {

                throw;
            }  
           

        }



        public ActionResult AddUser()
        {
            return View();
        }

        public JsonResult AddUsers(string name, string surname, string username,string password)
        {
            try
            {
                using (ProjeEntities db = new ProjeEntities())
                {
                    var dbo = DBO.GetInstance();
                    var cus = Session["UserCompany"] as UserCompany;
                    var u = dbo.AddUser(name, surname, username, password);

                    UserCompany uc =new UserCompany();
                    uc.UserId = u.Id;
                    uc.CompanyId = (int)cus.CompanyId;
                    db.UserCompanies.Add(uc);
                    db.SaveChanges();
                    return Json("");
                }
            }
            catch (Exception exe)
            {

                throw;
            }


        }


    }
}