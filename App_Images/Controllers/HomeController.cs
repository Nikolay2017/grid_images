using App_Images.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace App_Images.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index1()
        {
            List<ImageEx> list = new List<ImageEx>();
            Double width_All = 1000;
            double sum_otn = 0;
            double height = 0;

            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\pisarevno\source\repos\App_Images\App_Images\images");
            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {
                var imgItem = Image.FromFile(file.FullName);
                sum_otn = sum_otn + Convert.ToDouble(imgItem.Width) / Convert.ToDouble(imgItem.Height);
            }
            height = width_All / sum_otn;
            double sum = 0;
            foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
            {
                var imgItem = Image.FromFile(file.FullName);
                list.Add(new ImageEx { img= imgItem, NameImg =file.Name, heightImg=height, widthImg= Convert.ToDouble(imgItem.Width) * height/ Convert.ToDouble(imgItem.Height) });
                sum = sum + Convert.ToDouble(imgItem.Width) * height / Convert.ToDouble(imgItem.Height);
            }

            return View(list);
        }


        
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }
    }
}