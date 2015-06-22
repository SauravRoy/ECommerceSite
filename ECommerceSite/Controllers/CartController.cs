using CommonUtils;
using ECommerceSite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;

namespace ECommerceSite.Controllers
{
    public class CartController : Controller
    {

        private readonly ILogger _logger;
        private readonly IMail _mail;

        public CartController(ILogger logger, IMail mail)
        {
            _logger = logger;
            _mail = mail;
        }

        // GET: Cart
        public ActionResult Index()
        {

            var response = new HttpResponseMessage();
            OrderModel model = new OrderModel();
            Random random = new Random();
            model.OrderId = random.Next(1000);
            model.UserId = 1;

            model.Visible = false;

            try
            {

                using (var client = new System.Net.Http.HttpClient())
                {
                    client.BaseAddress = new System.Uri(ConfigurationManager.AppSettings["ServiceBaseUrl"].ToString());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    response = client.GetAsync("api/Product/").Result;
                    var result = response.Content.ReadAsAsync<List<ProductModel>>();
                    model.products = result.Result;

                    //Keep it in Cache with cache dependency for future use
                    HttpContext.Cache["ProductsCache"] = model.products;

                }
                
            }
            catch(Exception ex)
            {
                _logger.LogMessage(ex);
            }

            return View(model);


        }

        public string CreateOrder([FromBody] OrderModel model)
        {
            var response = new HttpResponseMessage();


            model.products.Add(new ProductModel { ID = 1, Name = "XL 42 Levis T Shirt", Price = 500 });
            model.UserId = 1;
            

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new System.Uri(ConfigurationManager.AppSettings["ServiceBaseUrl"].ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.PostAsync("api/Order/", new
                {
                    model

                }, new JsonMediaTypeFormatter()).Result;


                //Notify User of Order Placed .
                _mail.Notify("");
            }

            return "Success";
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