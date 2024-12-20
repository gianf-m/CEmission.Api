﻿// <auto-generated />
using System;
using CEmission.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CEmission.EntityFramework.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20241007124451_AddIdentityUserCustomTable")]
    partial class AddIdentityUserCustomTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CEmission.Companies.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<DateTime>("DeletionTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DeletionTime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("App_Companies", (string)null);
                });

            modelBuilder.Entity("CEmission.Emissions.Emission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("varchar")
                        .HasColumnName("Description");

                    b.Property<DateTime>("EmissionDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("EmissionDate");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Quantity");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("varchar")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("App_Emissions", (string)null);
                });

            modelBuilder.Entity("CEmission.IdentityUsers.IdentityUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Email");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("NormalizedEmail");

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("NormalizedUserName");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("varchar")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar")
                        .HasColumnName("PhoneNumber");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("IX_App_IdentityUsers_Email");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasDatabaseName("IX_App_IdentityUsers_UserName");

                    b.ToTable("App_IdentityUsers", (string)null);
                });

            modelBuilder.Entity("CEmission.Emissions.Emission", b =>
                {
                    b.HasOne("CEmission.Companies.Company", null)
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
