using ProjeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(String _username,String _pass)
        {
            try
            {
                using (ProjeEntities db = new ProjeEntities())
                {
                    _username = Request.Form["_username"];
                    _pass = Request.Form["_pass"];
                    var userDetails = db.Userrs.Where(x => x.UserName == _username && x.Password == _pass).FirstOrDefault();
                    var empDetails = db.Employees.Where(x => x.UserName == _username && x.Password == _pass).FirstOrDefault();

                    if (userDetails != null)
                    {
                        var user = db.UserCompanies.Include("Company").Where(x => x.UserId == userDetails.Id).FirstOrDefault();
                        Session["UserName"] = userDetails.Name;
                        Session["UserSurname"] = userDetails.Surname;
                        Session["CompanyName"] = user.Company.Name;
                        Session["UserCompany"] = user;
                        Session["User"] = userDetails;
                     
                        Session["Check"] = "User";
                       
                        return RedirectToAction("Index", "User");
                    }
                    else if (empDetails != null)
                    {

                        Session["empCompany"] = db.Companies.Where(x => x.Id == empDetails.CompanyId).Select(x => x.Name).FirstOrDefault();
                        Session["emp"] = empDetails;
                        Session["Check"] = "Emp";
                        Session["UserName"] = empDetails.Name;
                        Session["UserSurname"] = empDetails.Surname;
                        var compname = db.Companies.Where(x => x.Id == empDetails.CompanyId).Select(x => x.Name).FirstOrDefault();
                        Session["CompanyName"] = compname;
                        return RedirectToAction("Index", "Employee");
                    }
                    else
                    {
                        return View("Index");
                    }

                }

            }
            catch (Exception exec)
            {

                throw;
            }
              
        }

        public ActionResult LogOut()
        {
            try
            {
                Session.Abandon();
                return RedirectToAction("Index/Login");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}