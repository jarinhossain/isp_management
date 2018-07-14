using isp_management.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace isp_management.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UsertypeCreate()
        {

            return View();
        }
        [HttpPost]
        public JsonResult UsertypeCreate(UsertypeTB type)
        {

            DBContext db = new DBContext();
            db.UsertypeTBs.Add(type);
            db.SaveChanges();
            return Json("true", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult UsertypeEdit(int id)
        {
            DBContext db = new DBContext();
            UsertypeTB account = (from ac in db.UsertypeTBs
                                       where ac.Id == id
                                       select ac).FirstOrDefault();


            return View(account);
        }
        [HttpPost]
        public JsonResult UsertypeEdit(Account_Head_TB account)
        {
            DBContext db = new DBContext();
            UsertypeTB accoun = (from ac in db.UsertypeTBs
                                      where ac.Id == account.Id
                                      select ac).FirstOrDefault();

            accoun.Name = account.Name;
            db.SaveChanges();

            return Json("true", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult UsertypeSearch()
        {


            DBContext DB = new DBContext();

            List<UsertypeTB> type = (from client in DB.UsertypeTBs
                                       select client).ToList();

            return View(type);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["GenderList"] = LoadGender(); 
            ViewData["StatusList"] = LoadStatus(); 
                ViewData["typeList"] = Loadtype();
            return View();
        }
        [HttpPost]
        public JsonResult Create(UserTB user)
        {
            ViewData["GenderList"] = LoadGender();
            ViewData["StatusList"] = LoadStatus();
            ViewData["typeList"] = Loadtype();
            //HttpPostedFileBase file = null;
            //try { file = Request.Files[0]; } catch { }

            //if (file != null && file.ContentLength > 0)
            //{
            //    string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();
            //    if (extension != ".jpg")
            //    {
            //        ViewData["msg"] = "Failed to Save User Information! Allowed image format is .jpg";
            //        return View();
            //    }

            //}
            DBContext DB = new DBContext();
          //  user.Image = file != null && file.ContentLength > 0 ? true : false;
            DB.UserTBs.Add(user);
            DB.SaveChanges();
            //if (file != null && file.ContentLength > 0)
            //{
            //    string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();
            //    string path = Path.Combine(Server.MapPath("~/Images/User"), "U_" + user.Id + extension);
            //    file.SaveAs(path);/// file save
            //}
          
            return Json("true",JsonRequestBehavior.AllowGet);
        }
        public List<SelectListItem> LoadGender()
        {
            DBContext DB = new DBContext();
            List<Gender> gen = (from clas in DB.Genders                 
                                select clas).ToList();
            List<SelectListItem> gend = new List<SelectListItem>();
            foreach (var item in gen)
            {
                gend.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            return gend;
        }
        
             public List<SelectListItem> LoadStatus()
        {
            DBContext DB = new DBContext();
            List<User_StatusTB> status = (from clas in DB.User_StatusTB
                                select clas).ToList();
            List<SelectListItem> gend = new List<SelectListItem>();
            foreach (var item in status)
            {
                gend.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            return gend;
        }
        
        public List<SelectListItem> Loadtype()
        {
            DBContext DB = new DBContext();
            List<UsertypeTB> status = (from clas in DB.UsertypeTBs
                                          select clas).ToList();
            List<SelectListItem> gend = new List<SelectListItem>();
            foreach (var item in status)
            {
                gend.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            return gend;
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewData["GenderList"] = LoadGender();
            ViewData["StatusList"] = LoadStatus();
            ViewData["typeList"] = Loadtype();
            DBContext DB = new DBContext();
            UserTB user = (from use in DB.UserTBs
                           where use.Id == id
                           select use).FirstOrDefault();    
          
            return View(user);
        }
        [HttpPost]
        public JsonResult Edit(UserTB use)
        {
            ViewData["GenderList"] = LoadGender();
            ViewData["StatusList"] = LoadStatus();
            ViewData["typeList"] = Loadtype();
            DBContext DB = new DBContext();
            UserTB user = (from us in DB.UserTBs
                           where us.Id == use.Id
                           select us).FirstOrDefault(); 
            user.FullName = use.FullName;
            user.UserName = use.UserName;
            user.Password = use.Password;
            user.Email = use.Email;
            user.Mobile1 = use.Mobile1;
            user.Mobile2 = use.Mobile2;
            user.Gender_Id = use.Gender_Id;
            user.National_Id = use.National_Id;
            user.Address = use.Address;
            user.Remarks = use.Remarks;
            user.UserStatus_Id = use.UserStatus_Id;
            user.UserType_Id = use.UserType_Id;
            DB.SaveChanges();
           
            return Json("true",JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Search()
        {


            DBContext DB = new DBContext();

            List<UserTB> user = (from us in DB.UserTBs
                                       select us).ToList();

            return View(user);
        }
        [HttpGet]
        public ActionResult UserDetails(int id)
        {

            DBContext DB = new DBContext();
            UserTB client = (from u in DB.UserTBs
                                where u.Id == id
                                select u).FirstOrDefault();

            return View(client);
        }
        [HttpGet]
        public ActionResult UsertypeDetails(int id)
        {

            DBContext DB = new DBContext();
            UsertypeTB client = (from u in DB.UsertypeTBs
                             where u.Id == id
                             select u).FirstOrDefault();

            return View(client);
        }
    }
}