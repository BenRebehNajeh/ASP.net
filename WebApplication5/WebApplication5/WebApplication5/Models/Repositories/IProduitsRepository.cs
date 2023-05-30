namespace WebApplication5.Models.Repositories
{
    public interface IProduitsRepository
    {
        IList<Produit> GetAll();
        Produit GetById(int id);
        void Add(Produit p);
        void Edit(Produit p);
        void Delete(Produit p);
        object FindByID(int id);
        void Update(int id, Produit newProduit);
        void Delete(int id);
        Produit Update(Produit produit);
    }
}
