using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCAssignmentPerson.Migrations
{
    public partial class FixCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cityis_People_PersonInCityId",
                table: "Cityis");

            migrationBuilder.DropIndex(
                name: "IX_Cityis_PersonInCityId",
                table: "Cityis");

            migrationBuilder.DropColumn(
                name: "PersonInCityId",
                table: "Cityis");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cityis_CityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "PersonInCityId",
                table: "Cityis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cityis_PersonInCityId",
                table: "Cityis",
                column: "PersonInCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cityis_People_PersonInCityId",
                table: "Cityis",
                column: "PersonInCityId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
