using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace OnlineShopping.Controllers
{
    public class BuyNowController : Controller
    {
        private readonly ECommerceDbContext _context;
        public BuyNowController(ECommerceDbContext context)
        {
            _context = context;
        }

        public ActionResult BuyNow(int sno, string val)
        {
            //var total = 0;

           
            
        

            List<LaptopModel> lstOlddata = null;
            if (val == "Add")
            {
                LaptopModel model = new LaptopModel();

                var laptop = _context.Laptops.Where(s => s.Sno == sno).ToList();
                if (laptop.Count > 0)
                    model = laptop[0];

                lstOlddata = SessionHelper.GetObjectFromJson<List<LaptopModel>>(HttpContext.Session, "Placeorder");

                if (lstOlddata == null)
                    lstOlddata = new List<LaptopModel>();

                if (laptop.Count > 0)
                    lstOlddata.Add(model);



                SessionHelper.SetObjectAsJson(HttpContext.Session, "Placeorder", lstOlddata);
                // return View(lstOlddata);
            }
            else if (val == "Remove")
            {
                LaptopModel model = new LaptopModel();
                lstOlddata = SessionHelper.GetObjectFromJson<List<LaptopModel>>(HttpContext.Session, "Placeorder");

                if (lstOlddata.Count > 0)
                {
                    var lapmodellst = lstOlddata.Where(item => item.Sno == sno).ToList();
                    if (lapmodellst.Count > 0)
                    {
                        LaptopModel lapmodel = lapmodellst[0];
                        lstOlddata.Remove(lapmodel);
                    }
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "Placeorder", lstOlddata);


            }
            else
            {
                lstOlddata = SessionHelper.GetObjectFromJson<List<LaptopModel>>(HttpContext.Session, "Placeorder");

                if (lstOlddata == null)
                {
                    lstOlddata = new List<LaptopModel>();
                }

            }
            

            return View(lstOlddata);
            

        }

        public ActionResult Total(int sno)
        {
            LaptopModel model = new LaptopModel();
            List<LaptopModel> lstOlddata;
            lstOlddata = SessionHelper.GetObjectFromJson<List<LaptopModel>>(HttpContext.Session, "Placeorder");
            var total = lstOlddata.Where(c => c.Sno == sno)
                .Select(c => c.Price).Sum();
            return View(total);

        }

        //public IActionResult Total()
        //{
        //    private List<LaptopModel> _products = new List<LaptopModel>();
        //    public double TotalPrice { get; private set; }



        //    private void RecalculateTotalPrice()
        //    {
        //        var totalPrice = 0;
        //        foreach (var product in _products)
        //        {
        //        (totalPrice += product.Price);
        //        }
        //        TotalPrice = totalPrice;
        //    }
        //}




        public ActionResult ProceedToBuy(int sno)
        {
            string user = HttpContext.Session.GetString("LoginUser");
            if (string.IsNullOrEmpty(user))
            {
                TempData["ItemID"] = sno;
                return RedirectToAction("Login", "AddToCart");
            }
            else
            {
                LaptopModel model = new LaptopModel();

                var laptop = _context.Laptops.Where(s => s.Sno == sno).ToList();
                if (laptop.Count > 0)
                    model = laptop[0];

                List<LaptopModel> result = SessionHelper.GetObjectFromJson<List<LaptopModel>>(HttpContext.Session, "Placeorder");

                if (result == null)
                    result = new List<LaptopModel>();

                if (laptop.Count > 0)
                    result.Add(model);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "Placeorder", result);


                return RedirectToAction("Index","Address");
            }
        }

        
    }


    public static class SessionHelper
{
    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
}
}