
using System.ComponentModel.DataAnnotations;
namespace MyMusic.Models
{
    public class BranoViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Titolo { get; set; }
        public string Band { get; set; }
        public string Album { get; set; }
        public int AnnoUscita { get; set; }
        public decimal Durata { get; set; }

        [StringLength(50)]
        public string Genere { get; set; }
    }
}
