using ProjeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProje.Models;

namespace MVCProje.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        public ActionResult Index()
        {
            try
            {
                using (ProjeEntities db = new ProjeEntities())
                {
                    var usc = Session["UserCompany"] as UserCompany;
                    

                    var aaa= db.Companies.Include("UserCompanies").Include("UserCompanies.Userr").Where(z => z.Id == usc.Company.Id).ToList();
                    var bbb = db.Userrs.Include("UserAnnouncements").Include("UserAnnouncements.Announcement").ToList();
                    var LAnnouncementType = db.Companies.Include("CompanyAnnouncements").Include("CompanyAnnouncements.Announcement").Where(X=>X.Id== usc.CompanyId).ToList();
                   
                    ViewBag.La = LAnnouncementType;

                    //foreach (var item in LAnnouncementType)
                    //{
                    //    foreach (var item2 in item.CompanyAnnouncements)
                    //    {
                    //        item2.Announcement.Name
                    //    }
                    //}

                    var modelList = new List<AnnouncementsModel>();
                    foreach (var item in bbb)
                    {
                        var lua = new List<DetailsAndTitle>();

                        foreach (var item2 in aaa)
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
                    ViewBag.comb = modelList;

                    //foreach (var item in modelList)
                    //{
                    //    foreach (var item2 in item.DetailsAndTitle)
                    //    {
                            
                    //    }
                    //}


                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }



           
        }

        public JsonResult AddAnnouncements(string _type,string _textArea,string _title)
        {

            try
            {
                using (ProjeEntities db = new ProjeEntities())
                {
                    var user = Session["User"] as Userr;
                    var usc = Session["UserCompany"] as UserCompany;
                   
                    var LAnnouncementType = db.Companies.Include("CompanyAnnouncements").Include("CompanyAnnouncements.Announcement").Where(X => X.Id == usc.Id).ToList();
                    int typeid = db.Announcements.Where(x => x.Name ==_type).Select(z=>z.Id).FirstOrDefault();

                    
                    
                    UserAnnouncement us = new UserAnnouncement();
                    us.AnnouncementId = typeid;
                    us.UserId = user.Id;
                    us.Details = _textArea;
                    us.Title = _title;
                    db.UserAnnouncements.Add(us);
                    db.SaveChanges();
                    return Json("Add");
                }
            }
            catch (Exception)
            {

                throw;
            }   
        }


        public JsonResult DeleteAnnouncements(int _id)
        {

            try
            {
                using (ProjeEntities db = new ProjeEntities())
                {

                    var ann = db.UserAnnouncements.Where(x => x.Id == _id).FirstOrDefault();
                    db.UserAnnouncements.Remove(ann);
                    db.SaveChanges();



                    return Json("Delete");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


