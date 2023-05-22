﻿// <auto-generated />
using Fabrika_Personel_Kayit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fabrika_Personel_Kayit.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fabrika_Personel_Kayit.Models.Gorev", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gorevs");
                });

            modelBuilder.Entity("Fabrika_Personel_Kayit.Models.Personel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GorevId")
                        .HasColumnType("int");

                    b.Property<decimal>("Maas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TCNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GorevId");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("Fabrika_Personel_Kayit.Models.Personel", b =>
                {
                    b.HasOne("Fabrika_Personel_Kayit.Models.Gorev", "Gorev")
                        .WithMany("Personels")
                        .HasForeignKey("GorevId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gorev");
                });

            modelBuilder.Entity("Fabrika_Personel_Kayit.Models.Gorev", b =>
                {
                    b.Navigation("Personels");
                });
#pragma warning restore 612, 618
        }
    }
}
