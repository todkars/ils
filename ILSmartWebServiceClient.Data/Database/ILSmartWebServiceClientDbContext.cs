using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ILSmartWebServiceClient.Data.Database
{
    public partial class ILSmartWebServiceClientDbContext : DbContext
    {
        public ILSmartWebServiceClientDbContext()
        {
        }

        public ILSmartWebServiceClientDbContext(DbContextOptions<ILSmartWebServiceClientDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ForcastDatum> ForcastData { get; set; } = null!;
        public virtual DbSet<Generaldto> Generaldtos { get; set; } = null!;
        public virtual DbSet<GwgVendor> GwgVendors { get; set; } = null!;
        public virtual DbSet<Procurementdto> Procurementdtos { get; set; } = null!;
        public virtual DbSet<ProcurementdtoTimeseries> ProcurementdtoTimeseries { get; set; } = null!;
        public virtual DbSet<SrvaDataTemp> SrvaDataTemps { get; set; } = null!;
        public virtual DbSet<SrvaDatum> SrvaData { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseNpgsql("Host=gwg-dev-database.cm27e8tq7lft.us-west-1.rds.amazonaws.com;Port=5432;Database=dev;User ID=binarytouch;Password=binarytouch;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ForcastDatum>(entity =>
            {
                entity.ToTable("forcast_data");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DlaForcastMonth).HasColumnName("dla_forcast_month");

                entity.Property(e => e.DlaForcastTotalValue).HasColumnName("dla_forcast_total_value");

                entity.Property(e => e.DlaForcastValue).HasColumnName("dla_forcast_value");

                entity.Property(e => e.DlaForcastYear).HasColumnName("dla_forcast_year");

                entity.Property(e => e.SrvaDataId).HasColumnName("srva_data_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.SrvaData)
                    .WithMany(p => p.ForcastData)
                    .HasForeignKey(d => d.SrvaDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("forcast_data_srva_data_id_fk");
            });

            modelBuilder.Entity<Generaldto>(entity =>
            {
                entity.HasKey(e => new { e.Nsn, e.Part })
                    .HasName("generaldto_pkey");

                entity.ToTable("generaldto");

                entity.Property(e => e.Nsn).HasColumnName("nsn");

                entity.Property(e => e.Part).HasColumnName("part");

                entity.Property(e => e.CompletedAt).HasColumnName("completed_at");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Schedulebcode).HasColumnName("schedulebcode");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<GwgVendor>(entity =>
            {
                entity.ToTable("gwg_vendors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cage)
                    .HasMaxLength(20)
                    .HasColumnName("cage");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.JoiningDate).HasColumnName("joining_date");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Vendor).HasColumnName("vendor");

                entity.Property(e => e.VendorTillDate).HasColumnName("vendor_till_date");
            });

            modelBuilder.Entity<Procurementdto>(entity =>
            {
                entity.ToTable("procurementdto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Awarddate).HasColumnName("awarddate");

                entity.Property(e => e.Cage).HasColumnName("cage");

                entity.Property(e => e.CompletedAt).HasColumnName("completed_at");

                entity.Property(e => e.Contractno).HasColumnName("contractno");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Nsn).HasColumnName("nsn");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Sos).HasColumnName("sos");

                entity.Property(e => e.Unitofmeasure).HasColumnName("unitofmeasure");

                entity.Property(e => e.Unitprice).HasColumnName("unitprice");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Vendor).HasColumnName("vendor");
            });

            modelBuilder.Entity<ProcurementdtoTimeseries>(entity =>
            {
                entity.ToTable("procurementdto_timeseries");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apicalldate).HasColumnName("apicalldate");

                entity.Property(e => e.Awarddate)
                    .HasMaxLength(10)
                    .HasColumnName("awarddate");

                entity.Property(e => e.Cage)
                    .HasMaxLength(10)
                    .HasColumnName("cage");

                entity.Property(e => e.CompletedAt).HasColumnName("completed_at");

                entity.Property(e => e.Contractno)
                    .HasMaxLength(50)
                    .HasColumnName("contractno");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Nsn)
                    .HasMaxLength(25)
                    .HasColumnName("nsn");

                entity.Property(e => e.Quantity)
                    .HasMaxLength(3)
                    .HasColumnName("quantity");

                entity.Property(e => e.Sos)
                    .HasMaxLength(5)
                    .HasColumnName("sos");

                entity.Property(e => e.Unitofmeasure)
                    .HasMaxLength(5)
                    .HasColumnName("unitofmeasure");

                entity.Property(e => e.Unitprice)
                    .HasMaxLength(10)
                    .HasColumnName("unitprice");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Vendor)
                    .HasMaxLength(50)
                    .HasColumnName("vendor");
            });

            modelBuilder.Entity<SrvaDataTemp>(entity =>
            {
                entity.ToTable("srva_data_temp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Column33)
                    .HasMaxLength(1)
                    .HasColumnName("column33");

                entity.Property(e => e.Fsc).HasColumnName("fsc");

                entity.Property(e => e.Itemdescription).HasColumnName("itemdescription");

                entity.Property(e => e.Niin).HasColumnName("niin");

                entity.Property(e => e.Nsn).HasColumnName("nsn");

                entity.Property(e => e.SrvaDataForMonth).HasColumnName("srva_data_for_month");

                entity.Property(e => e.Supplychain).HasColumnName("supplychain");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Ui).HasColumnName("ui");

                entity.Property(e => e._012023).HasColumnName("01_2023");

                entity.Property(e => e._012024).HasColumnName("01_2024");

                entity.Property(e => e._022023).HasColumnName("02_2023");

                entity.Property(e => e._022024).HasColumnName("02_2024");

                entity.Property(e => e._032023).HasColumnName("03_2023");

                entity.Property(e => e._032024).HasColumnName("03_2024");

                entity.Property(e => e._042023).HasColumnName("04_2023");

                entity.Property(e => e._042024).HasColumnName("04_2024");

                entity.Property(e => e._052023).HasColumnName("05_2023");

                entity.Property(e => e._052024).HasColumnName("05_2024");

                entity.Property(e => e._062022).HasColumnName("06_2022");

                entity.Property(e => e._062023).HasColumnName("06_2023");

                entity.Property(e => e._062024).HasColumnName("06_2024");

                entity.Property(e => e._072022).HasColumnName("07_2022");

                entity.Property(e => e._072023).HasColumnName("07_2023");

                entity.Property(e => e._082022).HasColumnName("08_2022");

                entity.Property(e => e._082023).HasColumnName("08_2023");

                entity.Property(e => e._092022).HasColumnName("09_2022");

                entity.Property(e => e._092023).HasColumnName("09_2023");

                entity.Property(e => e._102022).HasColumnName("10_2022");

                entity.Property(e => e._102023).HasColumnName("10_2023");

                entity.Property(e => e._112022).HasColumnName("11_2022");

                entity.Property(e => e._112023).HasColumnName("11_2023");

                entity.Property(e => e._122022).HasColumnName("12_2022");

                entity.Property(e => e._122023).HasColumnName("12_2023");
            });

            modelBuilder.Entity<SrvaDatum>(entity =>
            {
                entity.ToTable("srva_data");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompletedAt).HasColumnName("completed_at");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Fsc).HasColumnName("fsc");

                entity.Property(e => e.Itemdescription).HasColumnName("itemdescription");

                entity.Property(e => e.Niin).HasColumnName("niin");

                entity.Property(e => e.Nsn).HasColumnName("nsn");

                entity.Property(e => e.SrvaDataForMonth).HasColumnName("srva_data_for_month");

                entity.Property(e => e.Supplychain).HasColumnName("supplychain");

                entity.Property(e => e.Ui).HasColumnName("ui");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e._1).HasColumnName("1");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
