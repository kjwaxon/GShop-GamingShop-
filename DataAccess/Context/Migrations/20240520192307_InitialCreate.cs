using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubcategoryName = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UnitPrice = table.Column<double>(type: "double precision", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    SubcategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedDate", "DeletedDate", "Description", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Gaming Furniture", new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4574), null, "Gaming Chairs,Desks and Stands", 1, null },
                    { 2, "Gaming Accessories", new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4592), null, "Gaming Headset,Keyboard,Mouse,Mousepad,Monitor,Microphone,Controller,Speaker,Camera", 1, null },
                    { 3, "Gaming Computers", new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4594), null, "Gaming Laptops and Desktop Computers", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Status", "SubcategoryName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4810), null, 1, "Chairs", null },
                    { 2, 1, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4815), null, 1, "Desks", null },
                    { 3, 1, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4817), null, 1, "Stands", null },
                    { 4, 2, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4818), null, 1, "Headsets", null },
                    { 5, 2, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4819), null, 1, "Keyboards", null },
                    { 6, 2, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4820), null, 1, "Mice", null },
                    { 7, 2, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4821), null, 1, "Mousepads", null },
                    { 8, 2, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4823), null, 1, "Monitors", null },
                    { 9, 2, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4824), null, 1, "Microphones", null },
                    { 10, 2, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4825), null, 1, "Controllers", null },
                    { 11, 2, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4826), null, 1, "Speakers", null },
                    { 12, 2, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4827), null, 1, "Cameras", null },
                    { 13, 3, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4828), null, 1, "Laptops", null },
                    { 14, 3, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4829), null, 1, "Desktops", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ImagePath", "ProductName", "Quantity", "Status", "SubcategoryId", "UnitPrice", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4957), null, "The all-around office and gaming chair\nFits most body types\nErgonomic design\nHigh-quality faux leather\n2-year warranty", "3fd2d97b-aea6-4609-aa59-66b4f616d1dd_dxracer_gladitor.jpg", "DxRacer Gladiator L Black & White Gaming Chair", 15, 1, 1, 299.99000000000001, null },
                    { 2, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4961), null, "More comfort. Deeper personalization. Exceptional durability. With research-backed design innovations engineered for serious performance, the Secretlab TITAN Evo is the first gaming chair of its kind. Elevate your game with pro-grade ergonomics — the choice of the world’s best players and professionals worldwide.", "81521263-3c92-4c7c-836d-fc280a8695ce_secretlab_titanevo.jpg", "Secretlab TITAN Evo Gaming Chair", 10, 1, 1, 519.99000000000001, null },
                    { 3, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4963), null, "L Shaped Gaming Desk with LED Lights & Power Outlets, 50.4” Computer Desk with Monitor Stand & Carbon Fiber Surface, Corner Desk with Cup Holder, Gaming Table with Hooks", "f7fed574-8f5e-44d3-b3ea-dc509e9938d9_sevenwarrior_desk.jpg", "Seven Warrior Gaming Desk", 8, 1, 2, 99.989999999999995, null },
                    { 4, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4965), null, "48” Gaming Desk with LED Lights & Power Outlets, Computer Desk with Monitor Stand & Storage Shelves", "b7d3b501-acde-4b29-8aad-0b912865c008_odk_desk.jpg", "ODK Gaming Desk", 5, 1, 2, 139.99000000000001, null },
                    { 5, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4966), null, "Black Metal Headset Stand", "18122bc6-3ee1-439c-a24d-a1d064fe4fb0_newolexx_headsetstand.jpg", "Newolexx Gaming Headset Stand", 25, 1, 3, 8.9900000000000002, null },
                    { 6, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4968), null, "ErGear Dual Monitor Mount up to 32” Screen, Max 10 kg Each Arm, Adjustable Dual Monitor Stand, Sturdy Steel Dual Monitor Arm with 180° Swivel, Tilt, 360° Rotation", "48bb05e1-d96f-4a83-8a61-131d452fe404_ergear_monitorstand.jpg", "ErGear Dual Monitor Stand", 22, 1, 3, 47.990000000000002, null },
                    { 7, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4969), null, "Multi-Platform Gaming Headset - Signature Arctis Sound - ClearCast Gen 2 Mic - PC, PS5/PS4, Xbox Series X|S, Switch, Mobile", "2a5a7979-f9f9-452f-a44f-62d0f73c4430_steelseries_arcticnova3.jpg", "SteelSeries New Arctis Nova 3 Gaming Headset", 12, 1, 4, 98.950000000000003, null },
                    { 8, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4970), null, "(2nd Generation) with Blue Voice, DTS Headphone 7.1 and 50 mm PRO-G Drivers, for PC, Xbox One, Xbox Series X|S,PS5,PS4, Nintendo Switch", "6c3c8154-66f9-4eae-a8eb-7cb960173865_logitech_gprox.jpg", "Logitech G PRO X Gaming Headset", 9, 1, 4, 86.780000000000001, null },
                    { 9, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4972), null, "RGB Membrane Wired Gaming Keyboard – Quiet, Responsive Switches – Spill Resistance – Ten-Zone RGB – Media Keys – iCUE Compatible – QWERTY NA – PC, Mac", "39adc990-04ed-49c6-97bc-45bbcf5d190f_corsair_k55.jpg", "Corsair K55 Gaming Keyboard", 10, 1, 5, 39.990000000000002, null },
                    { 10, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4973), null, "TKL Gaming Keyboard: Low-Profile Keys - Mecha-Membrane Switches - UV-Coated Keycaps - Backlit Media Keys - 8-Zone RGB Lighting - Spill-Resistant - Magnetic Wrist Wrest", "a9f4706c-762f-4053-94c0-879f534681ce_razer_ornatav3.jpg", "Razer Ornata V3 Gaming Keyboard", 13, 1, 5, 59.990000000000002, null },
                    { 11, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4974), null, "Ultra-Lightweight, 59g, Honeycomb Shell, Hex Design, RGB, HyperFlex USB Cable, Up to 16000 DPI, 6 Programmable Buttons", "c25ca3b8-b8ee-4f04-924a-7dd2642f78e4_hyperx_pulsefirehaste.jpg", "HyperX Pulsefire Haste Gaming Mouse", 11, 1, 6, 39.990000000000002, null },
                    { 12, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4976), null, "High Performance Wired Gaming Mouse, HERO 25K Sensor, 25,600 DPI, RGB, Adjustable Weights, 11 Programmable Buttons, On-Board Memory, PC / Mac", "2581f2b7-fb87-4494-9f40-c0774d1cb57c_logitech_g502hero.jpg", "Logitech G502 HERO Gaming Mouse", 22, 1, 6, 34.990000000000002, null },
                    { 13, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4977), null, "Large Cloth - Optimized For Gaming Sensors", "4522b151-b587-4563-8d11-0893c820c10e_steelseries_qck.jpg", "SteelSeries QcK Gaming Mousepad", 25, 1, 7, 14.57, null },
                    { 14, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4978), null, "Optimized for Gaming Sensors, Moderate Surface Friction, Non-Slip Mouse Mat - Black", "410fd339-1d32-471e-91ac-79879385914a_logitech_g240.jpg", "Logitech G240 Cloth Gaming Mousepad", 23, 1, 7, 16.68, null },
                    { 15, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4980), null, "23.8” 1080P 165Hz 1ms Gaming Monitor with FreeSync", "791b5fb4-3a81-4d40-b32d-f5cc620b760c_asus_vg247q1a.jpg", "ASUS VG247Q1A Gaming Monitor", 17, 1, 8, 119.0, null },
                    { 16, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4981), null, "27” Curved 1080P, 1ms, 250Hz, FreeSync, HDMI, DisplayPort, Anti-Flicker, Anti-Glare, HDR Ready,Black", "9fb194d1-a3ca-4057-bc94-d1654e73df74_msi_g27c4x.jpg", "MSI G27C4X Curved Gaming Monitor", 14, 1, 8, 163.19, null },
                    { 17, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4982), null, "USB Microphone for Gaming, Streaming, Podcasting, Twitch, YouTube, Discord, Recording for PC and Mac, 4 Polar Patterns, Studio Quality Sound, Plug & Play-Blackout", "2446aefa-5634-4e2c-8a41-837a0716cf83_logitech_blueyeti.jpg", "Logitech Blue Yeti Gaming Microphone", 4, 1, 9, 98.989999999999995, null },
                    { 18, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4984), null, "USB Condenser Gaming Microphone, for PC, PS4, PS5 and Mac, Tap-to-Mute Sensor, Cardioid Polar Pattern, great for Streaming, Podcasts, Twitch, YouTube, Discord,Black", "e5fdac31-72ae-4b57-a638-456c3af13365_hyperx_solocast.jpg", "HyperX SoloCast Gaming Microphone", 3, 1, 9, 87.75, null },
                    { 19, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4985), null, "Carbon Black – Xbox Series X|S, Xbox One, Windows PC, Android, and iOS", "0f7bd830-7f7d-4bc4-88c1-41c7ad5d99aa_xbox_core.jpg", "Xbox Core Wireless Gaming Controller", 33, 1, 10, 43.18, null },
                    { 20, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4986), null, "Xbox Series X|S, Xbox One, PC: Remappable Front-Facing Buttons - Mecha-Tactile Action Buttons and D-Pad - Trigger Stop-Switches - White", "f0806094-9f41-4736-af14-9d5c7f09195e_razer_wolverinev2.jpg", "Razer Wolverine V2 Wired Gaming Controller", 9, 1, 10, 74.0, null },
                    { 21, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4988), null, "Soundbar Speaker - Bluetooth, USB-C, Chroma RGB - Black", "02f1f821-003e-4599-90ff-e3a70a790cd6_razer_leviathanv2.jpg", "Razer Leviathan V2 Gaming Speaker", 3, 1, 11, 94.989999999999995, null },
                    { 22, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4989), null, "2.0 Channel PC Computer Stereo Speaker with 6 Colorful LED Modes, Enhanced Sound and Easy-Access Volume Control, USB Powered w/ 3.5mm Cable", "1ab254fc-4757-4e56-b356-38d0b08eab47_redragon_gs520.jpg", "Redragon GS520 Gaming Speaker", 14, 1, 11, 32.990000000000002, null },
                    { 23, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4990), null, "1080P Webcam with Microphone, Adjustable FOV, Zoom, Software Control & Privacy Cover, USB HD Computer Web Camera, Plug and Play, for Zoom/Skype/Teams, Conferencing and Video Calling", "f7fb93da-5fe5-4cb4-bc54-1c88cccd27b1_nexigo_n60.jpg", "NexiGo N60 Gaming Camera", 30, 1, 12, 29.98, null },
                    { 24, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4991), null, "1080P 60FPS Streaming Camera Webcam with Microphone and Fill RGB Light,Autofocus,Works with Laptop/Desktop Computer/Winsdows/Mac OS/PC", "c13a0919-5e0f-4802-9ad5-13ad5addacd7_nbpower_camera.jpg", "NBPOWER Gaming Camera", 21, 1, 12, 33.990000000000002, null },
                    { 25, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4993), null, "15.6” FHD 144Hz Display, NVIDIA® GeForce RTX™ 2050, AMD Ryzen™ 5 7535HS, 8GB DDR5, 512GB PCIe® Gen4 NVMe™ SSD, Wi-Fi 6, Windows 11", "d51ab2c2-e81f-411a-9317-cc60fa85aecb_asus_a15.jpg", "ASUS TUF Gaming A15 (2024) Gaming Laptop", 10, 1, 13, 643.49000000000001, null },
                    { 26, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4994), null, "16” QHD+ 240Hz Display, Intel Core i9-13900HK, 32GB LPDDR5 RAM, 1TB SSD, NVIDIA GeForce RTX 4080 12GB GDDR6, Windows 11 Home - Lunar Silver", "eed0728e-0c0b-4073-b172-41a8c1bd3002_alienware_x16r1.jpg", "Alienware X16 R1 Gaming Laptop", 18, 1, 13, 2042.8499999999999, null },
                    { 27, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4995), null, "Intel Core i5-11600KF 3.9GHz, GeForce RTX 3060 12GB, 16GB DDR4, 500GB PCI-E NVMe SSD, 1TB HDD, WiFi Ready & Win 11 Home", "6201ce85-239e-4fea-95d1-20937fb6ef69_cyberpower_xtreme.jpg", "CYBERPOWERPC Gamer Xtreme VR Gaming Desktop Computer", 7, 1, 14, 1399.0, null },
                    { 28, new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4997), null, "i7 14700KF, RTX 4070 12GB, 32 GB DDR5 5600 RGB (16GB x 2), 2TB NVME, WiFi Ready, Windows 11 Home", "803a26e8-c42d-4aa7-af43-07fcb23da58b_ibuypower_y60.jpg", "iBUYPOWER Y60 Gaming Desktop Computer", 9, 1, 14, 1899.95, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubcategoryId",
                table: "Products",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
