﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ponencias02.Models;

namespace Ponencia02.Migrations
{
    [DbContext(typeof(PonenciaContext))]
    partial class PonenciaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ponencias02.Models.Administrador", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("Ponencias02.Models.Docente", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacultadId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoInvestigacionId")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VinculoInst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("FacultadId");

                    b.HasIndex("GrupoInvestigacionId");

                    b.ToTable("Docente");
                });

            modelBuilder.Entity("Ponencias02.Models.Estudiante", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoEstudiante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEstudiante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SemilleroId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("SemilleroId");

                    b.ToTable("Estudiante");
                });

            modelBuilder.Entity("Ponencias02.Models.Evento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaFinal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaInicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkEvento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroDias")
                        .HasColumnType("int");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SolicitudId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorInscripcion")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("SolicitudId")
                        .IsUnique();

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("Ponencias02.Models.Facultad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreFacultad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Facultad");
                });

            modelBuilder.Entity("Ponencias02.Models.GrupoInvestigacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreGrupo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("GrupoInvestigacion");
                });

            modelBuilder.Entity("Ponencias02.Models.Investigacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreInvestigacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SolicitudId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("SolicitudId")
                        .IsUnique();

                    b.ToTable("Investigacion");
                });

            modelBuilder.Entity("Ponencias02.Models.Programa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FacultadId")
                        .HasColumnType("int");

                    b.Property<string>("NombrePrograma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("FacultadId");

                    b.ToTable("Programa");
                });

            modelBuilder.Entity("Ponencias02.Models.Repositorio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CitasBibliograficas")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("ContizacionHospedaje")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("DocInfoEvento")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("DocValorInscripcion")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("FormatoCesionDerecho")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("FormatoOriginal")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("SolicitudId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Sustentacion")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("id");

                    b.HasIndex("SolicitudId")
                        .IsUnique();

                    b.ToTable("Repositorio");
                });

            modelBuilder.Entity("Ponencias02.Models.Semillero", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GrupoInvestigacionId")
                        .HasColumnType("int");

                    b.Property<string>("NombreSemillero")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("GrupoInvestigacionId");

                    b.ToTable("Semillero");
                });

            modelBuilder.Entity("Ponencias02.Models.Solicitud", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocenteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EstadoSolicitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaEntrega")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombrePonencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("DocenteId");

                    b.ToTable("Solicitud");
                });

            modelBuilder.Entity("Ponencias02.Models.Transporte", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SolicitudId")
                        .HasColumnType("int");

                    b.Property<string>("TipoTransporte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorTrasporte")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("SolicitudId")
                        .IsUnique();

                    b.ToTable("Transporte");
                });

            modelBuilder.Entity("Ponencias02.Models.Docente", b =>
                {
                    b.HasOne("Ponencias02.Models.Facultad", "Facultad")
                        .WithMany("Docentes")
                        .HasForeignKey("FacultadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ponencias02.Models.GrupoInvestigacion", "GrupoInvestigacion")
                        .WithMany("Docentes")
                        .HasForeignKey("GrupoInvestigacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ponencias02.Models.Estudiante", b =>
                {
                    b.HasOne("Ponencias02.Models.Semillero", "Semillero")
                        .WithMany("Estudiantes")
                        .HasForeignKey("SemilleroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ponencias02.Models.Evento", b =>
                {
                    b.HasOne("Ponencias02.Models.Solicitud", "Solicitud")
                        .WithOne("Evento")
                        .HasForeignKey("Ponencias02.Models.Evento", "SolicitudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ponencias02.Models.Investigacion", b =>
                {
                    b.HasOne("Ponencias02.Models.Solicitud", "Solicitud")
                        .WithOne("Investigacion")
                        .HasForeignKey("Ponencias02.Models.Investigacion", "SolicitudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ponencias02.Models.Programa", b =>
                {
                    b.HasOne("Ponencias02.Models.Facultad", "Facultad")
                        .WithMany()
                        .HasForeignKey("FacultadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ponencias02.Models.Repositorio", b =>
                {
                    b.HasOne("Ponencias02.Models.Solicitud", "Solicitud")
                        .WithOne("Repositorio")
                        .HasForeignKey("Ponencias02.Models.Repositorio", "SolicitudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ponencias02.Models.Semillero", b =>
                {
                    b.HasOne("Ponencias02.Models.GrupoInvestigacion", "GrupoInvestigacion")
                        .WithMany("Semillero")
                        .HasForeignKey("GrupoInvestigacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ponencias02.Models.Solicitud", b =>
                {
                    b.HasOne("Ponencias02.Models.Docente", "Docente")
                        .WithMany("Solicitud")
                        .HasForeignKey("DocenteId");
                });

            modelBuilder.Entity("Ponencias02.Models.Transporte", b =>
                {
                    b.HasOne("Ponencias02.Models.Solicitud", "Solicitud")
                        .WithOne("Transporte")
                        .HasForeignKey("Ponencias02.Models.Transporte", "SolicitudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
