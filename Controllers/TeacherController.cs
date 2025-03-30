using DemoCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoCRUD.Controllers
{
    public class TeacherController : Controller
    {
        TeacherModel teacher = new TeacherModel();
        public IActionResult Index()
        {
            teacher = new TeacherModel();
            List<TeacherModel> list = teacher.getData();

            return View(list);
        }
        public IActionResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeacher(TeacherModel Teach)
        {
            bool res;
            teacher = new TeacherModel();
            res =  teacher.Insert(Teach);
            if(res)
            {
                TempData["msg"] = "Data Added SuccessFully";
            }
            else
            {
                TempData["msg"] = "Please Enter Valid Value";
            }
            return View();
        }
        public IActionResult EditTeacher()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EditTeacher(string Id)
        {
            TeacherModel tech = teacher.getData(Id);
            return View(tech);
        }
        [HttpPost]
        public IActionResult EditTeacher(TeacherModel Tech)
        {
            bool res;
            teacher = new TeacherModel();
            res = teacher.update(Tech);
            if (res)
            {
                TempData["msg"] = "Data Updated SuccessFully";
            }
            else
            {
                TempData["msg"] = "Please Enter Valid Value";
            }
            return View();
        }
        public IActionResult DeleteTeacher()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeleteTeacher(string Id)
        {
            TeacherModel tech = teacher.getData(Id);
            return View(tech);
        }
        [HttpPost]
        public IActionResult DeleteTeacher(TeacherModel Tech)
        {
            bool res;
            teacher = new TeacherModel();
            res = teacher.delete(Tech);
            if (res)
            {
                TempData["msg"] = "Data Deleted SuccessFully";
            }
            else
            {
                TempData["msg"] = "Please Enter Valid Value";
            }
            return View();
        }
    }
}
