﻿// <auto-generated />
using System;
using APISEMINARIO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APISEMINARIO.Migrations
{
    [DbContext(typeof(SENATIContext))]
    [Migration("20240314024722_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APISEMINARIO.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("APISEMINARIO.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("APISEMINARIO.Conocimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AreaConoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TecnicoId")
                        .HasColumnType("int");

                    b.Property<string>("TituloConoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TecnicoId");

                    b.ToTable("Conocimientos");
                });

            modelBuilder.Entity("APISEMINARIO.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("APISEMINARIO.Proyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreProyecto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("APISEMINARIO.Tecnico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreTecnico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("APISEMINARIO.TecnicoProyecto", b =>
                {
                    b.Property<int?>("TecnicoId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int?>("ProyectoId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("FechaAsignacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCese")
                        .HasColumnType("datetime2");

                    b.HasKey("TecnicoId", "ProyectoId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("TecnicosProyectos");
                });

            modelBuilder.Entity("APISEMINARIO.Conocimiento", b =>
                {
                    b.HasOne("APISEMINARIO.Tecnico", "Tecnicos")
                        .WithMany("Conocimientos")
                        .HasForeignKey("TecnicoId");

                    b.Navigation("Tecnicos");
                });

            modelBuilder.Entity("APISEMINARIO.Proyecto", b =>
                {
                    b.HasOne("APISEMINARIO.Cliente", "Clientes")
                        .WithMany("Proyectos")
                        .HasForeignKey("ClienteId");

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("APISEMINARIO.Tecnico", b =>
                {
                    b.HasOne("APISEMINARIO.Categoria", "Categoria")
                        .WithMany("Tecnicos")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("APISEMINARIO.Empresa", "Empresa")
                        .WithMany("Tecnicos")
                        .HasForeignKey("EmpresaId");

                    b.Navigation("Categoria");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("APISEMINARIO.TecnicoProyecto", b =>
                {
                    b.HasOne("APISEMINARIO.Proyecto", "Proyecto")
                        .WithMany("TecnicosProyectos")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APISEMINARIO.Tecnico", "Tecnico")
                        .WithMany("TecnicosProyectos")
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("APISEMINARIO.Categoria", b =>
                {
                    b.Navigation("Tecnicos");
                });

            modelBuilder.Entity("APISEMINARIO.Cliente", b =>
                {
                    b.Navigation("Proyectos");
                });

            modelBuilder.Entity("APISEMINARIO.Empresa", b =>
                {
                    b.Navigation("Tecnicos");
                });

            modelBuilder.Entity("APISEMINARIO.Proyecto", b =>
                {
                    b.Navigation("TecnicosProyectos");
                });

            modelBuilder.Entity("APISEMINARIO.Tecnico", b =>
                {
                    b.Navigation("Conocimientos");

                    b.Navigation("TecnicosProyectos");
                });
#pragma warning restore 612, 618
        }
    }
}