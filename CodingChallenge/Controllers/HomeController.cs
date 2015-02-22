using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodingChallenge.Models;
using CodingChallenge.ViewModel;

namespace CodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        private CustomerEntities1 customer = new CustomerEntities1();
        public ActionResult Index()
        {
            return View();
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

     
       
        public ActionResult Showresults()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Showresults(FormCollection formCollection)
        {
           
            String radio = formCollection[0];
            String id = formCollection[1];
            
            CGI cgi = new CGI();

            if (radio == "customerId")
            {
                List<CustomerInfo> customerList = customer.CustomerInfoes.ToList();
                foreach (CustomerInfo item in customerList)
                {
                    if (item.Id.ToString() == id )
                    {
                        cgi.customerInfo = item;
                        
                    }
                }                

            }
            if (radio == "groupId")
            {
                List<GroupInfo> groupList = customer.GroupInfoes.ToList();
                foreach (GroupInfo item in groupList)
                {
                    
                    if (item.Id.ToString() == id)
                    {
                        cgi.groupInfo = item;
                        
                    }
                }

            }
            if (radio == "itemId")
            {
                List<ItemInfo> itemList = customer.ItemInfoes.ToList();
                foreach (ItemInfo item in itemList)
                {
                    if(item.Id.ToString() == id)
                    {
                        cgi.itemInfo = item;
                        
                    }
                }
            }

            return View(cgi);
        }
       
    }
}