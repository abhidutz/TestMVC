using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using MVC.Filters;
using System.Data.Entity;
using MVC.Models;
using System.Web.Script.Serialization;
namespace MVC.Controllers
{
    public class HomeController : Controller
    {


        Cohort_PanthersEntities1 db = new Cohort_PanthersEntities1();
       
        public ActionResult Index()
        {
            if (!WebSecurity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else { 
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
            }

        }

        [HttpPost]
        public ActionResult getComments(int id)
        
        {
            

          var res =   db.Comments.Where(c => c.emailId == id);

    
            return Json(res.ToList().ToString());
        
        }

        public ActionResult DDOS()
        {

            return View();
        
        }

      
        public ActionResult DetailEmail(int id, FormCollection collection)
        {string com="";
            if(collection.Count>0)
             com = collection[0];


           var cdd = db.Emails.Where(c => c.EmailID == id);
           var css = cdd.ToList();
           ViewBag.email = css[0];
           ViewBag.Comments=db.Comments.Where(c => c.emailId == id).ToList();
            return View();
        
        }



        public ActionResult Emails()

        {
            //Cohort_PanthersEntities db = new Cohort_PanthersEntities();

        
       var c =      db.Emails.ToList();


       ViewBag.emails = c;
            if (!WebSecurity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
          
               // ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
                return View();
            }

        } 

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
