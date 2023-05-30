using Microsoft.EntityFrameworkCore;

namespace projet.Models.Repositories
{
    public class EnseignantRepository : IEnseignantRepository
    {
        readonly AppDbContext context;
        public EnseignantRepository(AppDbContext context)
        {
            this.context = context;
        }


        public IList<Enseignant> GetAll()
        {
            return context.Enseignants.OrderBy(c => c.Nom).ToList();
        }
        public Enseignant GetById(int id)
        {
            return context.Enseignants.Find(id);
        }
        public void Add(Enseignant c)
        {
            context.Enseignants.Add(c);
            context.SaveChanges();
        }
        public void Edit(Enseignant c)
        {
            Enseignant c1 = context.Enseignants.Find(c.Id);
            if (c1 != null)
            {
                c1.Nom = c.Nom;
                context.SaveChanges();
            }
        }
        public void Delete(Enseignant c)
        {
            Enseignant c1 = context.Enseignants.Find(c.Id);
            if (c1 != null)
            {
                context.Enseignants.Remove(c1);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Enseignant c1 = context.Enseignants.Find(id);
            if (c1 != null)
            {
                context.Enseignants.Remove(c1);
                context.SaveChanges();
            }
        }

        public void Update(int id, Enseignant c)
        {
            Enseignant c1 = context.Enseignants.Find(c.Id);
            if (c1 != null)
            {
                c1.Nom = c.Nom;
                context.SaveChanges();
            }
        }

        public object FindByID(int id)
        {
            return context.Enseignants.Find(id);
        }



        public Enseignant GetProduitsByCateg(string cat)
        {
            return context.Enseignants.Include("Enseignant")
            .Single(g => g.Nom == cat);
        }

 
    }
}
