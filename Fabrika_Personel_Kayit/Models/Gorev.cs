using System.ComponentModel.DataAnnotations;

namespace Fabrika_Personel_Kayit.Models
{
    public class Gorev
    {
        public int Id { get; set; }
        [Display(Name = "Görev adı")]
        public string Name { get; set; }
        public List<Personel>? Personels { get; set; }
    }
}
