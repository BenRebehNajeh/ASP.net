using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models.Repositories
{
    public class ProduitsRepository:IProduitsRepository
    {
        readonly AppDbContext context;
        public ProduitsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Produit> GetAll()
        {
            return context.Produits.OrderBy(p => p.Nom).ToList();

        }
        public Produit GetById(int id)
        {
            return context.Produits.Find(id);

        }
        public void Add(Produit p)
        {
            context.Produits.Add(p);
            context.SaveChanges();
        }
        public void Edit(Produit p)
        {
            Produit p1 = context.Produits.Find(p.ProduitId);
            if (p1 != null)
            {
                p1.Nom = p.Nom;
                p1.Prix = p.Prix;
                p1.CategorieId = p.CategorieId;
                p1.Quantite = p.Quantite;
                p1.Image = p.Image;
                context.SaveChanges();
            }
        }
        public void Delete(Produit p)
        {
            Produit p1 = context.Produits.Find(p.ProduitId);
            if (p1 != null)
            {
                context.Produits.Remove(p1);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Produit p1 = context.Produits.Find(id);
            if (p1 != null)
            {
                context.Produits.Remove(p1);
                context.SaveChanges();
            }
        }

        public object FindByID(int id)
        {
            return context.Produits.Find(id);

        }

        public void Update(int id, Produit p)
        {
            Produit p1 = context.Produits.Find(p.ProduitId);
            if (p1 != null)
            {
                p1.Nom = p.Nom;
                p1.Prix = p.Prix;
                p1.CategorieId = p.CategorieId;
                p1.Quantite = p.Quantite;
                p1.Image = p.Image;
                context.SaveChanges();
            }
        }

        public Produit Update(Produit produit)
        {
            var Produits = context.Produits.Attach(produit);
            Produits.State = EntityState.Modified;
            context.SaveChanges();
            return produit;
        }

    }
}
