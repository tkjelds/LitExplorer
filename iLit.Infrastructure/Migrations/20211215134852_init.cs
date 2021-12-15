using Microsoft.EntityFrameworkCore.Migrations;

namespace iLit.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edges",
                columns: table => new
                {
                    edgeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fromNodeID = table.Column<int>(type: "int", nullable: false),
                    toNodeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edges", x => x.edgeID);
                    table.CheckConstraint("CK_Edge_From_To_ID", "[fromNodeID] != [toNodeID]");
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edges_fromNodeID_toNodeID",
                table: "Edges",
                columns: new[] { "fromNodeID", "toNodeID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_title",
                table: "Nodes",
                column: "title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edges");

            migrationBuilder.DropTable(
                name: "Nodes");
        }
    }
}
