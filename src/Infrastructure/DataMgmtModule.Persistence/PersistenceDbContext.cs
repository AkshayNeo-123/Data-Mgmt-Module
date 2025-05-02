
using System.Data;
using DataMgmtModule.Application.Models;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence
{
    public partial class PersistenceDbContext:DbContext
    {
        public PersistenceDbContext(DbContextOptions<PersistenceDbContext> options):base(options)
        {
            
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        //public DbSet<User> Users { get; set; }
        //public DbSet<Roles> roles { get; set; }
        //public DbSet<Projects> Projects { get; set; }
        //public DbSet<Recipe> Recipes { get; set; }
        //public DbSet<Additive> Additives { get; set; }
        //public DbSet<Component> Components { get; set; }
        //public DbSet<MainPolymer> MainPolymers { get; set; }
        //public DbSet<RecipeComponent> RecipeComponents { get; set; }
        //public DbSet<Materials> Materials { get; set; }
        //public DbSet<RecipesLog> Recipes_Log { get; set; }
        //public DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Additive> Additives { get; set; }

        public virtual DbSet<Component> Components { get; set; }

        public virtual DbSet<CompoundLog> CompoundLogs { get; set; }

        public virtual DbSet<CompoundingComponent> CompoundingComponents { get; set; }

        public virtual DbSet<CompoundingDatum> CompoundingData { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Dosage> Dosages { get; set; }

        public virtual DbSet<InjectionMolding> InjectionMoldings { get; set; }

        public virtual DbSet<MainPolymer> MainPolymers { get; set; }

        public virtual DbSet<Materials> Materials { get; set; }

        public virtual DbSet<MouldingLog> MouldingLogs { get; set; }

        public virtual DbSet<Projects> Projects { get; set; }
          
        public virtual DbSet<Recipe> Recipes { get; set; }

        public virtual DbSet<RecipeComponent> RecipeComponents { get; set; }

        public virtual DbSet<RecipesLog> RecipesLogs { get; set; }

        public virtual DbSet<Roles> Roles { get; set; }

        public virtual DbSet<RolePermission> RolePermissions { get; set; }

        public virtual DbSet<MvrMfr> MvrMfr { get; set; }

        public virtual DbSet<StorageLocation> StorageLocation { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ProjectTypes> ProjectTypes { get; set; }
        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<Priorities> Priorities { get; set; }
        public virtual DbSet<Status> Status { get; set; }


        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //        => optionsBuilder.UseSqlServer("Server=DESKTOP-KLVE00N;Database=DMM;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Additive>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Additive__3214EC074C5EF213");

                entity.ToTable("Additive");

                entity.Property(e => e.AdditiveName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Additive_Name");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Componen__3214EC074E67F250");

                entity.Property(e => e.ComponentName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Component_Name");
            });

            modelBuilder.Entity<CompoundLog>(entity =>
            {
                entity.HasKey(e => e.LogId).HasName("PK__Compound__5E54864888758AA1");

                entity.ToTable("Compound_Log");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.Notes)
                    .HasMaxLength(234)
                    .IsUnicode(false);
                entity.Property(e => e.ResidualIm)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("ResidualIM");
                entity.Property(e => e.Temperature).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<CompoundingComponent>(entity =>
            {
                entity.Property(e => e.Mf).HasColumnName("MF");
                entity.Property(e => e.Sf).HasColumnName("SF");
                entity.Property(e => e.Share).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Component).WithMany(p => p.CompoundingComponents)
                    .HasForeignKey(d => d.ComponentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Components_CompoundingComponents");

                entity.HasOne(d => d.Compounding).WithMany(p => p.CompoundingComponents)
                    .HasForeignKey(d => d.CompoundingId)
                    .HasConstraintName("FK__Compoundi__Compo__6A30C649");

                entity.HasOne(d => d.Recipe).WithMany(p => p.CompoundingComponents)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__Compoundi__Recip__693CA210");
            });

            modelBuilder.Entity<CompoundingDatum>(entity =>
            {
                entity.HasKey(e => e.CompoundingId).HasName("PK__Compound__BFB1449628198F68");

                entity.Property(e => e.Notes)
                    .HasMaxLength(234)
                    .IsUnicode(false);
                entity.Property(e => e.ResidualM).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Temperature).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Recipe).WithMany(p => p.CompoundingData)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Compoundi__Recip__656C112C");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.ContactId).HasName("PK__Contacts__5C66259B02C31B89");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Address_Line1");
                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Address_Line2");
                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ContactName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dosage>(entity =>
            {
                entity.HasKey(e => e.DosageId).HasName("PK__Dosage__FD7BEA82CDB5FD52");

                entity.ToTable("Dosage");

                entity.Property(e => e.Notes)
                    .HasMaxLength(234)
                    .IsUnicode(false);
                entity.Property(e => e.ScrewSpeed).HasColumnName("screwSpeed");
                entity.Property(e => e.TemperatureWaterBath).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.UploadScrewconfig)
                    .HasMaxLength(213)
                    .IsUnicode(false)
                    .HasColumnName("Upload_Screwconfig");

                entity.HasOne(d => d.Compounding).WithMany(p => p.Dosages)
                    .HasForeignKey(d => d.CompoundingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Dosage__Compound__00200768");
            });

            modelBuilder.Entity<InjectionMolding>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Injectio__3214EC075D8F91C1");

                entity.ToTable("InjectionMolding");

                entity.Property(e => e.BackPressure).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.DecompressionVolume).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.DryingTemperature).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.DryingTime).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.ExtraFeedSection).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.HoldingPressure).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.InjectionPressure).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.InjectionSpeed).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.MeltTemperature).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.MoldTemperature).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.NozzleTemperature).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.PlasticizingVolume).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.ProcessingMoisture).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.ReferenceAdditive)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.ResidualMoisture).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.ScrewSpeed).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.SwitchingPoint).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.TemperatureZone).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Project).WithMany(p => p.InjectionMoldings)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_InjectionMolding");

                entity.HasOne(d => d.Recipe).WithMany(p => p.InjectionMoldings)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_InjectionMolding");
            });

            modelBuilder.Entity<MainPolymer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Main_Pol__3214EC073E201D8F");

                entity.ToTable("MainPolymer");

                entity.Property(e => e.PolymerName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Materials>(entity =>
            {
                entity.HasKey(e => e.MaterialId).HasName("PK__Material__C50610F7A8B00652");

                entity.Property(e => e.Density).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.MsdsfilePath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MSDSFilePath");
                //entity.Property(e => e.MvrMfrId).HasColumnName("MvrMfrId");
                entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.TdsfilePath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TDSFilePath");
                entity.Property(e => e.TestMethod)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                //entity.HasOne(d => d.Manufacturer)
                ////.WithMany(p => p.Materials)
                //    .HasForeignKey(d => d.ManufacturerId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("fk_Contacts_Materials");
            });

            modelBuilder.Entity<MouldingLog>(entity =>
            {
                entity.HasKey(e => e.LogId).HasName("PK__Moulding__5E548648065FEABD");

                entity.ToTable("Moulding_Log");

                entity.Property(e => e.BackPressure).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.DecompressionVolume).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.DryingTemperature).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.DryingTime).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.ExtraFeedSection).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.HoldingPressure).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.InjectionPressure).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.InjectionSpeed).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.MeltTemperature).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.MoldTemperature).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.NozzleTemperature).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.PlasticizingVolume).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.ProcessingMoisture).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.ReferenceAdditive)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.ResidualMoisture).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.ScrewSpeed).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.SwitchingPoint).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.TemperatureZone).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABEF04A8A34AE");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");
                entity.Property(e => e.Project_Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Project_Description");
                entity.Property(e => e.ProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.ReceipeId).HasName("PK__Recipes__7B815E005AB965F9");

                entity.Property(e => e.ReceipeId).HasColumnName("ReceipeID");
                entity.Property(e => e.Comments)
                    .HasMaxLength(210)
                    .IsUnicode(false);
                entity.Property(e => e.ProductName)
                    .HasMaxLength(123)
                    .IsUnicode(false);

                entity.HasOne(d => d.Additive).WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.AdditiveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Additive_Recipes");

                entity.HasOne(d => d.MainPolymer).WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.MainPolymerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MainPolymer_Recipes");

                entity.HasOne(d => d.Project).WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Projects_Recipes");
            });

            modelBuilder.Entity<RecipeComponent>(entity =>
            {
                entity.HasKey(e => e.RecipeComponentId).HasName("PK__RecipeCo__C532CD47C9FC7453");

                entity.Property(e => e.Density).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Mf).HasColumnName("MF");
                entity.Property(e => e.Mp).HasColumnName("MP");
                entity.Property(e => e.ValPercent).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.WtPercent).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Component).WithMany(p => p.RecipeComponents)
                    .HasForeignKey(d => d.ComponentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Component_RecipeComponents");

                entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeComponents)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Recipes_RecipeComponents");
            });

            modelBuilder.Entity<RecipesLog>(entity =>
            {
                entity.HasKey(e => e.LogId).HasName("PK__Recipes___5E5486481A3F1873");

                entity.ToTable("Recipes_Log");

                entity.Property(e => e.Comments)
                    .HasMaxLength(210)
                    .IsUnicode(false);
                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.ProductName)
                    .HasMaxLength(123)
                    .IsUnicode(false);
                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A3440A4D9");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => e.PermissionId).HasName("PK__RolePerm__EFA6FB2F767127EB");

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Roles_RolePermissions");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C439399B6");

                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534BAD20FD3").IsUnique();

                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                //entity.HasOne(d => d.Role).WithMany(p => p.Users)
                //    .HasForeignKey(d => d.RoleId)
                //    .HasConstraintName("fk_Users_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
