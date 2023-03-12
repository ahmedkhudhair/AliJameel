using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ali_Jameel.Models
{
    public class Vendor
    {
        public int ID { get; set; }

        public string CompanyName { get; set; }

        public string LogoName { get; set; }

        public HttpPostedFileBase LogoPath { get; set; }

        public string  CompanyURL { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string  ContactNumber { get; set; }
    }
}