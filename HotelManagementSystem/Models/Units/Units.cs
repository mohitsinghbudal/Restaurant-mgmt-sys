namespace HotelManagementSystem.Models.Units
{
    public class Unit
    {
        public int UnitId { get; set; } 
        public string UnitName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ShortName { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
