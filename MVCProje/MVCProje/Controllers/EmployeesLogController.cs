using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeDB;
using MVCProje.Models;

namespace MVCProje.Controllers
{
    public class EmployeesLogController : Controller
    {
        // GET: EmployeesLog
        public ActionResult Index()
        {
            try
            {
                using (var db = new ProjeDB.ProjeEntities())
                {
                    var dbo = ProjeDB.DBO.GetInstance();
                    var usercompany = Session["UserCompany"] as UserCompany;
                    List<ProjeDB.DBO.EmployeeLoginModel> elm = new List<ProjeDB.DBO.EmployeeLoginModel>();
                    
                    var list = db.Employees.Include("LoginEmployees").Where(x => x.CompanyId == usercompany.CompanyId).ToList();
                    foreach (var item in list)
                    {
                       
                        var a = dbo.getEmpLogin(item.Id);
                       

                        elm.Add(new ProjeDB.DBO.EmployeeLoginModel
                        {
                            Id=item.Id,
                            Employeename=item.Name,
                            SNameDate=a


                        }
                        );
                    }
                   
                    return View(elm);
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}