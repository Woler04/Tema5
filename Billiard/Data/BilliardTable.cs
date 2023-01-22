using System.ComponentModel.DataAnnotations;

namespace Billiard.Data
{
    public class BilliardTable
    {
        [Key]
        public int Id { get; set; }
        public int Spaces { get; set; }
        public bool isForSmokers { get; set; }
    }
}
