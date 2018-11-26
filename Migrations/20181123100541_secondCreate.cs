using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllAddOnsAPI.Migrations
{
    public partial class secondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    PromID = table.Column<long>(nullable: false),
                    Promoname = table.Column<string>(nullable: true),
                    Price = table.Column<long>(nullable: false),
                    PromoDescription = table.Column<string>(nullable: true),
                    GroupId = table.Column<long>(nullable: false),
                    IsPromoRecurring = table.Column<string>(nullable: true),
                    RecurringPromoId = table.Column<string>(nullable: true),
                    Spiel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promos");
        }
    }
}
