namespace HotelManagementSystem.Models.Categories
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsAvailable { get; set; } = true; 
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public int DisplayOrder { get; set; }

    }
}
