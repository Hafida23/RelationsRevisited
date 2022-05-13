namespace RelationsRevisited.Models
{
    public class EmployeeCv
    {
        public int EmployeeCvId { get; set; }
        public string Title { get; set; }
        public virtual Employee Employee { get; set; }


    }
}
