using System.ComponentModel.DataAnnotations;

namespace N5Challenge.Models
{
    public class PermissionType
    {
        [Display(Name = "Permission Type ID")]
        public int PermissionTypeId { get; set; }

        [Display(Name = "Permission Type Name")]
        public string Name { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
