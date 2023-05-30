using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models.ViewModel
{
    public class CreateProduitViewModel
    {
        public int ProduitId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Taille Max 50")]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Prix en dinar :")]
        public float Prix { get; set; }

        [Required]
        [Display(Name = "CategorieId :")]
        public int CategorieId { get; set; }

        [Required]
        [Display(Name = "Quantité en unité :")]
        public int Quantite { get; set; }

        [Required]
        [Display(Name = "Image :")]
        public IFormFile? ImagePath { get; set; }
    }
}
