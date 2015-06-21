using System.Web.Mvc;
using ECommerceSite.Models;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using CommonUtils;
using System.Configuration;
using System.Net.Http.Formatting;
using System.Web.Security;

namespace ECommerceSite.Controllers
{
    public class LogOnController : Controller
    {
        // GET: LogOn

        private readonly ILogger _logger;
        private readonly IMail _mail;

        // Constructor injection using Unity IOC
        public LogOnController(ILogger logger, IMail mail)
        {
            _logger = logger;
            _mail = mail;
        }

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult AuthUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var response = new HttpResponseMessage();

                using (var client = new System.Net.Http.HttpClient())
                {
                    client.BaseAddress = new System.Uri(ConfigurationManager.AppSettings["ServiceBaseUrl"].ToString());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    response = client.GetAsync("api/auth/" + model.UserName).Result;


                }

                if (response.IsSuccessStatusCode)
                {
                   return Json(Url.Action("Index", "Home"));
                    
                }
                else
                    return Json("Failed", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View();
            }





        }


        public ActionResult ForgotPassword(UserModel model)
        {
            return View();
        }


        
        public ActionResult NewRegistration(UserModel model)
        {
            if(ModelState.IsValid)
            {
                var response = new HttpResponseMessage();

                using (var client = new System.Net.Http.HttpClient())
                {
                    client.BaseAddress = new System.Uri(ConfigurationManager.AppSettings["ServiceBaseUrl"].ToString());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    response = client.PostAsync("api/auth/", new
                    {
                        UserName = model.UserName,
                        Password = model.Password,
                        Email = model.Email,
                        Status=1
                    }, new JsonMediaTypeFormatter()).Result;


                }

                if (response.IsSuccessStatusCode)
                {
                    //Calling asynchronoulsy as its fire and forget task .
                    Task.Run(() => _mail.SendMail(model.Email,model.Password));
                    return RedirectToAction("Index", "Home");
                }
                else
                    return Json("Failed", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View();
            }
            


            
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {

            return null;
        }


    }
}