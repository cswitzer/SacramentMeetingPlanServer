using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlannerServer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    HymnNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HymnTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HymnType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.HymnNumber);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "SacramentMeetingPlan",
                columns: table => new
                {
                    SacramentMeetingPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpeningHymnId = table.Column<int>(type: "int", nullable: false),
                    SacramentHymnId = table.Column<int>(type: "int", nullable: false),
                    IntermediateHymnId = table.Column<int>(type: "int", nullable: true),
                    ClosingHymnId = table.Column<int>(type: "int", nullable: false),
                    ConductingLeaderId = table.Column<int>(type: "int", nullable: false),
                    OpeningPrayerId = table.Column<int>(type: "int", nullable: false),
                    SacramentPrayerId = table.Column<int>(type: "int", nullable: false),
                    ClosingPrayerId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SacramentMeetingPlan", x => x.SacramentMeetingPlanId);
                    table.ForeignKey(
                        name: "FK_SacramentMeetingPlan_Hymn_ClosingHymnId",
                        column: x => x.ClosingHymnId,
                        principalTable: "Hymn",
                        principalColumn: "HymnNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SacramentMeetingPlan_Hymn_IntermediateHymnId",
                        column: x => x.IntermediateHymnId,
                        principalTable: "Hymn",
                        principalColumn: "HymnNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SacramentMeetingPlan_Hymn_OpeningHymnId",
                        column: x => x.OpeningHymnId,
                        principalTable: "Hymn",
                        principalColumn: "HymnNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SacramentMeetingPlan_Hymn_SacramentHymnId",
                        column: x => x.SacramentHymnId,
                        principalTable: "Hymn",
                        principalColumn: "HymnNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SacramentMeetingPlan_Member_ClosingPrayerId",
                        column: x => x.ClosingPrayerId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SacramentMeetingPlan_Member_ConductingLeaderId",
                        column: x => x.ConductingLeaderId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SacramentMeetingPlan_Member_OpeningPrayerId",
                        column: x => x.OpeningPrayerId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SacramentMeetingPlan_Member_SacramentPrayerId",
                        column: x => x.SacramentPrayerId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    SacramentMeetingPlanId = table.Column<int>(type: "int", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerId);
                    table.ForeignKey(
                        name: "FK_Speaker_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Speaker_SacramentMeetingPlan_SacramentMeetingPlanId",
                        column: x => x.SacramentMeetingPlanId,
                        principalTable: "SacramentMeetingPlan",
                        principalColumn: "SacramentMeetingPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeetingPlan_ClosingHymnId",
                table: "SacramentMeetingPlan",
                column: "ClosingHymnId");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeetingPlan_ClosingPrayerId",
                table: "SacramentMeetingPlan",
                column: "ClosingPrayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeetingPlan_ConductingLeaderId",
                table: "SacramentMeetingPlan",
                column: "ConductingLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeetingPlan_IntermediateHymnId",
                table: "SacramentMeetingPlan",
                column: "IntermediateHymnId");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeetingPlan_OpeningHymnId",
                table: "SacramentMeetingPlan",
                column: "OpeningHymnId");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeetingPlan_OpeningPrayerId",
                table: "SacramentMeetingPlan",
                column: "OpeningPrayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeetingPlan_SacramentHymnId",
                table: "SacramentMeetingPlan",
                column: "SacramentHymnId");

            migrationBuilder.CreateIndex(
                name: "IX_SacramentMeetingPlan_SacramentPrayerId",
                table: "SacramentMeetingPlan",
                column: "SacramentPrayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_MemberId",
                table: "Speaker",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_SacramentMeetingPlanId",
                table: "Speaker",
                column: "SacramentMeetingPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "SacramentMeetingPlan");

            migrationBuilder.DropTable(
                name: "Hymn");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
