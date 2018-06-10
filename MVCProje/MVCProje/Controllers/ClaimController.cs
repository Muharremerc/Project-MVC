using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeDB;
using MVCProje.Models;

namespace MVCProje.Controllers
{
    public class ClaimController : Controller
    {
        // GET: Claim
        public ActionResult Index()
        {

            try
            {
                using (var db =new ProjeEntities())
                {
                    var emp = Session["emp"] as Employee;
                    var ct = db.ClaimTypes.ToList();
                    List<MVCProje.Models.ClaimType> ctt =new List<MVCProje.Models.ClaimType>();
                    foreach (ProjeDB.ClaimType item in ct)
                    {
                       ctt.Add(new Models.ClaimType
                       {
                        Id=item.Id,
                        Name=item.Name
                       });
                    }
                  
                  
                    List<Models.ClaimOther> co =new List<Models.ClaimOther>();
                    List<Models.ClaimHoliday> ch = new List<Models.ClaimHoliday>();
                    var clistother = db.EmployeeClaims.Where(x => x.EmployeeId == emp.Id).Where(z=>z.ClaimTypeId==1).ToList();
                    var clistholiday = db.EmployeeClaims.Where(x => x.EmployeeId == emp.Id).Where(z => z.ClaimTypeId == 2).ToList();

                    var dbo = DBO.GetInstance();


                    foreach (var item in clistholiday)
                    {
                        var returnch = dbo.getCholidaybyId(item.Id);
                        Models.ClaimHoliday mch = new Models.ClaimHoliday();
                        mch.Id = returnch.Id;
                        mch.Start = Convert.ToDateTime(returnch.StartDate);
                        mch.Finish = Convert.ToDateTime(returnch.FinishDate);
                        mch.Accept = (Boolean)returnch.Accept;
                        ch.Add(mch);

                    }

                    foreach (var item in clistother)
                    {
                        var returnch = dbo.getCOtherbyId(item.Id);
                        Models.ClaimOther mco = new Models.ClaimOther();
                        mco.Id = returnch.Id;
                        mco.Details = returnch.Details;
                        co.Add(mco);

                    }

                    MVCProje.Models.ClaimModel Cmodel = new ClaimModel();
                    Cmodel.ClaimTypeModel = ctt;
                    Cmodel.ClaimHolidayModel = ch;
                    Cmodel.ClaimOtherModel = co;

                    return View(Cmodel);
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public JsonResult addClaim(string _details, string _typename)
        {
            try
            {
                using (var db = new ProjeEntities())
                {

                    int _typeid = db.ClaimTypes.Where(z => z.Name == _typename).Select(x => x.Id).FirstOrDefault();
                    var emp = Session["emp"] as Employee;
                    var dba = DBO.GetInstance();
                    var st = dba.addEmpClaim(_typeid,emp.Id);
                    dba.addClaimOther(_details, st.Id);
                    return Json("");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
       

         public JsonResult addHoliday(string _typename,string _start, string _finish)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    int _typeid = db.ClaimTypes.Where(z => z.Name == _typename).Select(x => x.Id).FirstOrDefault();
                    var emp = Session["emp"] as Employee;
                    var dba = DBO.GetInstance();
                    var st = dba.addEmpClaim(_typeid, emp.Id);
                    dba.addHoliday(st.Id, _start, _finish);
                    return Json("");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

            public ActionResult returnOther()
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                   
                    return PartialView("_OtherClaim");
                }
            }
            catch (Exception)
            {

                throw;
            }



        }


        public ActionResult returnHoliday()
        {
            try
            {
                using (var db = new ProjeEntities())
                {

                    return PartialView("_HolidayClaim");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}