using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verdant.Zero.Erp.Api.DataModel.Entities;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Utilities;

namespace Verdant.Zero.Erp.Api.Data.EntityFramework
{
    public class ZeroErpManagementDatabase : DbContext
    {
        private string _connectionString;

        //public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<TaxAndPaymentDetails> TaxAndPayments { get; set; }


        public ZeroErpManagementDatabase(DbContextOptions<ZeroErpManagementDatabase> options) : base(options) {
            this.Database.EnsureCreated();
                }

        public ZeroErpManagementDatabase() { }

        public ZeroErpManagementDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("Connecting to Database = " + _connectionString);
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                ConnectionStrings connectionStrings = ConfigurationUtility.GetConnectionStrings();
                string databaseConnectionString = connectionStrings.PrimaryDatabaseConnectionString;
                optionsBuilder.UseMySQL(databaseConnectionString);
            }
            else
            {
                optionsBuilder.UseMySQL(_connectionString);
            }


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.EmailAddress).IsUnique();

            //modelBuilder.Entity<Match>()
            //       .HasRequired(m => m.HomeTeam)
            //       .WithMany(t => t.HomeMatches)
            //       .HasForeignKey(m => m.HomeTeamId)
            //       .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Match>()
            //            .HasRequired(m => m.GuestTeam)
            //            .WithMany(t => t.AwayMatches)
            //            .HasForeignKey(m => m.GuestTeamId)
            //            .WillCascadeOnDelete(false);



        }
    }
}
