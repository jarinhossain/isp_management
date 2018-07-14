using isp_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace isp_management.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route
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
        public JsonResult Create(RouteTB ro)
        {
            DBContext DB = new DBContext();
            DB.RouteTBs.Add(ro);
            DB.SaveChanges();
           // ViewData["msg"] = "Successfully Saved";
            return Json("true",JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            DBContext DB = new DBContext();
            RouteTB route = (from rou in DB.RouteTBs
                              where rou.Id == id
                              select rou).FirstOrDefault();

            return View(route);
        }
        [HttpPost]
        public JsonResult Edit(RouteTB ro)
        {

            DBContext DB = new DBContext();
            RouteTB route = (from pa in DB.RouteTBs
                              where pa.Id == ro.Id
                              select pa).FirstOrDefault();
            route.Name = ro.Name;
            route.Address = ro.Address;
            route.Post_Code = ro.Post_Code;
            DB.SaveChanges();
            return Json ("true",JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Search()
        {


            DBContext DB = new DBContext();

            List<RouteTB> route = (from us in DB.RouteTBs
                                 select us).ToList();

            return View(route);
        }
        [HttpGet]
        public ActionResult RouteDetails(int id)
        {

            DBContext DB = new DBContext();
            RouteTB pac = (from u in DB.RouteTBs
                             where u.Id == id
                             select u).FirstOrDefault();

            return View(pac);
        }
    }
}