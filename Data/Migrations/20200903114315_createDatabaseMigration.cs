using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class createDatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 255, nullable: false),
                    FriendlyUrl = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 255, nullable: false),
                    FriendlyUrl = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    PasswordHash = table.Column<byte[]>(maxLength: 255, nullable: false),
                    PasswordSalt = table.Column<byte[]>(maxLength: 255, nullable: false),
                    Picture = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roadmap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Visibility = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roadmap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roadmap_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CopiedRoadmaps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    SourceRoadmapId = table.Column<int>(nullable: false),
                    TargetRoadmapId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopiedRoadmaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CopiedRoadmaps_Roadmap_SourceRoadmapId",
                        column: x => x.SourceRoadmapId,
                        principalTable: "Roadmap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoadmapCategoryRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    RoadmapId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadmapCategoryRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadmapCategoryRelation_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadmapCategoryRelation_Roadmap_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoadmapItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 525, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TargetDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    RoadmapId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadmapItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadmapItem_RoadmapItem_ParentId",
                        column: x => x.ParentId,
                        principalTable: "RoadmapItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoadmapItem_Roadmap_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoadmapTagRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(nullable: false),
                    RoadmapId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadmapTagRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadmapTagRelation_Roadmap_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadmapTagRelation_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CopiedRoadmaps_SourceRoadmapId",
                table: "CopiedRoadmaps",
                column: "SourceRoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmap_UserId",
                table: "Roadmap",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapCategoryRelation_CategoryId",
                table: "RoadmapCategoryRelation",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapCategoryRelation_RoadmapId",
                table: "RoadmapCategoryRelation",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapItem_ParentId",
                table: "RoadmapItem",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapItem_RoadmapId",
                table: "RoadmapItem",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapTagRelation_RoadmapId",
                table: "RoadmapTagRelation",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapTagRelation_TagId",
                table: "RoadmapTagRelation",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CopiedRoadmaps");

            migrationBuilder.DropTable(
                name: "RoadmapCategoryRelation");

            migrationBuilder.DropTable(
                name: "RoadmapItem");

            migrationBuilder.DropTable(
                name: "RoadmapTagRelation");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Roadmap");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
