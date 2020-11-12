using System;
using System.Collections.Generic;
using System.Text;
using Model1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Model1.Repositories
{
    class EFBankContext : DbContext
    {
        public static IConfigurationRoot configuration;

        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Rekening> Rekeningen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Zoek de naam in de connectionStrings section - appsettings.json    
            configuration = new ConfigurationBuilder()     
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)     
                .AddJsonFile("appsettings.json", false)     
                .Build(); 

            var connectionString = configuration.GetConnectionString("efbank");

            if (connectionString != null)   // Indien de naam is gevonden    
            {     
                optionsBuilder.UseSqlServer(      
                    connectionString       
                    , options => options.MaxBatchSize(150));   
                // Max aantal SQL commands die kunnen doorgestuurd worden naar de database    
            }   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //---Klant---//
            modelBuilder.Entity<Klant>().ToTable("Rekeningen");
            modelBuilder.Entity<Klant>().HasKey(c => c.Rekeningen);

           //---Rekening---//
            modelBuilder.Entity<Rekening>().ToTable("Rekeningen");
            modelBuilder.Entity<Rekening>().HasKey(c => c.RekeningId);
            modelBuilder.Entity<Rekening>().Property(b => b.RekeningNr).HasMaxLength(19);
            modelBuilder.Entity<Rekening>().HasOne(b => b.Klant)
                                          .WithMany(c => c.Rekeningen)
                                          .HasForeignKey(b => b.KlantId);
            modelBuilder.Entity<Rekening>().HasIndex(b => new { b.RekeningNr })
                                           .IsUnique(); 
        }
    } 
}
