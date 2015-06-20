using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonUtils;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace ECommerceSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        private readonly ILogger _logger;
        private readonly IMail _mail;

        public HomeController(ILogger logger,IMail mail)
        {
            _logger = logger;
            _mail = mail;
        }

        public ActionResult AddToCart()
        {
            return null;
        }
        public ActionResult Index()
        {
            var response = new HttpResponseMessage();

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new System.Uri(ConfigurationManager.AppSettings["ServiceBaseUrl"].ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = client.GetAsync("api/Product/").Result;

                
            }
            return View(response.Content);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
