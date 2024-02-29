using System.ComponentModel.DataAnnotations;
using System.Security;

namespace N5Challenge.Models
{
    public class Employee
    {
        [Display(Name ="Employee ID")]
        public int EmployeeId { get; set; }

        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Display(Name = "Employee Permissions")]
        public ICollection<Permission> Permissions { get; set; }
    }
}
