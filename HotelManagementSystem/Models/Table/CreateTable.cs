namespace HotelManagementSystem.Models.Table
{
    public class CreateTable
    {
        public int Capacity { get; set; }
        public int TableNo { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
    }
}
