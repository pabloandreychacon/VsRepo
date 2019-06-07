using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class StoreController : Controller
    {
        ShoppingEntities storeDB = new ShoppingEntities();

        // GET: Store
        //public ActionResult Index()
        //{
        //    //var locations = new List<Location>
        //    //{
        //    //    new Location { Name = "Locat1"},
        //    //    new Location { Name = "Locat2"},
        //    //    new Location { Name = "Locat3"}
        //    //};
        //    //return View(locations);
        //    var locations = storeDB.Locations.ToList();
        //    return View(locations);
        //}
        public ActionResult Index()
        {
            // Get most popular albums
            var items = GetTopSellingItems(5);

            return View(items);
        }

        //
        // GET: /Store/
        //public string Index()
        //{
        //    return "Hello from Store.Index()";
        //}
        //
        // GET: /Store/Browse?location=l1
        //public string Browse(string location)
        //{
        //    string message = HttpUtility.HtmlEncode("Store.Browse, Location = " + location);
        //    return message;
        //}
        public ActionResult Browse(string location)
        {
            //var locationModel = new Location { Name = location };
            //return View(locationModel);
            // Retrieve Genre and its Associated Albums from database
            var locationModel = storeDB.Locations.Include("Items")
                .Single(g => g.Name == location);

            return View(locationModel);
        }
        //
        // GET: /Store/Details/5
        //public string Details(int id)
        //{
        //    string message = "Store.Details, ID = " + id;

        //    return message;
        //}
        public ActionResult Details(int id)
        {
            //var item = new Item { Name = "Item " + id };
            //return View(item);
            var item = storeDB.Items.Find(id);
            return View(item);
        }

        //
        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult LocationMenu()
        {
            var locations = storeDB.Locations.ToList();
            return PartialView(locations);
        }

        private List<Item> GetTopSellingItems(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return storeDB.Items
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }
    }
}