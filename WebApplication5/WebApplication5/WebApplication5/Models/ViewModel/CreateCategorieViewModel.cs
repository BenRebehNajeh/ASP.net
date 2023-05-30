using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models.ViewModel
{
    public class CreateCategorieViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }
    }
}
