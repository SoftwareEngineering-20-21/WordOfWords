using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WorldOfWords.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "topic",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "character varying", nullable: true),
                    email = table.Column<string>(type: "character varying", nullable: true),
                    password = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "card",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    topic_id = table.Column<int>(nullable: true),
                    image = table.Column<byte[]>(nullable: true),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    description = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card", x => x.id);
                    table.ForeignKey(
                        name: "card_topic_id_fkey",
                        column: x => x.topic_id,
                        principalTable: "topic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_card",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    card_id = table.Column<int>(nullable: true),
                    answer_date = table.Column<DateTime>(type: "date", nullable: true),
                    answer = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_card_pkey", x => x.user_id);
                    table.ForeignKey(
                        name: "user_card_card_id_fkey",
                        column: x => x.card_id,
                        principalTable: "card",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_card_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_card_topic_id",
                table: "card",
                column: "topic_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_card_card_id",
                table: "user_card",
                column: "card_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_card");

            migrationBuilder.DropTable(
                name: "card");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "topic");
        }
    }
}
