using isp_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace isp_management.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ExpenseCreate()
        {
            ViewData["AccountHeadList"] = LoadAccount();
            return View();
        }
        [HttpPost]
        public JsonResult ExpenseCreate(ExpenseTB expense)
        {
            ViewData["AccountHeadList"] = LoadAccount();
            DBContext db = new DBContext();
            db.ExpenseTBs.Add(expense);
            db.SaveChanges();
            return Json("true", JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult ExpenseEdit(int id)
        {
            ViewData["AccountHeadList"] = LoadAccount();
            DBContext db = new DBContext();
            ExpenseTB account = (from ac in db.ExpenseTBs
                                       where ac.Id == id
                                       select ac).FirstOrDefault();
            return View(account);
        }
        [HttpPost]
        public JsonResult ExpenseEdit(ExpenseTB expense)
        {
            ViewData["AccountHeadList"] = LoadAccount();
          
            DBContext db = new DBContext();
            ExpenseTB account = (from ac in db.ExpenseTBs
                                 where ac.Id == expense.Id
                                 select ac).FirstOrDefault();

            account.AccountHead_Id = expense.AccountHead_Id;
            account.Amount = expense.Amount;
            account.Amount_Details = expense.Amount_Details;
            db.SaveChanges();

            return Json("true", JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult ExpenseSearch()
        {


            DBContext DB = new DBContext();

            List<ExpenseTB> expense = (from client in DB.ExpenseTBs
                                       select client).ToList();

            return View(expense);
        }
        [HttpGet]
        public ActionResult ExpenseDetails(int id)
        {

            DBContext DB = new DBContext();
            ExpenseTB client = (from u in DB.ExpenseTBs
                                      where u.Id == id
                                      select u).FirstOrDefault();

            return View(client);
        }

        public List<SelectListItem> LoadAccount()
        {
            DBContext DB = new DBContext();
            List<Account_Head_TB> gen = (from clas in DB.Account_Head_TB
                                select clas).ToList();
            List<SelectListItem> gend = new List<SelectListItem>();
            foreach (var item in gen)
            {
                gend.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
            return gend;
        }
        [HttpGet]
        public ActionResult AccountHeadCreate()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AccountHeadCreate(Account_Head_TB acount)
        {
            DBContext db = new DBContext();
            db.Account_Head_TB.Add(acount);
            db.SaveChanges();
            return Json("true",JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AccountHeadEdit(int id)
        {
            DBContext db = new DBContext();
            Account_Head_TB account = (from ac in db.Account_Head_TB
                                       where ac.Id == id
                                       select ac).FirstOrDefault();


            return View(account);
        }
        [HttpPost]
        public JsonResult AccountHeadEdit(Account_Head_TB account)
        {
            DBContext db = new DBContext();
            Account_Head_TB accoun = (from ac in db.Account_Head_TB
                                       where ac.Id == account.Id
                                      select ac).FirstOrDefault();

            accoun.Name = account.Name;
            db.SaveChanges();

            return Json("true",JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AccountheadSearch()
        {


            DBContext DB = new DBContext();

            List<Account_Head_TB> expense = (from client in DB.Account_Head_TB
                                       select client).ToList();

            return View(expense);
        }
        [HttpGet]
        public ActionResult AccountHeadDetails(int id)
        {

            DBContext DB = new DBContext();
            Account_Head_TB client = (from u in DB.Account_Head_TB
                             where u.Id == id
                             select u).FirstOrDefault();

            return View(client);
        }
    }
}