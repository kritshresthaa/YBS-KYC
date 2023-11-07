using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Client.Migrations
{
    /// <inheritdoc />
    public partial class remake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: true),
                    WardNumber = table.Column<int>(type: "int", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrandFatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Spouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnualTransaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherBank = table.Column<bool>(type: "bit", nullable: false),
                    CrimalAct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaughterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaughterInLaw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherInLaw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PanNumber = table.Column<int>(type: "int", nullable: false),
                    SourceOfIncome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyDetails_UserDetails_userid",
                        column: x => x.userid,
                        principalTable: "UserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeftVerificationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F1 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeftVerificationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeftVerificationDetails_UserDetails_UserID",
                        column: x => x.UserID,
                        principalTable: "UserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RightVerificationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F2 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RightVerificationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RightVerificationDetails_UserDetails_UserID",
                        column: x => x.UserID,
                        principalTable: "UserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetails_userid",
                table: "FamilyDetails",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_LeftVerificationDetails_UserID",
                table: "LeftVerificationDetails",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RightVerificationDetails_UserID",
                table: "RightVerificationDetails",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyDetails");

            migrationBuilder.DropTable(
                name: "LeftVerificationDetails");

            migrationBuilder.DropTable(
                name: "RightVerificationDetails");

            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
