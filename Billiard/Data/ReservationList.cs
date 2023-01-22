using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Billiard.Data
{
    public class ReservationList
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual AppUser? User { get; set; }
        public string Title { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
        public ReservationList()
        {
            Reservations = new List<Reservation>();
        }
    }
}