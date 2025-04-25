namespace DataMgmtModule.Application.Features.RolePermissions.DTOs
{
    public class RolePermissionDto
    {
        public int? RoleId { get; set; }
        public string ModuleName { get; set; }
        public bool CanView { get; set; }
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}
