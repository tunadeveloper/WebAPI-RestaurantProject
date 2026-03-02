using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantProject.WebAPILayer.Migrations
{
    /// <inheritdoc />
    public partial class eventsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventsTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventsDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventsImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventsStatus = table.Column<bool>(type: "bit", nullable: false),
                    EventsPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
