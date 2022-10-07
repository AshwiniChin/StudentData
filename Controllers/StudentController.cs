using Microsoft.AspNetCore.Mvc;
using StudentData.Data;
using StudentData.Models;

namespace StudentData.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;
        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _db.Students.ToList();
            return View(objStudentList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        public IActionResult Create(Student obj)
        {
            _db.Students.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get
        public IActionResult Delete(int? id)
        {
           if(id == null || id == 0)
            {
                return NotFound();
            }
           var studentFromDb = _db.Students.Find(id);
            if(studentFromDb == null)
            {
                return NotFound();
            }
                return View(studentFromDb);
        }
        //post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Students.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentFromDb = _db.Students.Find(id);
            if (studentFromDb == null)
            {
                return NotFound();
            }
            return View(studentFromDb);
        }
        //post
        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            _db.Students.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
