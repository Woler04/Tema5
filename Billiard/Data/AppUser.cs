using Microsoft.AspNetCore.Identity;

namespace Billiard.Data
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public virtual List<ReservationList> ReservationList { get; set; }

        public AppUser()
        {
            ReservationList = new List<ReservationList>();
        }
    }
}
