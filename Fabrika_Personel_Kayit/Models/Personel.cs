using System.ComponentModel.DataAnnotations;

namespace Fabrika_Personel_Kayit.Models
{
    public class Personel
    {
        public int Id { get; set; }

        [Display(Name = "Personel adı")]
        [Required(ErrorMessage = "Personel Adı Gerekli")]
        public string? Name { get; set; }

        [Display(Name = "Personel soyadı")]
        [Required(ErrorMessage = "Personel soyadı Gerekli")]
        public string? SurName { get; set; }

        [Display(Name = "Personel Fotoğrafı")]
        public string? Photo { get; set; }

        [Display(Name = "Personel Maaşı")]
        [Required(ErrorMessage = "Personel Maaşı Gerekli")]
        public decimal Maas { get; set; }

        [Display(Name = "Personel TC'si")]
        [Required(ErrorMessage = "Personel TC'si Gerekli")]
        public string? TCNo { get; set; }


        [Display(Name = "Görevi")]
        public Gorev? Gorev { get; set; }
        public int GorevId { get; set; }
    }
}
