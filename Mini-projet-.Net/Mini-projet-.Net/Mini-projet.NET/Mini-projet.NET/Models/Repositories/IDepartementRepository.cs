using System.Collections;

namespace projet.Models.Repositories
{
    public interface IDepartementRepository
    {
        IList<Departement> GetAll();
        void Add(Departement c);
        void Edit(Departement c);
        void Delete(Departement c);
        void Delete(int id);
        void Update(int id, Departement newDepartement);
        object FindByID(int id);
    }
}
