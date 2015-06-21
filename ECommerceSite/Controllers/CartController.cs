using ECommerceSite.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSite.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var response = new HttpResponseMessage();
            OrderModel model = new OrderModel();
            Random random = new Random();
            model.OrderId = random.Next(1000);
            model.UserId = 1;

            model.Visible = false;

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new System.Uri(ConfigurationManager.AppSettings["ServiceBaseUrl"].ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync("api/Product/",HttpCompletionOption.ResponseHeadersRead).Result;
                var result = response.Content.ReadAsAsync<List<ProductModel>>();
                model.products = result.Result;

                //Keep it in Cache with cache dependency for future use
                HttpContext.Cache["ProductsCache"] = model.products;

            }

            return View(model);
        }

        public ActionResult CreateOrder(OrderModel model)
        {
            // create Order and redirect to OrderView Details 
            return null;
        }

        public ActionResult AddToCart(int Id)
        {
            List<ProductModel> prod = new List<ProductModel>();

            OrderModel model = new OrderModel();
            Random random = new Random();
            model.OrderId = random.Next(1000);
            model.UserId = 1;
            model.Visible = true;

            if (HttpContext.Cache["ProductsCache"] != null)
            {
                var cacheproducts = (List<ProductModel>)HttpContext.Cache["ProductsCache"];
                model.products = cacheproducts;

                prod.Add(cacheproducts.First(m => m.ID == Id));

            }

            model.SelectedProducts = prod;
            HttpContext.Cache["CartCache"] = prod;

            return View("Index",model);

        }

        public ActionResult RemoveFromCart(int Id)
        {
            OrderModel model = new OrderModel();
            Random random = new Random();
            model.OrderId = random.Next(1000);
            model.UserId = 1;
            model.Visible = true;
            var cacheproducts = new List<ProductModel>();

            if (HttpContext.Cache["CartCache"] !=null)
            {
                cacheproducts = (List<ProductModel>)HttpContext.Cache["CartCache"];
                cacheproducts.Remove(cacheproducts.First(m => m.ID == Id));
                
            }

            model.SelectedProducts = cacheproducts;
            model.products = (List<ProductModel>)HttpContext.Cache["ProductsCache"];


            return View("Index", model);
        }
    }
}