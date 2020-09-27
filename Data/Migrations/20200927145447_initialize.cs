using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(maxLength: 500, nullable: false),
                    FriendlyUrl = table.Column<string>(maxLength: 500, nullable: false)
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
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(maxLength: 500, nullable: false),
                    FriendlyUrl = table.Column<string>(maxLength: 500, nullable: false)
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
                    Password = table.Column<string>(maxLength: 150, nullable: false),
                    Picture = table.Column<string>(maxLength: 255, nullable: false),
                    Status = table.Column<int>(nullable: false)
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
                    Name = table.Column<string>(maxLength: 500, nullable: false),
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
                name: "CopiedRoadmap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    SourceRoadmapId = table.Column<int>(nullable: false),
                    TargetRoadmapId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopiedRoadmap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CopiedRoadmap_Roadmap_SourceRoadmapId",
                        column: x => x.SourceRoadmapId,
                        principalTable: "Roadmap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CopiedRoadmap_Roadmap_TargetRoadmapId",
                        column: x => x.TargetRoadmapId,
                        principalTable: "Roadmap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoadmapCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    RoadmapId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadmapCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadmapCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadmapCategory_Roadmap_RoadmapId",
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
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TargetEndDate = table.Column<DateTime>(nullable: false),
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
                name: "RoadmapTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpDateTime = table.Column<DateTime>(nullable: false),
                    TagId = table.Column<int>(nullable: false),
                    RoadmapId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadmapTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadmapTag_Roadmap_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadmapTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CopiedRoadmap_SourceRoadmapId",
                table: "CopiedRoadmap",
                column: "SourceRoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_CopiedRoadmap_TargetRoadmapId",
                table: "CopiedRoadmap",
                column: "TargetRoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmap_UserId",
                table: "Roadmap",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapCategory_CategoryId",
                table: "RoadmapCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapCategory_RoadmapId",
                table: "RoadmapCategory",
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
                name: "IX_RoadmapTag_RoadmapId",
                table: "RoadmapTag",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapTag_TagId",
                table: "RoadmapTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CopiedRoadmap");

            migrationBuilder.DropTable(
                name: "RoadmapCategory");

            migrationBuilder.DropTable(
                name: "RoadmapItem");

            migrationBuilder.DropTable(
                name: "RoadmapTag");

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
