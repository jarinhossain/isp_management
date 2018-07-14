using isp_management.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace isp_management.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["GenderList"] = LoadGender();
            ViewData["RouteList"] = LoadRoute();
            ViewData["PackageList"] = LoadPackage();
            ViewData["StatusList"] = LoadStatus();
            ViewData["bloodlist"] = Loadblood();
            return View();
        }
        [HttpPost]
        public JsonResult Create(Client client)
        {
            ViewData["GenderList"] = LoadGender();
           ViewData["RouteList"] = LoadRoute();
            ViewData["PackageList"] = LoadPackage();
            ViewData["StatusList"] = LoadStatus();
            ViewData["bloodlist"] = Loadblood();

            HttpPostedFileBase file = null;
            var image = System.Web.HttpContext.Current.Request.Files["Image"];
            try { file = Request.Files[0]; } catch { }

            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();
                if (extension != ".jpg")
                {
                    ViewData["msg"] = "Failed to Save User Information! Allowed image format is .jpg";
                   // return View();
                }
            }
            DBContext DB = new DBContext();
            DB.Clients.Add(client);
            DB.SaveChanges();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();
                string path = Path.Combine(Server.MapPath("~/Images/Client"), "C_" + client.Id + extension);
                file.SaveAs(path);/// file save
            }
            // ViewData["msg"] = "Successfully Saved";
            return Json("true",JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)


        {
            ViewData["GenderList"] = LoadGender();
            ViewData["RouteList"] = LoadRoute();
            ViewData["PackageList"] = LoadPackage();
            ViewData["StatusList"] = LoadStatus();
            ViewData["bloodlist"] = Loadblood();
            DBContext DB = new DBContext();
            Client cl = (from clie in DB.Clients
                           where clie.Id == id
                           select clie).FirstOrDefault();

            return View(cl);
        }
        [HttpPost]
        public JsonResult Edit(Client clien)
        {
            ViewData["GenderList"] = LoadGender();
            ViewData["RouteList"] = LoadRoute();
            ViewData["PackageList"] = LoadPackage();
            ViewData["StatusList"] = LoadStatus();
            ViewData["bloodlist"] = Loadblood();
            DBContext DB = new DBContext();
            Client cli = (from cl in DB.Clients
                          where cl.Id == clien.Id
                          select cl).FirstOrDefault();
            cli.Code = clien.Code;
            cli.Name = clien.Name;
            cli.Mobile1 = clien.Mobile1;
            cli.Mobile2 = clien.Mobile2;
            cli.Email = clien.Email;
            cli.Gender_Id = clien.Gender_Id; 
           cli.Blood_Group_Id = clien.Blood_Group_Id;
            cli.National_Id = clien.National_Id;
            cli.Occupation = clien.Occupation;
            cli.Address = clien.Address;
            cli.Monthly_Amount = clien.Monthly_Amount;
            cli.IP_Address = clien.IP_Address;
            cli.Connection_Date = clien.Connection_Date;
            cli.Speed = clien.Speed;
            cli.Status_Id = clien.Status_Id;
            cli.Route = clien.Route;
           cli.Package = clien.Package;
            cli.Discount = clien.Discount;
           
            DB.SaveChanges();
           // ViewData["msg"] = "Successfully Updated";
            return Json("true", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ClientDetails(int id)
        {
            
            DBContext DB = new DBContext();
            Client client = (from u in DB.Clients
                                  where u.Id == id
                                  select u).FirstOrDefault();

            return View(client);
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
        public List<SelectListItem> LoadRoute()
        {
            DBContext DB = new DBContext();
            List<RouteTB> ro = (from cla in DB.RouteTBs
                              select cla).ToList();
            List<SelectListItem> route = new List<SelectListItem>();
            foreach (var item in ro)
            {
                route.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            return route;
        }
        public List<SelectListItem> LoadPackage()
        {
            DBContext DB = new DBContext();
            List<PackageTB> gen = (from clas in DB.PackageTBs
                                select clas).ToList();
            List<SelectListItem> gend = new List<SelectListItem>();
            foreach (var item in gen)
            {
                gend.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            return gend;
        }
        public List<SelectListItem> Loadblood()
        {
            DBContext DB = new DBContext();
            List<Blood_Group_TB> blod = (from bl in DB.Blood_Group_TB
                                         select bl).ToList();
            List<SelectListItem> blood = new List<SelectListItem>();
            foreach (var item in blod)
            {
                blood.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            return blood;
        }
     
        public List<SelectListItem> LoadStatus()
        {
            DBContext DB = new DBContext();
            List<Client_Status> st = (from clas in DB.Client_Status
                               select clas).ToList();
            List<SelectListItem> status = new List<SelectListItem>();
            foreach (var item in st)
            {
                status.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            return status;
        }
        public ActionResult testLayout()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Search()
        {
            

            DBContext DB = new DBContext();

            List<Client> clientList = (from client in DB.Clients
                                            select client).ToList();

            return View(clientList);
        }

        public JsonResult getClient(string code)//code
        {
            DBContext DB = new DBContext();

            Client cl = (from client in DB.Clients
                             where client.Code == code
                             select client).FirstOrDefault();

            return Json(cl.Name, JsonRequestBehavior.AllowGet);
        }


    }

}