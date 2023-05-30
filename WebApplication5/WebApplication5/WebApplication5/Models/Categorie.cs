using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
