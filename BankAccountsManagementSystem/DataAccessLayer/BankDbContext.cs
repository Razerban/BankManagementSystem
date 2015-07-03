using System.Data.Entity;
using BankAccountsManagementSystem.Models;

namespace BankAccountsManagementSystem.DataAccessLayer
{
    public class BankDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Banque> Banque { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<PersonneMorale> PersonnesMorales { get; set; }
        public DbSet<PersonnePhysique> PersonnesPhysiques { get; set; }


    }
}