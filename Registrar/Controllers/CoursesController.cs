using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq;

namespace Registrar.Models
{
  public class CoursesController : Controller
  {
  private readonly RegistrarContext _db;
  public CoursesController(RegistrarContext db)
  {
    _db = db;
  }
  public ActionResult Index()
  {
    List<Course> model = _db.Courses.ToList();
    return View(model);
  }
  public ActionResult Create()
  {
    ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "Name");
    return View();
  }
  [HttpPost]
  public ActionResult Create(Course course, int DepartmentId)
  {
    _db.Courses.Add(course);
    _db.SaveChanges();
    if (DepartmentId != 0)
      {
        _db.CourseDepartment.Add(new CourseDepartment() {DepartmentId = DepartmentId, CourseId = course.CourseId } );
        _db.SaveChanges();
      }
    return RedirectToAction("Index");
  }
  public ActionResult Details(int id)
  {
    var thisCourse = _db.Courses
      .Include(course => course.JoinEntities)
      .ThenInclude(join => join.Student)
      .FirstOrDefault(course => course.CourseId == id);
    return View(thisCourse);
  }
  }
}