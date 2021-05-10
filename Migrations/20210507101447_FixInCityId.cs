using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCAssignmentPerson.Migrations
{
    public partial class FixInCityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cityis_CityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "InCityId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_People_InCityId",
                table: "People",
                column: "InCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cityis_InCityId",
                table: "People",
                column: "InCityId",
                principalTable: "Cityis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cityis_InCityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_InCityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "InCityId",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cityis_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cityis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
