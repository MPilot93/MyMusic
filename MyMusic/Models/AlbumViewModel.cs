using System.ComponentModel.DataAnnotations;
namespace MyMusic.Models
  
{
    public class AlbumViewModel
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Titolo { get; set; }
        
        [Required]
        public int IdBrani { get; set; }

        [Required] public int IdBand { get; set; }
        public int AnnoUscita { get; set; }
    }
}
