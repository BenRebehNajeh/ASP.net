using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Produit
    {
        
            public int ProduitId { get; set; }


            [Required]
            [Display(Name = "Nom de produit :")]
            public String Nom { get; set; }

            [Required]
            [Display(Name = "Prix en Dinars :")]
            public float Prix { get; set; }


            [Required]
            [Display(Name = "Catégorie")]
            public int CategorieId { get; set; }
            public Categorie Categorie { get; set; }

            [Required]
            [Display(Name = "Quantité en unité :")]
            public int Quantite { get; set; }

            [Required]
            [Display(Name = "Image :")]
            public string Image { get; set; }
        }
    }

