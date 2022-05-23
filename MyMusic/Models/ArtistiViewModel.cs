using System.ComponentModel.DataAnnotations;
namespace MyMusic.Models
{
    public class ArtistiViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }


        [StringLength(50)]
        public string Cognome { get; set; }
        
        [StringLength(50)]
        public string NomeArte { get; set; }

        [StringLength(50)]
        public string Tipo { get; set; }


    }
}
