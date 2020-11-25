using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TransportCompanyMVCApp.Models;

#nullable disable

namespace TransportCompanyMVCApp
{
    public partial class TransportCompanyContext : DbContext
    {
        public TransportCompanyContext()
        {
        }

        public TransportCompanyContext(DbContextOptions<TransportCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarBrand> CarBrands { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<CargoType> CargoTypes { get; set; }
        public virtual DbSet<Fligt> Fligts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-4LIUQAR;Database=TransportCompany;Trusted_Connection=True;");
            }
        }
    }
}
