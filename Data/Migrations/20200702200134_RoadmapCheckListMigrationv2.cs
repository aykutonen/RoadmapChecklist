using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RoadmapCheckListMigrationv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CopiedRoadmaps_Roadmap_RoadmapId",
                table: "CopiedRoadmaps");

            migrationBuilder.DropForeignKey(
                name: "FK_RoadmapItem_RoadmapItem_ParentRoadmapItemId",
                table: "RoadmapItem");

            migrationBuilder.DropIndex(
                name: "IX_RoadmapItem_ParentRoadmapItemId",
                table: "RoadmapItem");

            migrationBuilder.DropIndex(
                name: "IX_CopiedRoadmaps_RoadmapId",
                table: "CopiedRoadmaps");

            migrationBuilder.DropColumn(
                name: "ParentRoadmapItemId",
                table: "RoadmapItem");

            migrationBuilder.DropColumn(
                name: "RoadmapId",
                table: "CopiedRoadmaps");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "User",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Tag",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FriendlyUrl",
                table: "Tag",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "RoadmapItem",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RoadmapItem",
                maxLength: 525,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roadmap",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Category",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FriendlyUrl",
                table: "Category",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateTime", "Email", "Name", "Password", "Picture", "Status", "UpDateTime" },
                values: new object[] { 1, new DateTime(2020, 7, 2, 20, 1, 34, 547, DateTimeKind.Utc).AddTicks(5803), "hande.ebrar@gmail.com", "Hande", "123", null, 1, new DateTime(2020, 7, 2, 20, 1, 34, 547, DateTimeKind.Utc).AddTicks(7201) });

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapItem_ParentId",
                table: "RoadmapItem",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CopiedRoadmaps_SourceRoadmapId",
                table: "CopiedRoadmaps",
                column: "SourceRoadmapId");

            migrationBuilder.AddForeignKey(
                name: "FK_CopiedRoadmaps_Roadmap_SourceRoadmapId",
                table: "CopiedRoadmaps",
                column: "SourceRoadmapId",
                principalTable: "Roadmap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoadmapItem_RoadmapItem_ParentId",
                table: "RoadmapItem",
                column: "ParentId",
                principalTable: "RoadmapItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CopiedRoadmaps_Roadmap_SourceRoadmapId",
                table: "CopiedRoadmaps");

            migrationBuilder.DropForeignKey(
                name: "FK_RoadmapItem_RoadmapItem_ParentId",
                table: "RoadmapItem");

            migrationBuilder.DropIndex(
                name: "IX_RoadmapItem_ParentId",
                table: "RoadmapItem");

            migrationBuilder.DropIndex(
                name: "IX_CopiedRoadmaps_SourceRoadmapId",
                table: "CopiedRoadmaps");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "FriendlyUrl",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "RoadmapItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RoadmapItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 525);

            migrationBuilder.AddColumn<int>(
                name: "ParentRoadmapItemId",
                table: "RoadmapItem",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roadmap",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "RoadmapId",
                table: "CopiedRoadmaps",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "FriendlyUrl",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapItem_ParentRoadmapItemId",
                table: "RoadmapItem",
                column: "ParentRoadmapItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CopiedRoadmaps_RoadmapId",
                table: "CopiedRoadmaps",
                column: "RoadmapId");

            migrationBuilder.AddForeignKey(
                name: "FK_CopiedRoadmaps_Roadmap_RoadmapId",
                table: "CopiedRoadmaps",
                column: "RoadmapId",
                principalTable: "Roadmap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoadmapItem_RoadmapItem_ParentRoadmapItemId",
                table: "RoadmapItem",
                column: "ParentRoadmapItemId",
                principalTable: "RoadmapItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
