using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProfile.Migrations
{
    public partial class R2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Others",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CvPath = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ImageSiteBarPath = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ResumeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Others_resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Others_ResumeId",
                table: "Others",
                column: "ResumeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Others");
        }
    }
}
