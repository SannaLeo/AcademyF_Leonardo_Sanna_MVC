﻿// <auto-generated />
using System;
using AcademyF_Leonardo_Sanna_MVC.RepositoryEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AcademyF_Leonardo_Sanna_MVC.RepositoryEF.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20220610105050_prima")]
    partial class prima
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AcademyF_Leonardo_Sanna_MVC.Core.Entities.Utente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ruolo")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Utente");

                    b.ToTable("Utente", (string)null);
                });

            modelBuilder.Entity("AcademyF_Leonardo_Sanna_MVC.Core.Menu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id")
                        .HasName("PK_Menu");

                    b.ToTable("Menu", (string)null);
                });

            modelBuilder.Entity("AcademyF_Leonardo_Sanna_MVC.Core.Piatto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Tipologia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Piatto", (string)null);
                });

            modelBuilder.Entity("AcademyF_Leonardo_Sanna_MVC.Core.Piatto", b =>
                {
                    b.HasOne("AcademyF_Leonardo_Sanna_MVC.Core.Menu", "Menu")
                        .WithMany("Piatti")
                        .HasForeignKey("MenuId");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("AcademyF_Leonardo_Sanna_MVC.Core.Menu", b =>
                {
                    b.Navigation("Piatti");
                });
#pragma warning restore 612, 618
        }
    }
}
