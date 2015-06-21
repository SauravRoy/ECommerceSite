using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using learningMVC.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace learningMVC.Controllers
{
    public class HomeController : Controller
    {
        public ILogger _Logger { get; set; }

        
        public HomeController(ILogger logger)
        {
            _Logger = logger;
        }

        public int Age { get; set; } =50;


        public void PrintLine() => Console.WriteLine(Age.ToString());

        [RequireHttps]
        public ActionResult Index()
        {

            ViewBag.Name = "Saurav";
            // Create a DataCacheFactoryConfiguration object

            int[] a = new int[] { 1, 2, 3, 4, 5 };
            a.Where(m => m % 2 == 2);

            List<int> test = new List<int>();



                List<Employee> emp = new List<Employee>();
                Employee emp1 = new Employee { Age = 23, DOB = DateTime.Today, Name = "Saurav" };
                Employee emp2 = new Employee { Age = 25, DOB = DateTime.Today, Name = "Rohit" };
                Employee emp3 = new Employee { Age = 33, DOB = DateTime.Today, Name = "Shyam" };
                Employee emp5 = new Employee { Age = 40, DOB = DateTime.Today, Name = "Akshay" };
                Employee emp4 = new Employee { Age = 50, DOB = DateTime.Today, Name = "Bilal" };


                emp.Add(emp1);
                emp.Add(emp2);
                emp.Add(emp3);
                emp.Add(emp4);
                emp.Add(emp5);





            return View(emp);
            

        }


        public ActionResult Create()
        {

           
            return PartialView("~/Views/Home/CreateEmployee.cshtml");

        }

        public ActionResult Chat()
        {


            return View();

        }


        public JsonResult getData()
        {
           string str= " [{'Name' : 'Paris spécialités','City' : 'Paris','Country' : 'France'}]";
            
            return Json(str,JsonRequestBehavior.AllowGet);
              
        }


        public ActionResult reporttype(int year,int month,int day)
        {

            return null;
        }


        [Authorize(Roles = ("User"))]
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