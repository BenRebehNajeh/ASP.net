using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace projet.Models
{
    public class AppDbContext : DbContext
    {
        
            public AppDbContext (DbContextOptions <AppDbContext > options) : base (options)
                {
                }
                    public DbSet<Enseignant> Enseignants { get; set; }
                    public DbSet<Departement> Departements { get; set; }


    }
}
