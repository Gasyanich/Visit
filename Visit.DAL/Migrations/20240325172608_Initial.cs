using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Visit.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StringValues = table.Column<List<string>>(type: "text[]", nullable: true),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CanUseInFilter = table.Column<bool>(type: "boolean", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    AllowMultipleValues = table.Column<bool>(type: "boolean", nullable: false),
                    PredefinedValues = table.Column<List<object>>(type: "jsonb", nullable: true),
                    Type = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ControlType = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeCategory",
                columns: table => new
                {
                    AttributesId = table.Column<long>(type: "bigint", nullable: false),
                    CategoriesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeCategory", x => new { x.AttributesId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_AttributeCategory_Attributes_AttributesId",
                        column: x => x.AttributesId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlaceId = table.Column<int>(type: "integer", nullable: false),
                    AttributeId = table.Column<long>(type: "bigint", nullable: false),
                    IntValue = table.Column<int>(type: "integer", nullable: true),
                    DoubleValue = table.Column<double>(type: "double precision", nullable: true),
                    StringValue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeValues_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeValues_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPlace",
                columns: table => new
                {
                    CategoriesId = table.Column<long>(type: "bigint", nullable: false),
                    PlacesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPlace", x => new { x.CategoriesId, x.PlacesId });
                    table.ForeignKey(
                        name: "FK_CategoryPlace_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPlace_Places_PlacesId",
                        column: x => x.PlacesId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeCategory_CategoriesId",
                table: "AttributeCategory",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_AttributeId",
                table: "AttributeValues",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_DoubleValue",
                table: "AttributeValues",
                column: "DoubleValue");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_IntValue",
                table: "AttributeValues",
                column: "IntValue");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_PlaceId",
                table: "AttributeValues",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_StringValue",
                table: "AttributeValues",
                column: "StringValue");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPlace_PlacesId",
                table: "CategoryPlace",
                column: "PlacesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeCategory");

            migrationBuilder.DropTable(
                name: "AttributeValues");

            migrationBuilder.DropTable(
                name: "CategoryPlace");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}
