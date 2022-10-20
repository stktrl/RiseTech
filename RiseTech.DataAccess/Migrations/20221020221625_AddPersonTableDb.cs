using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RiseTech.DataAccess.Migrations
{
    public partial class AddPersonTableDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE REPORT
AS
BEGIN
Select konumkisi.Content as Sehir ,konum_kisi as KayitliKisi , ISNULL(tel_num,0)as KayitliTelefonNumarasi from (
(
	Select t1.Content , COUNT(*) as konum_kisi from 

	(select * from ContactInfos where InformationType=2) as t1
		left join
	(Select * from ContactInfos where InformationType =0) as t2
	on t1.PersonUUID=t2.PersonUUID group by t1.Content) as konumkisi
full join
(
	Select t3.Content  ,ISNULL(COUNT(*),0) as tel_num from 

(select * from ContactInfos where InformationType=2) as t3
		inner join
(Select * from ContactInfos where InformationType =0) as t4
on t3.PersonUUID=t4.PersonUUID  group by t3.Content) as telnum
on konumkisi.Content=telnum.Content) order by konum_kisi Desc
END";
            migrationBuilder.Sql(sp);

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.UUID);
                });


            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InformationType = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.UUID);
                    table.ForeignKey(
                        name: "FK_ContactInfos_Persons_PersonUUID",
                        column: x => x.PersonUUID,
                        principalTable: "Persons",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_PersonUUID",
                table: "ContactInfos",
                column: "PersonUUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
