namespace WebApplication5.Models.Repositories
{
    public interface ICategorieRepository
    {
        IList<Categorie> GetAll();
        void Add(Categorie c);
        void Edit(Categorie c);
        void Delete(Categorie c);
        void Delete(int id);
        void Update(int id, Categorie newCategorie);
        object FindByID(int id);
    }
}
