using CEmission.Companies;
using CEmission.Domain;
using CEmission.Emissions;
using CEmission.IdentityUsers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.EntityFramework {
    public class ApiDbContext: DbContext {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options) { 
        
        }

        #region DbSets
        public DbSet<Company>  Companies { get; set; }
        public DbSet<Emission> Emissions { get; set; }
        public DbSet<IdentityUser> IdentityUsers { get; set; } //Custom IdentityUser Entity
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Company>(b => {
                b.ToTable(DomainConsts.DbTablePrefix + "Companies", DomainConsts.DbSchema);
                b.Property(x => x.Id).HasColumnName(nameof(Company.Id)).IsRequired();
                b.Property(x => x.Name).HasColumnName(nameof(Company.Name)).HasColumnType("varchar").HasMaxLength(CompaniesConsts.NameMaxLength).IsRequired();
                b.Property(x => x.CreationTime).HasColumnName(nameof(Company.CreationTime)).IsRequired();
                b.Property(x => x.IsDeleted).HasColumnName(nameof(Company.IsDeleted)).IsRequired();
                b.Property(x => x.DeletionTime).HasColumnName(nameof(Company.DeletionTime)).IsRequired();
            });

            modelBuilder.Entity<Emission>(b => {
                b.ToTable(DomainConsts.DbTablePrefix + "Emissions", DomainConsts.DbSchema);
                b.Property(x => x.Id).HasColumnName(nameof(Emission.Id)).IsRequired();
                b.Property(x => x.Description).HasColumnName(nameof(Emission.Description)).HasColumnType("varchar").HasMaxLength(EmissionsConsts.DescriptionMaxLength).IsRequired();
                b.Property(x => x.Quantity).HasColumnName(nameof(Emission.Quantity)).IsRequired();
                b.Property(x => x.EmissionDate).HasColumnName(nameof(Emission.EmissionDate)).IsRequired();
                b.Property(x => x.Type).HasColumnName(nameof(Emission.Type)).HasColumnType("varchar").HasMaxLength(EmissionsConsts.TypenMaxLength).IsRequired();
                b.Property(x => x.CreationTime).HasColumnName(nameof(Emission.CreationTime)).IsRequired();
                b.HasOne<Company>().WithMany().HasForeignKey(x => x.CompanyId);
            });

            modelBuilder.Entity<IdentityUser>(b => {
                b.ToTable(DomainConsts.DbTablePrefix + "IdentityUsers", DomainConsts.DbSchema);
                b.Property(x => x.Id).HasColumnName(nameof(IdentityUser.Id)).IsRequired();
                b.Property(x => x.UserName).HasColumnName(nameof(IdentityUser.UserName)).HasColumnType("varchar").HasMaxLength(IdentityUsersConsts.UsernameMaxLength).IsRequired();
                b.Property(x => x.NormalizedUserName).HasColumnName(nameof(IdentityUser.NormalizedUserName)).HasColumnType("varchar").HasMaxLength(IdentityUsersConsts.UsernameMaxLength).IsRequired();
                b.Property(x => x.Email).HasColumnName(nameof(IdentityUser.Email)).HasColumnType("varchar").HasMaxLength(IdentityUsersConsts.EmailMaxLength).IsRequired();
                b.Property(x => x.NormalizedEmail).HasColumnName(nameof(IdentityUser.NormalizedEmail)).HasColumnType("varchar").HasMaxLength(IdentityUsersConsts.EmailMaxLength).IsRequired();
                b.Property(x => x.PasswordHash).HasColumnName(nameof(IdentityUser.PasswordHash)).HasColumnType("varchar").HasMaxLength(IdentityUsersConsts.PasswordHashMaxLength).IsRequired();
                b.Property(x => x.PhoneNumber).HasColumnName(nameof(IdentityUser.PhoneNumber)).HasColumnType("varchar").HasMaxLength(IdentityUsersConsts.PhoneNumberMaxLength).IsRequired();
                b.HasIndex(x => new { x.UserName }).IsUnique().HasDatabaseName("IX_" + DomainConsts.DbTablePrefix + "IdentityUsers_UserName");
                b.HasIndex(x => new { x.Email }).IsUnique().HasDatabaseName("IX_" + DomainConsts.DbTablePrefix + "IdentityUsers_Email");
            });
        }

    }
}
