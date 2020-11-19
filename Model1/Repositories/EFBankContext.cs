 using System;
using System.Collections.Generic;
using System.Text;
using Model1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Configuration;

namespace Model1.Repositories
{
    class EFBankContext : DbContext
    {
        public static IConfigurationRoot configuration;
        bool testMode = false;

        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Rekening> Rekeningen { get; set; }

        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging
            (
            builder => builder.AddConsole()
                              .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
            );
            return serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Pagina 103
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
                    , options => options.MaxBatchSize(150))
                // Max aantal SQL commands die kunnen doorgestuurd worden naar de database  
                                        .UseLoggerFactory(GetLoggerFactory())
                                        .EnableSensitiveDataLogging(true);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //---Klant---//
            modelBuilder.Entity<Klant>().ToTable("Klanten");
            modelBuilder.Entity<Klant>().HasKey(c => c.KlantId);

            //---Rekening---//
            modelBuilder.Entity<Rekening>().ToTable("Rekeningen");
            modelBuilder.Entity<Rekening>().HasKey(c => c.RekeningId);
            modelBuilder.Entity<Rekening>().Property(b => b.RekeningNr).HasMaxLength(19);
            modelBuilder.Entity<Rekening>().HasOne(b => b.Klant)
                                          .WithMany(c => c.Rekeningen)
                                          .HasForeignKey(b => b.KlantId);
            modelBuilder.Entity<Rekening>().HasIndex(b => new { b.RekeningNr })
                                           .IsUnique();
            { if (!testMode)
                {
                    //--Seeding Klant--//
                    modelBuilder.Entity<Klant>().HasData
                        (
                    new Klant
                         { KlantId = 1, Naam = "Marge"},
                    new Klant
                        { KlantId = 2, Naam = "Homer"},
                    new Klant
                        { KlantId = 3, Naam = "Lisa"},
                    new Klant
                        { KlantId = 4, Naam = "Maggie"},
                    new Klant
                        { KlantId = 5, Naam = "Bart"}
                    );

                    modelBuilder.Entity<Rekening>().HasData
                        (
                        new Rekening
                        {
                            RekeningId = 1,
                            RekeningNr = "BE68 1234 5678 9012",
                            KlantId = 1,
                            Saldo = 1000,
                            Soort = 'Z'
                        },
                        new Rekening
                        {
                            RekeningId = 2,
                            RekeningNr = "BE68 2345 6789 0169",
                            KlantId = 1,
                            Saldo = 2000,
                            Soort = 'S'
                        },
                        new Rekening
                        {
                            RekeningId = 3,
                            RekeningNr = "BE68 3456 7890 1212",
                            KlantId = 2,
                            Saldo = 500,
                            Soort = 'S'
                        }
                        );
                }
            }
        }
    } 
}
