using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VistaBasket.Catalog.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifyproducttbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "ImageName");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageBlob",
                table: "Products",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBlob",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Products",
                newName: "ImageUrl");
        }
    }
}
