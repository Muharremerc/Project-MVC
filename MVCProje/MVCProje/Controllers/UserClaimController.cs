using MVCProje.Models;
using ProjeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class UserClaimController : Controller
    {
        // GET: UserClaim
        public ActionResult Index()
        {

            try
            {
                using (var db = new ProjeEntities())
                {
                    var emp = Session["User"] as Userr;
                    var usercompany = Session["UserCompany"]  as UserCompany;
                    var clistother = db.Employees.Include("EmployeeClaims").Where(x => x.CompanyId == usercompany.CompanyId).ToList();
                    

                    List<EmployeeClaimOtherList> ecl = new List<EmployeeClaimOtherList>();
                    List<EmployeeClaimHolidayList> echl = new List<EmployeeClaimHolidayList>();

                    var dbo = DBO.GetInstance();


                    //foreach (var item in clistholiday)
                    //{
                    //    var returnch = dbo.getCholidaybyId(item.Id);
                    //    Models.ClaimHoliday mch = new Models.ClaimHoliday();
                    //    mch.Id = returnch.Id;
                    //    mch.Start = Convert.ToDateTime(returnch.StartDate);
                    //    mch.Finish = Convert.ToDateTime(returnch.FinishDate);
                    //    ch.Add(mch);

                    //}

                    foreach (var item in clistother)
                    {
                        foreach (var item2 in item.EmployeeClaims)
                        {
                             if(item2.ClaimTypeId==1)
                            {
                                var returnch = dbo.getCOtherbyId(item2.Id);
                                Models.EmployeeClaimOtherList ec = new Models.EmployeeClaimOtherList();
                                ec.Name = item.Name + "" + item.Surname;
                                ec.Details = returnch.Details;
                                ecl.Add(ec);
                            }
                            else
                            {
                                var returnch = dbo.getCholidaybyId(item2.Id);
                                Models.EmployeeClaimHolidayList ec = new Models.EmployeeClaimHolidayList();
                                ec.Name = item.Name + "" + item.Surname;
                                ec.Finish = Convert.ToDateTime(returnch.FinishDate);
                                ec.Start = Convert.ToDateTime(returnch.StartDate);
                                ec.Check = (Boolean)returnch.Accept;
                                ec.Id = returnch.Id;
                                echl.Add(ec);
                            }
                            
                        }
                        

                    }

                    MVCProje.Models.ClaimListUserModel Cmodel = new ClaimListUserModel();
           
                    Cmodel.HolidayClaim = echl;
                    Cmodel.OtherClaim = ecl;

                    return View(Cmodel);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public JsonResult AccepTrue(int id)
        {
            try
            {
                using (var db =new ProjeEntities())
                {
                    var dbo = DBO.GetInstance();
                    var holiday = dbo.returnTrue(id);

                    return Json("");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public JsonResult AccepFalse(int id)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var dbo = DBO.GetInstance();
                    var holiday = dbo.returnFalse(id);

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