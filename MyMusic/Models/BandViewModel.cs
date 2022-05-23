using System.ComponentModel.DataAnnotations;
namespace MyMusic.Models
{
    public class BandViewModel
    {
        public int ID { get; set; }
       
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public int IdArtista { get; set; }

        [Url]
        public string Immagine { get; set; }
        public string Genere { get; set; }
    }
}
