using System.Collections.Generic;

namespace RelationsRevisited.Models
{
    public class Skills
    {
        public int SkillsId { get; set; }
        public string SkillsDescription { get; set;}

        public virtual ICollection<Employee_Skills> Employees_Skills { get; set; }
    }
}
