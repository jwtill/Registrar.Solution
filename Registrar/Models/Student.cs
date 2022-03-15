using System.Collections.Generic;
namespace Registrar.Models
{
  public class Student
  {
    public Student()
    {
      this.JoinEntities = new HashSet<CourseStudent>();
    }
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string Date { get; set; }
    public virtual ICollection<CourseStudent> JoinEntities { get; set;}
    public virtual ICollection<StudentDepartment> JoinEntitiesStudentDepartment { get; set;}

  }
}