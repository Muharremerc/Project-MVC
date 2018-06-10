using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeDB;
using System.Threading;
using System.Globalization;

namespace MVCProje.Controllers
{
    public class CardReaderController : Controller
    {
        // GET: CardReader
        public ActionResult Index()
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    var user = Session["User"] as Userr;
                    var usc = Session["UserCompany"] as UserCompany;
                    var lEmployee = db.Employees.Where(x => x.CompanyId == usc.Company.Id).ToList();
                    ViewBag.lEmployee = lEmployee;
                    var lShift = db.Companies.Include("CompanyShifts").Include("CompanyShifts.Shift").Where(x => x.Id == usc.Company.Id).ToList();
                    ViewBag.lShift = lShift;

                    var empList = db.Employees.Include("EmployeeShifts").Include("EmployeeShifts.Shift").Where(x => x.CompanyId == usc.Company.Id).ToList();
                    ViewBag.empList = empList;

                  

                    //foreach (var item in lShift)
                    //{
                    //    foreach (var item2 in item.CompanyShifts)
                    //    {
                    //        item2.Shift.Name
                    //    }
                    //}

                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public JsonResult AddEmployeeShift(string _cardId, string _shiftid, string _start,string _finish)
        {

            try
            {
                using (var db = new ProjeEntities())
                {
                    EmployeeShift es = new EmployeeShift();
                    es.ShiftId = db.Shifts.Where(x => x.Name == _shiftid).Select(x => x.Id).FirstOrDefault();
                    es.EmployeeId= db.Employees.Where(x => x.CardNumber==_cardId).Select(x => x.Id).FirstOrDefault();
                    es.Finish = Convert.ToDateTime(_finish);
                    es.Start = Convert.ToDateTime(_start);
                    db.EmployeeShifts.Add(es);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Json("a");
        }

        public JsonResult ReadCard()
        {
            RFID.NFCReader rf = new RFID.NFCReader();
            rf.Connect();
            var _ıd = rf.GetCardUID();
            rf.Disconnect();
            return Json(_ıd);
        }
    }
}