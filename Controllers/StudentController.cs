using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using System.Collections.Generic;
using enexiongroup.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace enexiongroup.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration configuration;
        StudentLog db;
        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new StudentLog(this.configuration);
        }
        
        
        public IActionResult LoginDetails()
        {
            return View();
        }   

        [HttpPost]
        public IActionResult LoginDetails(Login log)
        {

            try
            {
                int res = db.UserDetails(log);
                if (res > 0)
                {
                    ViewBag.SuccessMessage = "Submitted Successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("Something went wrong");
                    return View();
                }

            }
            catch
            {
                ViewBag.ErrorMessage = "Something went wrong";
                return View();
            }

        }


        public IActionResult Index()
        {
            List<Login> logList = db.UserList();
            return View(logList);
        }
    }
}

