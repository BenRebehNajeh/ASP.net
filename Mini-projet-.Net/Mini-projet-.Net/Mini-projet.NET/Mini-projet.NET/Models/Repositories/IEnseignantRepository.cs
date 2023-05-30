namespace projet.Models.Repositories
{
    public interface IEnseignantRepository
    {

        IList<Enseignant> GetAll();
        Enseignant GetById(int id);
        void Add(Enseignant c);
        void Edit(Enseignant c);
        void Delete(Enseignant c);
        void Delete(int id);
        void Update(int id, Enseignant newEnseignant);
        object FindByID(int id);
        
    }
}
