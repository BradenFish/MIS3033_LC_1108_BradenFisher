using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MIS3033_LC_1108_BradenFisher.Data;
using MIS3033_LC_1108_BradenFisher.Models;

namespace MIS3033_LC_1108_BradenFisher.Controllers
{
    public class HomeController : Controller
    {
        StuDB db = new StuDB();

        public JsonResult DeleteStu(string id)// action, web api
        {
            Message mes;// complex
            mes = new Message();

            if (id == null)
            {
                mes.status = "fail";
                mes.message = "You need to provide an ID";
                return Json(mes);
            }

            id = id.Trim();// delete spaces at the beginning and end of the string

            if (id == "")
            {
                mes.status = "fail";
                mes.message = "You need to provide an ID";
                return Json(mes);
            }

            Student stu;// complex
            stu = db.Students.Where(x => x.Id.ToLower() == id.ToLower()).FirstOrDefault();

            if (stu == null)
            {
                mes.status = "fail";
                mes.message = $"Student ID {id} does not exist in the DB!";
                return Json(mes);


                db.Students.Remove(stu);// in computer memory
                db.SaveChanges();// persist save to the database file

            mes.status = "success";
            mes.message = "Student deleted successfully";

            return Json(mes);
        }

        public JsonResult EditStu(string id, string name, DateTime dob)
        {
            Student stu;// complex
            // stu = new Student();
            stu = db.Students.Where(x => x.Id == id).FirstOrDefault();
            // if there is any student in the result in the where, we are going to pick the first one
            // if not, return a null

            // stu.Id = id;// could not change the primary key
            stu.Name = name;
            // stu.DOB = dob.ToLocalTime();// 
            stu.DOB = dob.ToUniversalTime();// 

            //db.Students.Add(stu);
            db.SaveChanges();

            Message mes;// complex
            mes = new Message();

            mes.status = "success";
            mes.message = "Student edited successfully";

            return Json(mes);
        }

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
            var r = db.Students.Select(x => new { id = x.Id, name = x.Name, dob = x.DOB.ToString("MMMM dd, yyyy") });
            return Json(r);
        }

        public IActionResult Index()
        {
            return View();
        }
    }           
}
