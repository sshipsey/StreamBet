using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace StreamBet.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateSequence(
                name: "DefaultSequence",
                type: "bigint",
                startWith: 1L,
                incrementBy: 10);
            migration.CreateTable(
                name: "Streamer",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false),
                    Name = table.Column(type: "nvarchar(max)", nullable: true),
                    StreamLink = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streamer", x => x.Id);
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropSequence("DefaultSequence");
            migration.DropTable("Streamer");
        }
    }
}
