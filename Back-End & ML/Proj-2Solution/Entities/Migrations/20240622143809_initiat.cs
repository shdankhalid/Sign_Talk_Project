using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class initiat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modes",
                columns: table => new
                {
                    ModeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    A = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    B = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    G = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    H = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    I = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    J = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    K = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    M = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    N = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modes", x => x.ModeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensors_data",
                columns: table => new
                {
                    DataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sensor1_Value = table.Column<int>(type: "int", nullable: false),
                    Sensor2_Value = table.Column<int>(type: "int", nullable: false),
                    Sensor3_Value = table.Column<int>(type: "int", nullable: false),
                    Sensor4_Value = table.Column<int>(type: "int", nullable: false),
                    Sensor5_Value = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ModeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors_data", x => x.DataId);
                    table.ForeignKey(
                        name: "FK_Sensors_data_Modes_ModeId",
                        column: x => x.ModeId,
                        principalTable: "Modes",
                        principalColumn: "ModeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sensors_data_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmartGloves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartGloves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmartGloves_Users_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignClassifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SensorDataID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignClassifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignClassifications_Sensors_data_SensorDataID",
                        column: x => x.SensorDataID,
                        principalTable: "Sensors_data",
                        principalColumn: "DataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Modes",
                columns: new[] { "ModeId", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "ModeName", "N" },
                values: new object[,]
                {
                    { 1, "I need medicine.", "Waiting...", "I'm thirsty.", "Thank you.", "I need more.", "I like this.", "I don't like this.", "Call the doctor.", "I need less.", "Stop.", "I want to go out.", "I'm hungry.", "It's too noisy.", "Home", "I have a headache." },
                    { 2, "I need to see a doctor.", "Waiting...", "I need help with mobility.", "I am in pain.", "I need help with feeding.", "I am feeling better.", "I am feeling worse.", "Can you explain the treatment plan?", "Can you call my family?", "I am having trouble breathing.", "I need help finding the pharmacy.", "Could you adjust the room temperature?", "Can I have a glass of water?", "Hospital", "Can I have a pen and paper?" },
                    { 3, "Need help, please.", "Waiting...", "Please call an ambulance.", "Can you tell me the time?", "Are there any restaurants around here?", "Are there any Mosques around here?", "Where is the nearest hospital?", "Is there a pharmacy nearby?", "I need to find an ATM.", "Phone charger?", "Is there a police station nearby?", "Can you help me find a taxi?", "I'm lost, can you guide me?", "Street", "Where is the nearest subway station." }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DateTime", "Email", "Gender", "Name", "Password", "Phone" },
                values: new object[] { 1, "123 Main St", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmed12@gmail.com", true, "Ahmed", "123", "0123456789" });

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_data_ModeId",
                table: "Sensors_data",
                column: "ModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_data_UserID",
                table: "Sensors_data",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SignClassifications_SensorDataID",
                table: "SignClassifications",
                column: "SensorDataID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SmartGloves_OwnerID",
                table: "SmartGloves",
                column: "OwnerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignClassifications");

            migrationBuilder.DropTable(
                name: "SmartGloves");

            migrationBuilder.DropTable(
                name: "Sensors_data");

            migrationBuilder.DropTable(
                name: "Modes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
