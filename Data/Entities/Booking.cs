using System.ComponentModel.DataAnnotations;

namespace QMS.Data.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public required string Service { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        public const int MaxBookingsPerDay = 10; // กำหนดจำนวนคิวสูงสุดต่อวัน
    }

}
