﻿using CO2.Companies;
using CO2.Domain;
using CO2.Emissions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO2.EntityFramework {
    public class ApiDbContext: DbContext {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options) { 
        
        }

        #region DbSets
        public DbSet<Company>  Companies { get; set; }
        public DbSet<Emission> Emissions { get; set; }
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
        }

    }
}
