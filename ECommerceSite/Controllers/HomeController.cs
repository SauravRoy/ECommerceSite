using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonUtils;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;
using ECommerceSite.Models;
using Newtonsoft.Json;

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
