using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        readonly AppDbContext context;
        public CategorieRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Categorie> GetAll()
        {
            return context.Categories.OrderBy(c => c.Nom).ToList();
        }
        public Categorie GetById(int id)
        {
            return context.Categories.Find(id);
        }
        public void Add(Categorie c)
        {
            context.Categories.Add(c);
            context.SaveChanges();
        }
        public void Edit(Categorie c)
        {
            Categorie c1 = context.Categories.Find(c.CategorieId);
            if (c1 != null)
            {
                c1.Nom = c.Nom;
                context.SaveChanges();
            }
        }
        public void Delete(Categorie c)
        {
            Categorie c1 = context.Categories.Find(c.CategorieId);
            if (c1 != null)
            {
                context.Categories.Remove(c1);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Categorie c1 = context.Categories.Find(id);
            if (c1 != null)
            {
                context.Categories.Remove(c1);
                context.SaveChanges();
            }
        }

        public void Update(int id, Categorie c)
        {
            Categorie c1 = context.Categories.Find(c.CategorieId);
            if (c1 != null)
            {
                c1.Nom = c.Nom;
                context.SaveChanges();
            }
        }

        public object FindByID(int id)
        {
            return context.Categories.Find(id);
        }



        public Categorie GetProduitsByCateg(string cat)
        {
            return context.Categories.Include("Produits")
            .Single(g => g.Nom == cat);
        }
    } }
