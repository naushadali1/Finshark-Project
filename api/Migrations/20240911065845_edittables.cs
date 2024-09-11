using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class edittables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_CommentId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Stock_StocksId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_StocksId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "StocksId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "LastDiv",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "MarcketCap",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Purchase",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Stock",
                newName: "Symbol");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Stock",
                newName: "Industry");

            migrationBuilder.RenameColumn(
                name: "Symbol",
                table: "Comment",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Industry",
                table: "Comment",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comment",
                newName: "StockId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_CommentId",
                table: "Comment",
                newName: "IX_Comment_StockId");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "LastDiv",
                table: "Stock",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "MarcketCap",
                table: "Stock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "Purchase",
                table: "Stock",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Stock_StockId",
                table: "Comment",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Stock_StockId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "LastDiv",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "MarcketCap",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Purchase",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "Symbol",
                table: "Stock",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Industry",
                table: "Stock",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Comment",
                newName: "Symbol");

            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "Comment",
                newName: "CommentId");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comment",
                newName: "Industry");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_StockId",
                table: "Comment",
                newName: "IX_Comment_CommentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Stock",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Stock",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StocksId",
                table: "Stock",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "LastDiv",
                table: "Comment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "MarcketCap",
                table: "Comment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "Purchase",
                table: "Comment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_StocksId",
                table: "Stock",
                column: "StocksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_CommentId",
                table: "Comment",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Stock_StocksId",
                table: "Stock",
                column: "StocksId",
                principalTable: "Stock",
                principalColumn: "Id");
        }
    }
}
