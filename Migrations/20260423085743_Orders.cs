using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeliveryOrdersApp.Migrations
{
    /// <inheritdoc />
    public partial class Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orderNumber = table.Column<decimal>(type: "numeric", maxLength: 10, nullable: false),
                    senderSity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    senderAdress = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    recipientSity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    recipientAdress = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    pickupDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
