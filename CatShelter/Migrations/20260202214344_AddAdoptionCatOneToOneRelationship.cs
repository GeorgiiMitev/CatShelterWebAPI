using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatShelter.Migrations
{
    /// <inheritdoc />
    public partial class AddAdoptionCatOneToOneRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Adoptions_CatId",
                table: "Adoptions");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_CatId",
                table: "Adoptions",
                column: "CatId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Adoptions_CatId",
                table: "Adoptions");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_CatId",
                table: "Adoptions",
                column: "CatId");
        }
    }
}
