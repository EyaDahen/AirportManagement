using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Core.Domain;
using AM.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Data
{
    public class AMContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog = Airport;
                                        Integrated Security = true");

        }

        // override onmodel creating nekteb to tji hethii 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
              
            modelBuilder.ApplyConfiguration(new PlaneConfig() );

            //Methode 1 : namel classe de configuration w nayetlha akeya bel apply 
            modelBuilder.ApplyConfiguration(new FlightConfig()); 

            //Methode 2 : ou bien n7ot les configurations directement fel onmodelcreating
              /*  modelBuilder.Entity<Flight>()
                            .HasMany(f => f.Passengers)
                            .WithMany(p => p.Flights)
                            .UsingEntity(ass => ass.ToTable("FK"));

                modelBuilder.Entity<Flight>()
                            .HasOne(f => f.MyPlane)
                            .WithMany(p => p.Flights)
                            .HasForeignKey(f => f.PlaneId)
                            .OnDelete(DeleteBehavior.SetNull);
              */
        }

        //Pré convention est une regle ili tekhdem al les types prédefini moch sur les entitées 
        //lezem namlou ovveride lel configureConvention 
        //DateTime ->datetime2, datetime : ihbeha tawali date
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                                .HaveColumnType("date");
        }
    }
}
