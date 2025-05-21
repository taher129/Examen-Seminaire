using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using static Azure.Core.HttpHeader;
using System.Collections;
using System.Numerics;
using Examen.Infrastructure.Configurations;

namespace Examen.Infrastructure
{
    public class ExamContext: DbContext
    {
        //DBSET

        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Industriel> Industriels { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Seminaire> Seminaires { get; set; }
        public DbSet<Specialite> Specialites { get; set; }
        public DbSet<Universitaire> Universitaires { get; set; }


        //OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=TaherEzzineARCTIC6;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");

            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        //FluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new InscriptionConfig());

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    if (property.ClrType == typeof(string))
                    {
                        property.SetMaxLength(100);
                    }
                }
            }
            modelBuilder.Entity<Participant>()
                .HasDiscriminator<char>("TypeParticipant")
                .HasValue<Participant>('P')       
                .HasValue<Universitaire>('U')
                .HasValue<Industriel>('I');
            base.OnModelCreating(modelBuilder);
        }

        //Conventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
