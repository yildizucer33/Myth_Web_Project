using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class MythCard
    {
        public int Id { get; set; }

        [Required]
        public string Baslik { get; set; } = string.Empty;

        [Required]
        public string Aciklama { get; set; } = string.Empty;

        [Required]
        public string ResimUrl { get; set; } = string.Empty;

        [Required]
        public string MitolojiTuru { get; set; } = string.Empty;
    }
}
