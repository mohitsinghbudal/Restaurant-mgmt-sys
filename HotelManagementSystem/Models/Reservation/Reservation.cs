namespace HotelManagementSystem.Models.Reservation
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int guests { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int TableId { get; set; }
        public DateTime ReservationDateTime { get; set; }

    }
}
