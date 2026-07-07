namespace HotelManagementSystem.Models.Roles
{
    public class Role
    { 
        public string RoleName { get; set; } = string.Empty;
        public int RoleId { get; set; }

        public bool IsActive { get; set; } = true;
        public string? Description { get; set; }
    }
}
