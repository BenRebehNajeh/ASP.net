using WebApplication2.Models.ViewModels;


namespace WebApplication2.Models.ViewModels
{
    public class EditViewModel : CreateViewModel
    {
        public  int Id { get; set; }
        public string ExistingImagePath { get; set; }

    }
}
