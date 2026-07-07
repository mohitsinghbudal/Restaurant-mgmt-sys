namespace HotelManagementSystem.Models.FeedBack
{
    public class FeedBack
    {
        public string FeedBackId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int UserId { get; set; }
        public int sessionId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
