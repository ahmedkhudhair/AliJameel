using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ali_Jameel.Models;
using System.Data;
using System.IO;

namespace Ali_Jameel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Vendors()
        {
            DBMS db = new DBMS();
            DataTable table = db.ExecuteSelectQuery("select * from vendor");

            List<Vendor> Vendors = new List<Vendor>();
            foreach (DataRow item in table.Rows)
            {
                Vendor Vendor = new Vendor();
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


        [HttpGet]
        public ActionResult CreateVendors()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateVendors(Vendor vendor)
        {

            DBMS db = new DBMS();

            var filename = Path.GetFileName(vendor.LogoPath.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Logos/"), filename);
            vendor.LogoPath.SaveAs(path);

            bool ok = db.ExecuteInsertQuery($" insert into vendor (CompanyName,CompanyLogo) values ('{vendor.CompanyName}' ,'{vendor.LogoPath.FileName}')");
            return View();
        }


        [HttpGet]
        public ActionResult News()
        {
            return View();
        }


        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        //public ActionResult Login()
        //{
        //    return View();
        //}




    }
}