using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// import the Entities (database models representing structure of tables in database)
using PlacementTracker.Data.Entities; 

namespace PlacementTracker.Data.Repositories
{
    // The Context is How EntityFramework communicates with the database
    // We define DbSet properties for each table in the database
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        // authentication store
        public DbSet<User> Users { get; set; }
        public DbSet<ForgotPassword> ForgotPasswords { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }





        // Configure the context with logging - remove in production
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     // remove in production 
        //     optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();               
        // }

        //public static DbContextOptionsBuilder<DatabaseContext> OptionsBuilder => new ();

        // Convenience method to recreate the database thus ensuring the new database takes 
        // account of any changes to Models or DatabaseContext. ONLY to be used in development
        public void Initialise()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

    }
}
