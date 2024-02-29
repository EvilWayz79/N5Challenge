using System.Security;

namespace N5Challenge.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
