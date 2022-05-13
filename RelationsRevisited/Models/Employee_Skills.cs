namespace RelationsRevisited.Models
{
    public class Employee_Skills
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int SkillsId { get; set; }
        public virtual Skills Skills { get; set; }
    }
}
