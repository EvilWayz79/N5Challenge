namespace N5Challenge.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public PermissionType PermissionType { get; set; }
        public Employee Employee { get; set; }
    }
}
