using Microsoft.AspNetCore.Mvc;
using MIS3033_LC_1108_BradenFisher.Data;
using MIS3033_LC_1108_BradenFisher.Models;

namespace MIS3033_LC_1108_BradenFisher.Controllers
{
    public class HomeController : Controller
    {
        StuDB db = new StuDB();

        public JsonResult AddStu(string id, string name, DateTime dob)
        {
            Student stu;// complex
            stu = new Student();
            stu.Id = id;    
            stu.Name = name;
            //stu.DOB = dob.ToLocalTime();// 
            stu.DOB = dob.ToUniversalTime();// 

            db.Students.Add(stu);
            db.SaveChanges();

            Message mes;// complex
            mes = new Message();

            return Json(mes);
        }

        public JsonResult GetStus()
        {
            var r = db.Students;
            return Json(r);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
