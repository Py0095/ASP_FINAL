﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetFinal.Models;

#nullable disable

namespace ProjetFinal.Migrations
{
    [DbContext(typeof(BridgeDBcontext))]
    [Migration("20230612230124_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetFinal.Models.Conducteur", b =>
                {
                    b.Property<int>("No_Dossier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("No_Dossier"));

                    b.Property<string>("MyPrenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nif")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("No_Dossier");

                    b.ToTable("Tb_Conducteur");
                });

            modelBuilder.Entity("ProjetFinal.Models.Contravention", b =>
                {
                    b.Property<int>("No_Fiche")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("No_Fiche"));

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Article_violation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code_agent")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Couleur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_contravention")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marque")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Montant_a_payer")
                        .HasColumnType("int");

                    b.Property<int>("No_Dossier")
                        .HasColumnType("int");

                    b.Property<string>("Plaque_vehicule")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("No_Fiche");

                    b.HasIndex("Code_agent");

                    b.HasIndex("No_Dossier");

                    b.ToTable("Tb_Contravention");
                });

            modelBuilder.Entity("ProjetFinal.Models.DCPR", b =>
                {
                    b.Property<string>("Code_agent")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Affectation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code_agent");

                    b.ToTable("Tb_DCPR");
                });

            modelBuilder.Entity("ProjetFinal.Models.DGI", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date_paiement")
                        .HasColumnType("datetime2");

                    b.Property<int>("Montant")
                        .HasColumnType("int");

                    b.Property<int>("No_Fiche")
                        .HasColumnType("int");

                    b.Property<string>("Remarque")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("No_Fiche");

                    b.ToTable("Tb_DGI");
                });

            modelBuilder.Entity("ProjetFinal.Models.Contravention", b =>
                {
                    b.HasOne("ProjetFinal.Models.DCPR", "DCPR")
                        .WithMany()
                        .HasForeignKey("Code_agent");

                    b.HasOne("ProjetFinal.Models.Conducteur", "Conducteur")
                        .WithMany()
                        .HasForeignKey("No_Dossier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conducteur");

                    b.Navigation("DCPR");
                });

            modelBuilder.Entity("ProjetFinal.Models.DGI", b =>
                {
                    b.HasOne("ProjetFinal.Models.Contravention", "contravention")
                        .WithMany()
                        .HasForeignKey("No_Fiche")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("contravention");
                });
#pragma warning restore 612, 618
        }
    }
}
