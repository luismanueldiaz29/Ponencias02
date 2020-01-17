using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ponencia02.Migrations
{
    public partial class Ponencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Usuario = table.Column<string>(nullable: false),
                    Pass = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Facultad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreFacultad = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultad", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoInvestigacion",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGrupo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoInvestigacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Programa",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePrograma = table.Column<string>(nullable: false),
                    FacultadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programa", x => x.id);
                    table.ForeignKey(
                        name: "FK_Programa_Facultad_FacultadId",
                        column: x => x.FacultadId,
                        principalTable: "Facultad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    VinculoInst = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Pass = table.Column<string>(nullable: true),
                    FacultadId = table.Column<int>(nullable: false),
                    GrupoInvestigacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Docente_Facultad_FacultadId",
                        column: x => x.FacultadId,
                        principalTable: "Facultad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Docente_GrupoInvestigacion_GrupoInvestigacionId",
                        column: x => x.GrupoInvestigacionId,
                        principalTable: "GrupoInvestigacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Semillero",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSemillero = table.Column<string>(nullable: true),
                    GrupoInvestigacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semillero", x => x.id);
                    table.ForeignKey(
                        name: "FK_Semillero_GrupoInvestigacion_GrupoInvestigacionId",
                        column: x => x.GrupoInvestigacionId,
                        principalTable: "GrupoInvestigacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitud",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePonencia = table.Column<string>(nullable: true),
                    FechaEntrega = table.Column<string>(nullable: true),
                    DocenteId = table.Column<string>(nullable: true),
                    EstadoSolicitud = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitud", x => x.id);
                    table.ForeignKey(
                        name: "FK_Solicitud_Docente_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstudiante = table.Column<string>(nullable: true),
                    ApellidoEstudiante = table.Column<string>(nullable: true),
                    SemilleroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.id);
                    table.ForeignKey(
                        name: "FK_Estudiante_Semillero_SemilleroId",
                        column: x => x.SemilleroId,
                        principalTable: "Semillero",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEvento = table.Column<string>(nullable: false),
                    LinkEvento = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: false),
                    Ciudad = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    ValorInscripcion = table.Column<decimal>(nullable: false),
                    FechaEvento = table.Column<string>(nullable: false),
                    FechaInicio = table.Column<string>(nullable: false),
                    FechaFinal = table.Column<string>(nullable: false),
                    Entidad = table.Column<string>(nullable: true),
                    NumeroDias = table.Column<int>(nullable: false),
                    SolicitudId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.id);
                    table.ForeignKey(
                        name: "FK_Evento_Solicitud_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solicitud",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Investigacion",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreInvestigacion = table.Column<string>(nullable: false),
                    SolicitudId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investigacion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Investigacion_Solicitud_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solicitud",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repositorio",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudId = table.Column<int>(nullable: false),
                    Sustentacion = table.Column<byte[]>(nullable: true),
                    CitasBibliograficas = table.Column<byte[]>(nullable: true),
                    DocValorInscripcion = table.Column<byte[]>(nullable: true),
                    ContizacionHospedaje = table.Column<byte[]>(nullable: true),
                    DocInfoEvento = table.Column<byte[]>(nullable: true),
                    FormatoOriginal = table.Column<byte[]>(nullable: true),
                    FormatoCesionDerecho = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repositorio", x => x.id);
                    table.ForeignKey(
                        name: "FK_Repositorio_Solicitud_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solicitud",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transporte",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoTransporte = table.Column<string>(nullable: true),
                    ValorTrasporte = table.Column<decimal>(nullable: false),
                    SolicitudId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transporte", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transporte_Solicitud_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solicitud",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docente_FacultadId",
                table: "Docente",
                column: "FacultadId");

            migrationBuilder.CreateIndex(
                name: "IX_Docente_GrupoInvestigacionId",
                table: "Docente",
                column: "GrupoInvestigacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_SemilleroId",
                table: "Estudiante",
                column: "SemilleroId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_SolicitudId",
                table: "Evento",
                column: "SolicitudId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Investigacion_SolicitudId",
                table: "Investigacion",
                column: "SolicitudId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programa_FacultadId",
                table: "Programa",
                column: "FacultadId");

            migrationBuilder.CreateIndex(
                name: "IX_Repositorio_SolicitudId",
                table: "Repositorio",
                column: "SolicitudId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Semillero_GrupoInvestigacionId",
                table: "Semillero",
                column: "GrupoInvestigacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_DocenteId",
                table: "Solicitud",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transporte_SolicitudId",
                table: "Transporte",
                column: "SolicitudId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Investigacion");

            migrationBuilder.DropTable(
                name: "Programa");

            migrationBuilder.DropTable(
                name: "Repositorio");

            migrationBuilder.DropTable(
                name: "Transporte");

            migrationBuilder.DropTable(
                name: "Semillero");

            migrationBuilder.DropTable(
                name: "Solicitud");

            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "Facultad");

            migrationBuilder.DropTable(
                name: "GrupoInvestigacion");
        }
    }
}
