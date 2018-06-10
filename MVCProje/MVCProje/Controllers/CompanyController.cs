using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeDB;

namespace MVCProje.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddCompany(string name, string surname, string username, string password, string cname)
        {

            try
            {
                using (var db= new ProjeEntities())
                {
                    var dbo = DBO.GetInstance();
                    var u = dbo.AddUser(name, surname, username, password);
                    var c = dbo.AddCompamy(cname);
                    UserCompany uc = new UserCompany();
                    uc.UserId = u.Id;
                    uc.CompanyId = c.Id;
                    db.UserCompanies.Add(uc);
                    db.SaveChanges();
                    return Json("");
                }
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}