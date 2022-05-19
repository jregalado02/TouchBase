using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouchBase.Data.Migrations
{
    public partial class AddedReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectCollection",
                columns: table => new
                {
                    ProjectCollectionModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCollection", x => x.ProjectCollectionModelId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approximation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCollectionModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectModelId);
                    table.ForeignKey(
                        name: "FK_Project_ProjectCollection_ProjectCollectionModelId",
                        column: x => x.ProjectCollectionModelId,
                        principalTable: "ProjectCollection",
                        principalColumn: "ProjectCollectionModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProjectCollection",
                columns: new[] { "ProjectCollectionModelId", "CompanyName" },
                values: new object[] { 1, "Great Lakes Cloud Solutions, LLC" });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectModelId", "Approximation", "Description", "IsDone", "Name", "ProjectCollectionModelId" },
                values: new object[] { 1, "Your Mom", "Stuff and things", false, "First Model", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectCollectionModelId",
                table: "Project",
                column: "ProjectCollectionModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectCollection");
        }
    }
}
