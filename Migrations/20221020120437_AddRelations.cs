using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_travel_agency.Migrations
{
    public partial class AddRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "TravelPackages");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TravelPackages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "TravelPackages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransportId",
                table: "TravelPackages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagTravelPackage",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    TravelPackagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTravelPackage", x => new { x.TagsId, x.TravelPackagesId });
                    table.ForeignKey(
                        name: "FK_TagTravelPackage_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTravelPackage_TravelPackages_TravelPackagesId",
                        column: x => x.TravelPackagesId,
                        principalTable: "TravelPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackages_CategoryId",
                table: "TravelPackages",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackages_DestinationId",
                table: "TravelPackages",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackages_TransportId",
                table: "TravelPackages",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagTravelPackage_TravelPackagesId",
                table: "TagTravelPackage",
                column: "TravelPackagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_Name",
                table: "Transports",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackages_Categories_CategoryId",
                table: "TravelPackages",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackages_Destinations_DestinationId",
                table: "TravelPackages",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackages_Transports_TransportId",
                table: "TravelPackages",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackages_Categories_CategoryId",
                table: "TravelPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackages_Destinations_DestinationId",
                table: "TravelPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackages_Transports_TransportId",
                table: "TravelPackages");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "TagTravelPackage");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_TravelPackages_CategoryId",
                table: "TravelPackages");

            migrationBuilder.DropIndex(
                name: "IX_TravelPackages_DestinationId",
                table: "TravelPackages");

            migrationBuilder.DropIndex(
                name: "IX_TravelPackages_TransportId",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "TransportId",
                table: "TravelPackages");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "TravelPackages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
