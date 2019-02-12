using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using WebApplicationEpicTest.Models;

namespace WebApplicationEpicTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Products> products = new List<Products>();

            //Load the XML file in XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/App_Data/inventory.xml"));

            //Loop through the selected Nodes.
            foreach (XmlNode node in doc.SelectNodes("/inventory/products/product"))
            {
                //Fetch the Node values and assign it to Model.
                products.Add(new Products
                {
                    Name =  node.Attributes["name"].InnerText,
                    Price = decimal.Parse(node.Attributes["price"].InnerText),
                    Qty = int.Parse(node.Attributes["qty"].InnerText)
                });
            }

            var productsSorted = products.OrderBy(f => f.Name).Take(5);

            return View(productsSorted);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}