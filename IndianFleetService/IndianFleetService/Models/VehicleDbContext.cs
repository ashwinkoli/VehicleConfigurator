using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Identity.Client;
using System;

namespace VehicleConfigurator.Model
{
    public class VehicleDbContext : DbContext, IDesignTimeDbContextFactory<VehicleDbContext>
    {
        public VehicleDbContext()
        {

        }
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=VehicleDb;Integrated Security=True");
            
        }

       

            public VehicleDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<VehicleDbContext>();

                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=VehicleDb;Integrated Security=True");

                return new VehicleDbContext(optionsBuilder.Options);
            }

            public DbSet<AlternateComponentMaster> AlternateComponentMasters { get; set; }
        public DbSet<ComponentMaster> ComponentMasterMasters { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetailMasters { get;set; }
        public DbSet<InvoiceHeader> InvoiceHeaderMasters { get;set; }
        public DbSet<MfgMaster> MfgMasters { get; set; }
        public DbSet<ModelMaster> ModelMasterMasters { get; set; }
        public DbSet<SegmentMaster> SegmentMasterMasters { get;set; }
        public DbSet<UserData> UserDataMasters { get;set; }
        public DbSet<VehicleDetail> VehicleDetailMasters { get; set; }

    }
}
