using System.ComponentModel.DataAnnotations;

namespace Billiard.Data
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public string ReserverId { get; set; }
        public virtual AppUser? Reserver { get; set; }
        public string BilliardTableId { get; set; }
        public virtual BilliardTable? BilliardTable { get; set; }
        public string ReservationDescription { get; set; }
        public DateTime ReservationTime { get; set; }
        public virtual ReservationList? ReservationList { get; set; }
    }
}