using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ali_Jameel.Models;
using System.Data;
using System.IO;
using System.Text;

namespace Ali_Jameel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["Username"] != null)
            {
                return View();
            }
            else
            {
                //return View();
                return RedirectToAction("Index", "Login");
            }
          
        }

        [HttpGet]
        public ActionResult Vendors()
        {
            if (System.Web.HttpContext.Current.Session["Username"] != null)
            {

                DBMS db = new DBMS();
                DataTable table = db.ExecuteSelectQuery("select * from vendor");

                List<Vendor> Vendors = new List<Vendor>();
                foreach (DataRow item in table.Rows)
                {
                    Vendor Vendor = new Vendor();
                    Vendor.ID = (int)item["ID"];
                    Vendor.CompanyName = item["CompanyName"].ToString();
                    Vendor.LogoName = "\\Content\\Logos\\" + item["CompanyLogo"].ToString(); // System.Web.HttpContext.Current.Server.MapPath("~//Content//Logos//") 
                    Vendor.CompanyURL = item["CompanyURL"].ToString();
                    Vendor.Email = item["Email"].ToString();
                    Vendor.Address = item["Address"].ToString();
                    Vendor.ContactNumber = item["ContactNumber"].ToString();
                    Vendors.Add(Vendor);
                }
                return View(Vendors);
            }
            else
            {
                //return View();
                return RedirectToAction("Index", "Login");
            }


        }


        [HttpGet]
        public bool DeleteVendors(int VendorID)
        {
            bool ok = false;
            DBMS db = new DBMS();
            ok = db.ExecuteDeleteQuery($"DELETE FROM vendor WHERE ID = '{VendorID}'");
            return ok;
        }


        [HttpGet]
        public ActionResult CreateVendors()
        {
            if (System.Web.HttpContext.Current.Session["Username"] != null)
            {

                return View();
            }
            else
            {
                //return View();
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult CreateVendors(Vendor vendor)
        {

            DBMS db = new DBMS();
            if (System.Web.HttpContext.Current.Session["Username"] != null)
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(vendor.LogoPath.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Logos/"), filename);
                    vendor.LogoPath.SaveAs(path);
                    bool ok = db.ExecuteInsertQuery($" insert into vendor (CompanyName,CompanyLogo,CompanyURL,Email,Address,ContactNumber) values ('{vendor.CompanyName}' ,'{vendor.LogoPath.FileName}','{vendor.CompanyURL}','{vendor.Email}','{vendor.Address}','{vendor.ContactNumber}')");
                    ModelState.Clear();
                }
                return View();
            }
            else
            {
                //return View();
                return RedirectToAction("Index", "Login");
            }

        }


        [HttpGet]
        public ActionResult News()
        {
            if (System.Web.HttpContext.Current.Session["Username"] != null)
            {
                DBMS db = new DBMS();
                DataTable table = db.ExecuteSelectQuery("select * from News order by PublishDate DESC");

                List<News> News = new List<News>();
                foreach (DataRow item in table.Rows)
                {
                    News singleNews = new News();
                    singleNews.ID = (int)item["ID"];
                    singleNews.Title = item["title"].ToString();
                    singleNews.Description = item["description"].ToString();
                    singleNews.WebsiteLink = item["WebsiteLink"].ToString();
                    singleNews.LogoName = "\\Content\\Logos\\" + item["logo"].ToString();
                    singleNews.HtmlContent = item["htmlContent"].ToString();
                    singleNews.PublishDate = item["PublishDate"].ToString();
                    News.Add(singleNews);
                }
                return View(News);
            }
            else
            {
                //return View();
                return RedirectToAction("Index", "Login");
            }
        }


        [HttpGet]
        public bool DeleteNews(int newsID)
        {
            bool ok = false;
            DBMS db = new DBMS();
            ok = db.ExecuteDeleteQuery($"DELETE FROM news WHERE ID = '{newsID}'");
            return ok;
        }


         [HttpGet]
        public ActionResult CreateNews()
        {
            if (System.Web.HttpContext.Current.Session["Username"] != null)
            {
                return View();
            }
            else
            {
                //return View();
                return RedirectToAction("Index", "Login");
            }
        }


        [HttpPost]
        public ActionResult CreateNews(News News)
        {
            if (System.Web.HttpContext.Current.Session["Username"] != null)
            {

                if (ModelState.IsValid)
                {
                  
                    var filename = Path.GetFileName(News.LogoPath.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/News/logos/"), filename);
                    News.LogoPath.SaveAs(path);
                    //News.HtmlContent = News.Make_HTTP_Request(News.WebsiteLink);
                    DBMS db = new DBMS();
                    bool ok = db.ExecuteInsertQuery(News);
                    ModelState.Clear();
                }
                return View();
            }
            else
            {
                //return View();
                return RedirectToAction("Index", "Login");
            }
        }


        [HttpGet]
        public ActionResult Calculator()
        {
            if (System.Web.HttpContext.Current.Session["Username"] != null)
            {
                return View();
            }
            else
            {
                //return View();
                return RedirectToAction("Index", "Login");
            }
        }



        [HttpGet]
        public ActionResult About()
        {
            if (System.Web.HttpContext.Current.Session["Username"] != null)
            {
                return View();
            }
            else
            {
               
                return RedirectToAction("Index", "Login");
            }
        }


        [HttpGet]
        public ActionResult Users()
        {
            if (System.Web.HttpContext.Current.Session["Username"] != null)
            {

                DBMS db = new DBMS();
                DataTable table = db.ExecuteSelectQuery("select * from user");

                List<User> Users = new List<User>();
                foreach (DataRow item in table.Rows)
                {
                    User User = new User();
                    User.UserName = item["username"].ToString();
                    User.IsAdmin = match(item["role"].ToString());
                    Users.Add(User);
                }
                    return View(Users);
            }
            else
            {
                //return View();
                return RedirectToAction("Index", "Login");
            }
        }

        bool match(string role)
        {
            if (role == "True")
                return true;
            else
                return false;
        }

        [HttpGet]
        public bool Permit(string Username , string Role)
        {
            DBMS db = new DBMS();
            bool ok = db.ExecuteUpdateQuery($" UPDATE user SET Role = '{Role}' WHERE username = '{Username}' ");
            return true;
        }
        
    }
}