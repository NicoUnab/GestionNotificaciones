﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestionNotificaciones.Migrations
{
    /// <inheritdoc />
    public partial class AddNotificaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosReporte",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosReporte", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TiposReporte",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposReporte", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rut = table.Column<int>(type: "integer", nullable: false),
                    dv = table.Column<char>(type: "character(1)", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    telefono = table.Column<int>(type: "integer", nullable: false),
                    contraseña = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vecinos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    direccion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vecinos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vecinos_Usuarios_id",
                        column: x => x.id,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    ubicacion = table.Column<string>(type: "text", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    imagen = table.Column<int>(type: "integer", nullable: false),
                    idVecino = table.Column<int>(type: "integer", nullable: false),
                    idEstado = table.Column<int>(type: "integer", nullable: false),
                    idTipo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reportes_EstadosReporte_idEstado",
                        column: x => x.idEstado,
                        principalTable: "EstadosReporte",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reportes_TiposReporte_idTipo",
                        column: x => x.idTipo,
                        principalTable: "TiposReporte",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reportes_Vecinos_idVecino",
                        column: x => x.idVecino,
                        principalTable: "Vecinos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mensaje = table.Column<string>(type: "text", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    leido = table.Column<bool>(type: "boolean", nullable: false),
                    idReporte = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notificaciones_Reportes_idReporte",
                        column: x => x.idReporte,
                        principalTable: "Reportes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_idReporte",
                table: "Notificaciones",
                column: "idReporte");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_idEstado",
                table: "Reportes",
                column: "idEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_idTipo",
                table: "Reportes",
                column: "idTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_idVecino",
                table: "Reportes",
                column: "idVecino");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "EstadosReporte");

            migrationBuilder.DropTable(
                name: "TiposReporte");

            migrationBuilder.DropTable(
                name: "Vecinos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
