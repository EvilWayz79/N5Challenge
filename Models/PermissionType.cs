namespace N5Challenge.Models
{
    public class PermissionType
    {
        public int PermissionTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
