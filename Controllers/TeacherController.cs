using DemoCRUD.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
