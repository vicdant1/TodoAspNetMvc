using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Creating_Missing_Columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tasks");
        }
    }
}
