using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementSolution.Migrations
{
    public partial class freshInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "RoomNumber", "Status" },
                values: new object[,]
                {
                    { 1, "1A", "Available" },
                    { 18, "4C", "Available" },
                    { 17, "4D", "Available" },
                    { 16, "4E", "Available" },
                    { 15, "3E", "Available" },
                    { 14, "3D", "Available" },
                    { 13, "3C", "Available" },
                    { 12, "3B", "Available" },
                    { 11, "3A", "Available" },
                    { 10, "2A", "Available" },
                    { 9, "2B", "Available" },
                    { 8, "2C", "Available" },
                    { 7, "2D", "Available" },
                    { 6, "2E", "Available" },
                    { 5, "1E", "Available" },
                    { 4, "1D", "Available" },
                    { 3, "1C", "Available" },
                    { 2, "1B", "Available" },
                    { 19, "4B", "Available" },
                    { 20, "4A", "Available" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
