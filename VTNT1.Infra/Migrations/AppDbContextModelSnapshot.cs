﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VTNT1.Infra.Data;

#nullable disable

namespace VTNT1.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VTNT1.Domain.Models.FaseCafe", b =>
                {
                    b.Property<int>("FaseCafeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FaseCafeID"), 1L, 1);

                    b.Property<int>("Chumbinho")
                        .HasColumnType("int");

                    b.Property<int>("Marrom")
                        .HasColumnType("int");

                    b.Property<int>("Verde")
                        .HasColumnType("int");

                    b.Property<int>("Vermelho")
                        .HasColumnType("int");

                    b.HasKey("FaseCafeID");

                    b.ToTable("tb_FasesCafe");
                });

            modelBuilder.Entity("VTNT1.Domain.Models.RouteVTNT1", b =>
                {
                    b.Property<int>("PassagemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassagemID"), 1L, 1);

                    b.Property<decimal>("Distancia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FaseCafeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime2");

                    b.HasKey("PassagemID");

                    b.HasIndex("FaseCafeID")
                        .IsUnique();

                    b.ToTable("tb_RouteVTNT1");
                });

            modelBuilder.Entity("VTNT1.Domain.Models.RouteVTNT1", b =>
                {
                    b.HasOne("VTNT1.Domain.Models.FaseCafe", "FaseCafe")
                        .WithOne("Passagem_VTNT1")
                        .HasForeignKey("VTNT1.Domain.Models.RouteVTNT1", "FaseCafeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FaseCafe");
                });

            modelBuilder.Entity("VTNT1.Domain.Models.FaseCafe", b =>
                {
                    b.Navigation("Passagem_VTNT1")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
