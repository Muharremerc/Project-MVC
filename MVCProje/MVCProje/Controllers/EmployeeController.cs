using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeDB;
using MVCProje.Models;

namespace MVCProje.Controllers
{
    public class EmployeeController : Controller
    {
        
        public ActionResult Index()
        {
            try
            {
                using(ProjeEntities db = new ProjeEntities())
                {
                    var empc = Session["empCompany"] as Company;
                    var emp =Session["emp"] as Employee;
                    if (emp == null)
                    {
                        Response.Redirect("~/Login/Index");
                    }

                    

                    var cu = db.Companies.Include("UserCompanies").Include("UserCompanies.Userr").Where(z => z.Id == emp.CompanyId).ToList();
                    var ua = db.Userrs.Include("UserAnnouncements").Include("UserAnnouncements.Announcement").ToList();

                    var modelList = new List<AnnouncementsModel>();
                    foreach (var item in ua)
                    {
                        var lua = new List<DetailsAndTitle>();

                        foreach (var item2 in cu)
                        {
                            foreach (var item3 in item2.UserCompanies)
                            {

                                if (item.Id == item3.Userr.Id)
                                {

                                    foreach (var item4 in item.UserAnnouncements)
                                    {
                                        var dat = new DetailsAndTitle();
                                        dat.Details = item4.Details;
                                        dat.Title = item4.Title;
                                        dat.Id = item4.Id;
                                        lua.Add(dat);
                                    }
                                    AnnouncementsModel a = new AnnouncementsModel()
                                    {
                                        UserName = new Userr()
                                        {
                                            Id = item.Id,
                                            Name = item.Name
                                        },
                                        DetailsAndTitle = lua

                                    };
                                    modelList.Add(a);

                                }

                            }

                        }

                    }
                    return View(emp);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public ActionResult returnShift()
        {
            try
            {
                using (var db= new ProjeEntities() )
                {
               
                    var emp = Session["emp"] as Employee;
                    emp.Name = emp.Name.ToString();
                    emp.Surname = emp.Surname.ToString();
                    int _id = emp.Id;
                    var lshift = db.EmployeeShifts.Include("Shift").Include("Shift.ShiftPrices").Where(x => x.EmployeeId == _id).ToList();



                    return PartialView("_EmpShift",lshift);
                }
            }
            catch (Exception)
            {

                throw;
            }


            
        }


        public ActionResult returnClaim()
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var emp = Session["emp"] as Employee;
                    int _id = emp.Id;
                    var lclaim = db.EmployeeClaims.Include("ClaimType").Include("ClaimOthers").Include("ClaimHolidays").Where(x => x.EmployeeId == _id).ToList();
                    
                    return PartialView("_EmpClaim", lclaim);
                }
            }
            catch (Exception)
            {

                throw;
            }



        }

        public ActionResult returnLog()
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var emp = Session["emp"] as Employee;
                    
                    var emplogin = db.LoginEmployees.Where(x => x.EmployeeId == emp.Id).ToList();

                    return PartialView("_EmpLog", emplogin);
                }
            }
            catch (Exception)
            {

                throw;
            }



        }



        public ActionResult returnAnn()
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var empc = Session["empCompany"] as Company;
                    var emp = Session["emp"] as Employee;
                    if (emp == null)
                    {
                        Response.Redirect("~/Login/Index");
                    }


                    var cu = db.Companies.Include("UserCompanies").Include("UserCompanies.Userr").Where(z => z.Id == emp.CompanyId).ToList();
                    var ua = db.Userrs.Include("UserAnnouncements").Include("UserAnnouncements.Announcement").ToList();

                    var modelList = new List<AnnouncementsModel>();
                    foreach (var item in ua)
                    {
                        var lua = new List<DetailsAndTitle>();

                        foreach (var item2 in cu)
                        {
                            foreach (var item3 in item2.UserCompanies)
                            {

                                if (item.Id == item3.Userr.Id)
                                {

                                    foreach (var item4 in item.UserAnnouncements)
                                    {
                                        var dat = new DetailsAndTitle();
                                        dat.Details = item4.Details;
                                        dat.Title = item4.Title;
                                        dat.Id = item4.Id;
                                        lua.Add(dat);
                                    }
                                    AnnouncementsModel a = new AnnouncementsModel()
                                    {
                                        UserName = new Userr()
                                        {
                                            Id = item.Id,
                                            Name = item.Name
                                        },
                                        DetailsAndTitle = lua

                                    };
                                    modelList.Add(a);

                                }

                            }

                        }

                    }
                    return PartialView("_EmpAnn",modelList);
                }      
            }
            catch (Exception)
            {

                throw;
            }



        }

        [HttpGet]
        public ActionResult UpdEmployee(int id)
        {
            var dbo = DBO.GetInstance();
            var emp = dbo.getEmployee(id);
            return View(emp);
        }

        public JsonResult upde(string name, string surname, string username, string password,int id)
        {

            try
            {
                using (var db = new ProjeEntities())
                {
                    var emp = db.Employees.FirstOrDefault(x => x.Id == id);
                    emp.Name = name;
                    emp.Surname = surname;
                    emp.Password = password;
                    emp.UserName = username;
                    db.SaveChanges();
                    return Json("");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }



        public JsonResult fillemp(int id)
        {

            try
            {
                using (var db = new ProjeEntities())
                {
                    var dbo = DBO.GetInstance();
                    var _emp = dbo.getEmployee(id);
                    Employee emp = new Employee();
                    emp.Name =_emp.Name;
                    emp.Id = _emp.Id;
                    emp.Surname = _emp.Surname;
                    emp.UserName = _emp.UserName;
                    emp.Password = _emp.Password;
                    return Json(emp);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}