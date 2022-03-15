using System.Collections.Generic;

namespace Registrar.Models
{
  public class Department
  {
    public Department()
    {
      this.JoinEntities = new HashSet<CourseStudent>();
    }
    public int DepartmentId { get; set; }
    public string Name {get; set;}
    public virtual ICollection<CourseStudent> JoinEntities {get;}
  }
}