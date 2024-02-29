using System.ComponentModel.DataAnnotations;

namespace N5Challenge.Models
{
    public class Permission
    {
        [Display(Name = "Permission Id")]
        public int PermissionId { get; set; }

        [Display(Name = "Permission Name")]
        public string Name { get; set; }


        
        public PermissionType PermissionType { get; set; }
        
        public Employee Employee { get; set; }
    }
}
