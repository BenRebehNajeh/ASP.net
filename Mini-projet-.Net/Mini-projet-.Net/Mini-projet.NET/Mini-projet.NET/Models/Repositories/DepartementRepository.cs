
using Microsoft.EntityFrameworkCore;

namespace projet.Models.Repositories
{
    public class DepartementRepository : IDepartementRepository
    {
        readonly AppDbContext context;

        public DepartementRepository(AppDbContext context)
        {
            this.context = context;
        } 
        public IList<Departement> GetAll()
        {
            return context.Departements.OrderBy(c => c.Name).ToList();
        }
        public Departement GetById(int id)
        {
            return context.Departements.Find(id);
        }
        public void Add(Departement c)
        {
            context.Departements.Add(c);
            context.SaveChanges();
        }
        public void Edit(Departement c)
        {
            Departement c1 = context.Departements.Find(c.ID);
            if (c1 != null)
            {
                c1.Name = c.Name;
                context.SaveChanges();
            }
        }
        public void Delete(Departement c)
        {
            Departement c1 = context.Departements.Find(c.ID);
            if (c1 != null)
            {
                context.Departements.Remove(c1);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Departement c1 = context.Departements.Find(id);
            if (c1 != null)
            {
                context.Departements.Remove(c1);
                context.SaveChanges();
            }
        }

        public void Update(int id, Departement c)
        {
            Departement c1 = context.Departements.Find(c.ID);
            if (c1 != null)
            {
                c1.Name = c.Name;
                context.SaveChanges();
            }
        }

        public object FindByID(int id)
        {
            return context.Departements.Find(id);
        }



        public Departement GetProduitsByCateg(string cat)
        {
            return context.Departements.Include("Enseignant")
            .Single(g => g.Name == cat);
        }

    }
}
