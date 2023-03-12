using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Ali_Jameel.Models
{
    public class News
    {

        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string LogoName { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        public HttpPostedFileBase LogoPath { get; set; }

        [Required(ErrorMessage = "Please Enter Website Link.")]
        public string WebsiteLink { get; set; }

        public string HtmlContent { get; set; }

        public string PublishDate { get; set; } = DateTime.Now.ToString();

        public string Make_HTTP_Request(string url)
        {
            string html = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            return html;
        }


    }
}