using isp_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace isp_management.Controllers
{
    public class PackageController : Controller
    {
        // GET: Package
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(PackageTB pack)
        {
            DBContext DB = new DBContext();
            DB.PackageTBs.Add(pack);
            DB.SaveChanges();
           // ViewData["msg"] = "Successfully Saved";
            return Json("true",JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
           
            DBContext DB = new DBContext();
            PackageTB pack = (from pa in DB.PackageTBs
                          where pa.Id == id
                          select pa).FirstOrDefault();

            return View(pack);
        }
        [HttpPost]
        public JsonResult Edit(PackageTB pac)
        {
            
            DBContext DB = new DBContext();
            PackageTB pack = (from pa in DB.PackageTBs
                              where pa.Id == pac.Id
                              select pa).FirstOrDefault();
            pack.Name = pac.Name;
            pack.MBPS =pac.MBPS;
            pack.Taka = pac.Taka;
            pack.Remarks = pac.Remarks;
            DB.SaveChanges();
          //  ViewData["msg"] = "Successfully Updated";
            return Json("true",JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Search()
        {


            DBContext DB = new DBContext();

            List<PackageTB> pac = (from pack in DB.PackageTBs
                                 select pack).ToList();

            return View(pac);
        }
        [HttpGet]
        public ActionResult PackageDetails(int id)
        {

            DBContext DB = new DBContext();
            PackageTB pac = (from u in DB.PackageTBs
                             where u.Id == id
                             select u).FirstOrDefault();

            return View(pac);
        }
    }
}