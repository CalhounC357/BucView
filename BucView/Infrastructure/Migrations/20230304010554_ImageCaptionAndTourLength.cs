using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BucView.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImageCaptionAndTourLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstimatedTime",
                table: "Tour",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LocationImage",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedTime",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "LocationImage");
        }
    }
}
