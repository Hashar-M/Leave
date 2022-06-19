using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leave.Data.Migrations
{
    public partial class Addedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leave_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leave_Allocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number_of_Days = table.Column<int>(type: "int", nullable: false),
                    Date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Emp_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Leave_type_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave_Allocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leave_Allocations_AspNetUsers_Emp_Id",
                        column: x => x.Emp_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leave_Allocations_Leave_types_Leave_type_id",
                        column: x => x.Leave_type_id,
                        principalTable: "Leave_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leave_histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestingEmplId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypId = table.Column<int>(type: "int", nullable: false),
                    Date_requested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_actioned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedById = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave_histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leave_histories_AspNetUsers_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leave_histories_AspNetUsers_RequestingEmplId",
                        column: x => x.RequestingEmplId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leave_histories_Leave_types_LeaveTypId",
                        column: x => x.LeaveTypId,
                        principalTable: "Leave_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leave_Allocations_Emp_Id",
                table: "Leave_Allocations",
                column: "Emp_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_Allocations_Leave_type_id",
                table: "Leave_Allocations",
                column: "Leave_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_histories_ApprovedById",
                table: "Leave_histories",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_histories_LeaveTypId",
                table: "Leave_histories",
                column: "LeaveTypId");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_histories_RequestingEmplId",
                table: "Leave_histories",
                column: "RequestingEmplId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leave_Allocations");

            migrationBuilder.DropTable(
                name: "Leave_histories");

            migrationBuilder.DropTable(
                name: "Leave_types");
        }
    }
}
