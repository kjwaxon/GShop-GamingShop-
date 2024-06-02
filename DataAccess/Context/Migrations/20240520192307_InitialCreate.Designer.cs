﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Context.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240520192307_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.Entities.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Gaming Furniture",
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4574),
                            Description = "Gaming Chairs,Desks and Stands",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Gaming Accessories",
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4592),
                            Description = "Gaming Headset,Keyboard,Mouse,Mousepad,Monitor,Microphone,Controller,Speaker,Camera",
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Gaming Computers",
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4594),
                            Description = "Gaming Laptops and Desktop Computers",
                            Status = 1
                        });
                });

            modelBuilder.Entity("ApplicationCore.Entities.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("integer");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4957),
                            Description = "The all-around office and gaming chair\nFits most body types\nErgonomic design\nHigh-quality faux leather\n2-year warranty",
                            ImagePath = "3fd2d97b-aea6-4609-aa59-66b4f616d1dd_dxracer_gladitor.jpg",
                            ProductName = "DxRacer Gladiator L Black & White Gaming Chair",
                            Quantity = 15,
                            Status = 1,
                            SubcategoryId = 1,
                            UnitPrice = 299.99000000000001
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4961),
                            Description = "More comfort. Deeper personalization. Exceptional durability. With research-backed design innovations engineered for serious performance, the Secretlab TITAN Evo is the first gaming chair of its kind. Elevate your game with pro-grade ergonomics — the choice of the world’s best players and professionals worldwide.",
                            ImagePath = "81521263-3c92-4c7c-836d-fc280a8695ce_secretlab_titanevo.jpg",
                            ProductName = "Secretlab TITAN Evo Gaming Chair",
                            Quantity = 10,
                            Status = 1,
                            SubcategoryId = 1,
                            UnitPrice = 519.99000000000001
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4963),
                            Description = "L Shaped Gaming Desk with LED Lights & Power Outlets, 50.4” Computer Desk with Monitor Stand & Carbon Fiber Surface, Corner Desk with Cup Holder, Gaming Table with Hooks",
                            ImagePath = "f7fed574-8f5e-44d3-b3ea-dc509e9938d9_sevenwarrior_desk.jpg",
                            ProductName = "Seven Warrior Gaming Desk",
                            Quantity = 8,
                            Status = 1,
                            SubcategoryId = 2,
                            UnitPrice = 99.989999999999995
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4965),
                            Description = "48” Gaming Desk with LED Lights & Power Outlets, Computer Desk with Monitor Stand & Storage Shelves",
                            ImagePath = "b7d3b501-acde-4b29-8aad-0b912865c008_odk_desk.jpg",
                            ProductName = "ODK Gaming Desk",
                            Quantity = 5,
                            Status = 1,
                            SubcategoryId = 2,
                            UnitPrice = 139.99000000000001
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4966),
                            Description = "Black Metal Headset Stand",
                            ImagePath = "18122bc6-3ee1-439c-a24d-a1d064fe4fb0_newolexx_headsetstand.jpg",
                            ProductName = "Newolexx Gaming Headset Stand",
                            Quantity = 25,
                            Status = 1,
                            SubcategoryId = 3,
                            UnitPrice = 8.9900000000000002
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4968),
                            Description = "ErGear Dual Monitor Mount up to 32” Screen, Max 10 kg Each Arm, Adjustable Dual Monitor Stand, Sturdy Steel Dual Monitor Arm with 180° Swivel, Tilt, 360° Rotation",
                            ImagePath = "48bb05e1-d96f-4a83-8a61-131d452fe404_ergear_monitorstand.jpg",
                            ProductName = "ErGear Dual Monitor Stand",
                            Quantity = 22,
                            Status = 1,
                            SubcategoryId = 3,
                            UnitPrice = 47.990000000000002
                        },
                        new
                        {
                            Id = 7,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4969),
                            Description = "Multi-Platform Gaming Headset - Signature Arctis Sound - ClearCast Gen 2 Mic - PC, PS5/PS4, Xbox Series X|S, Switch, Mobile",
                            ImagePath = "2a5a7979-f9f9-452f-a44f-62d0f73c4430_steelseries_arcticnova3.jpg",
                            ProductName = "SteelSeries New Arctis Nova 3 Gaming Headset",
                            Quantity = 12,
                            Status = 1,
                            SubcategoryId = 4,
                            UnitPrice = 98.950000000000003
                        },
                        new
                        {
                            Id = 8,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4970),
                            Description = "(2nd Generation) with Blue Voice, DTS Headphone 7.1 and 50 mm PRO-G Drivers, for PC, Xbox One, Xbox Series X|S,PS5,PS4, Nintendo Switch",
                            ImagePath = "6c3c8154-66f9-4eae-a8eb-7cb960173865_logitech_gprox.jpg",
                            ProductName = "Logitech G PRO X Gaming Headset",
                            Quantity = 9,
                            Status = 1,
                            SubcategoryId = 4,
                            UnitPrice = 86.780000000000001
                        },
                        new
                        {
                            Id = 9,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4972),
                            Description = "RGB Membrane Wired Gaming Keyboard – Quiet, Responsive Switches – Spill Resistance – Ten-Zone RGB – Media Keys – iCUE Compatible – QWERTY NA – PC, Mac",
                            ImagePath = "39adc990-04ed-49c6-97bc-45bbcf5d190f_corsair_k55.jpg",
                            ProductName = "Corsair K55 Gaming Keyboard",
                            Quantity = 10,
                            Status = 1,
                            SubcategoryId = 5,
                            UnitPrice = 39.990000000000002
                        },
                        new
                        {
                            Id = 10,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4973),
                            Description = "TKL Gaming Keyboard: Low-Profile Keys - Mecha-Membrane Switches - UV-Coated Keycaps - Backlit Media Keys - 8-Zone RGB Lighting - Spill-Resistant - Magnetic Wrist Wrest",
                            ImagePath = "a9f4706c-762f-4053-94c0-879f534681ce_razer_ornatav3.jpg",
                            ProductName = "Razer Ornata V3 Gaming Keyboard",
                            Quantity = 13,
                            Status = 1,
                            SubcategoryId = 5,
                            UnitPrice = 59.990000000000002
                        },
                        new
                        {
                            Id = 11,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4974),
                            Description = "Ultra-Lightweight, 59g, Honeycomb Shell, Hex Design, RGB, HyperFlex USB Cable, Up to 16000 DPI, 6 Programmable Buttons",
                            ImagePath = "c25ca3b8-b8ee-4f04-924a-7dd2642f78e4_hyperx_pulsefirehaste.jpg",
                            ProductName = "HyperX Pulsefire Haste Gaming Mouse",
                            Quantity = 11,
                            Status = 1,
                            SubcategoryId = 6,
                            UnitPrice = 39.990000000000002
                        },
                        new
                        {
                            Id = 12,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4976),
                            Description = "High Performance Wired Gaming Mouse, HERO 25K Sensor, 25,600 DPI, RGB, Adjustable Weights, 11 Programmable Buttons, On-Board Memory, PC / Mac",
                            ImagePath = "2581f2b7-fb87-4494-9f40-c0774d1cb57c_logitech_g502hero.jpg",
                            ProductName = "Logitech G502 HERO Gaming Mouse",
                            Quantity = 22,
                            Status = 1,
                            SubcategoryId = 6,
                            UnitPrice = 34.990000000000002
                        },
                        new
                        {
                            Id = 13,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4977),
                            Description = "Large Cloth - Optimized For Gaming Sensors",
                            ImagePath = "4522b151-b587-4563-8d11-0893c820c10e_steelseries_qck.jpg",
                            ProductName = "SteelSeries QcK Gaming Mousepad",
                            Quantity = 25,
                            Status = 1,
                            SubcategoryId = 7,
                            UnitPrice = 14.57
                        },
                        new
                        {
                            Id = 14,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4978),
                            Description = "Optimized for Gaming Sensors, Moderate Surface Friction, Non-Slip Mouse Mat - Black",
                            ImagePath = "410fd339-1d32-471e-91ac-79879385914a_logitech_g240.jpg",
                            ProductName = "Logitech G240 Cloth Gaming Mousepad",
                            Quantity = 23,
                            Status = 1,
                            SubcategoryId = 7,
                            UnitPrice = 16.68
                        },
                        new
                        {
                            Id = 15,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4980),
                            Description = "23.8” 1080P 165Hz 1ms Gaming Monitor with FreeSync",
                            ImagePath = "791b5fb4-3a81-4d40-b32d-f5cc620b760c_asus_vg247q1a.jpg",
                            ProductName = "ASUS VG247Q1A Gaming Monitor",
                            Quantity = 17,
                            Status = 1,
                            SubcategoryId = 8,
                            UnitPrice = 119.0
                        },
                        new
                        {
                            Id = 16,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4981),
                            Description = "27” Curved 1080P, 1ms, 250Hz, FreeSync, HDMI, DisplayPort, Anti-Flicker, Anti-Glare, HDR Ready,Black",
                            ImagePath = "9fb194d1-a3ca-4057-bc94-d1654e73df74_msi_g27c4x.jpg",
                            ProductName = "MSI G27C4X Curved Gaming Monitor",
                            Quantity = 14,
                            Status = 1,
                            SubcategoryId = 8,
                            UnitPrice = 163.19
                        },
                        new
                        {
                            Id = 17,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4982),
                            Description = "USB Microphone for Gaming, Streaming, Podcasting, Twitch, YouTube, Discord, Recording for PC and Mac, 4 Polar Patterns, Studio Quality Sound, Plug & Play-Blackout",
                            ImagePath = "2446aefa-5634-4e2c-8a41-837a0716cf83_logitech_blueyeti.jpg",
                            ProductName = "Logitech Blue Yeti Gaming Microphone",
                            Quantity = 4,
                            Status = 1,
                            SubcategoryId = 9,
                            UnitPrice = 98.989999999999995
                        },
                        new
                        {
                            Id = 18,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4984),
                            Description = "USB Condenser Gaming Microphone, for PC, PS4, PS5 and Mac, Tap-to-Mute Sensor, Cardioid Polar Pattern, great for Streaming, Podcasts, Twitch, YouTube, Discord,Black",
                            ImagePath = "e5fdac31-72ae-4b57-a638-456c3af13365_hyperx_solocast.jpg",
                            ProductName = "HyperX SoloCast Gaming Microphone",
                            Quantity = 3,
                            Status = 1,
                            SubcategoryId = 9,
                            UnitPrice = 87.75
                        },
                        new
                        {
                            Id = 19,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4985),
                            Description = "Carbon Black – Xbox Series X|S, Xbox One, Windows PC, Android, and iOS",
                            ImagePath = "0f7bd830-7f7d-4bc4-88c1-41c7ad5d99aa_xbox_core.jpg",
                            ProductName = "Xbox Core Wireless Gaming Controller",
                            Quantity = 33,
                            Status = 1,
                            SubcategoryId = 10,
                            UnitPrice = 43.18
                        },
                        new
                        {
                            Id = 20,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4986),
                            Description = "Xbox Series X|S, Xbox One, PC: Remappable Front-Facing Buttons - Mecha-Tactile Action Buttons and D-Pad - Trigger Stop-Switches - White",
                            ImagePath = "f0806094-9f41-4736-af14-9d5c7f09195e_razer_wolverinev2.jpg",
                            ProductName = "Razer Wolverine V2 Wired Gaming Controller",
                            Quantity = 9,
                            Status = 1,
                            SubcategoryId = 10,
                            UnitPrice = 74.0
                        },
                        new
                        {
                            Id = 21,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4988),
                            Description = "Soundbar Speaker - Bluetooth, USB-C, Chroma RGB - Black",
                            ImagePath = "02f1f821-003e-4599-90ff-e3a70a790cd6_razer_leviathanv2.jpg",
                            ProductName = "Razer Leviathan V2 Gaming Speaker",
                            Quantity = 3,
                            Status = 1,
                            SubcategoryId = 11,
                            UnitPrice = 94.989999999999995
                        },
                        new
                        {
                            Id = 22,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4989),
                            Description = "2.0 Channel PC Computer Stereo Speaker with 6 Colorful LED Modes, Enhanced Sound and Easy-Access Volume Control, USB Powered w/ 3.5mm Cable",
                            ImagePath = "1ab254fc-4757-4e56-b356-38d0b08eab47_redragon_gs520.jpg",
                            ProductName = "Redragon GS520 Gaming Speaker",
                            Quantity = 14,
                            Status = 1,
                            SubcategoryId = 11,
                            UnitPrice = 32.990000000000002
                        },
                        new
                        {
                            Id = 23,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4990),
                            Description = "1080P Webcam with Microphone, Adjustable FOV, Zoom, Software Control & Privacy Cover, USB HD Computer Web Camera, Plug and Play, for Zoom/Skype/Teams, Conferencing and Video Calling",
                            ImagePath = "f7fb93da-5fe5-4cb4-bc54-1c88cccd27b1_nexigo_n60.jpg",
                            ProductName = "NexiGo N60 Gaming Camera",
                            Quantity = 30,
                            Status = 1,
                            SubcategoryId = 12,
                            UnitPrice = 29.98
                        },
                        new
                        {
                            Id = 24,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4991),
                            Description = "1080P 60FPS Streaming Camera Webcam with Microphone and Fill RGB Light,Autofocus,Works with Laptop/Desktop Computer/Winsdows/Mac OS/PC",
                            ImagePath = "c13a0919-5e0f-4802-9ad5-13ad5addacd7_nbpower_camera.jpg",
                            ProductName = "NBPOWER Gaming Camera",
                            Quantity = 21,
                            Status = 1,
                            SubcategoryId = 12,
                            UnitPrice = 33.990000000000002
                        },
                        new
                        {
                            Id = 25,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4993),
                            Description = "15.6” FHD 144Hz Display, NVIDIA® GeForce RTX™ 2050, AMD Ryzen™ 5 7535HS, 8GB DDR5, 512GB PCIe® Gen4 NVMe™ SSD, Wi-Fi 6, Windows 11",
                            ImagePath = "d51ab2c2-e81f-411a-9317-cc60fa85aecb_asus_a15.jpg",
                            ProductName = "ASUS TUF Gaming A15 (2024) Gaming Laptop",
                            Quantity = 10,
                            Status = 1,
                            SubcategoryId = 13,
                            UnitPrice = 643.49000000000001
                        },
                        new
                        {
                            Id = 26,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4994),
                            Description = "16” QHD+ 240Hz Display, Intel Core i9-13900HK, 32GB LPDDR5 RAM, 1TB SSD, NVIDIA GeForce RTX 4080 12GB GDDR6, Windows 11 Home - Lunar Silver",
                            ImagePath = "eed0728e-0c0b-4073-b172-41a8c1bd3002_alienware_x16r1.jpg",
                            ProductName = "Alienware X16 R1 Gaming Laptop",
                            Quantity = 18,
                            Status = 1,
                            SubcategoryId = 13,
                            UnitPrice = 2042.8499999999999
                        },
                        new
                        {
                            Id = 27,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4995),
                            Description = "Intel Core i5-11600KF 3.9GHz, GeForce RTX 3060 12GB, 16GB DDR4, 500GB PCI-E NVMe SSD, 1TB HDD, WiFi Ready & Win 11 Home",
                            ImagePath = "6201ce85-239e-4fea-95d1-20937fb6ef69_cyberpower_xtreme.jpg",
                            ProductName = "CYBERPOWERPC Gamer Xtreme VR Gaming Desktop Computer",
                            Quantity = 7,
                            Status = 1,
                            SubcategoryId = 14,
                            UnitPrice = 1399.0
                        },
                        new
                        {
                            Id = 28,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4997),
                            Description = "i7 14700KF, RTX 4070 12GB, 32 GB DDR5 5600 RGB (16GB x 2), 2TB NVME, WiFi Ready, Windows 11 Home",
                            ImagePath = "803a26e8-c42d-4aa7-af43-07fcb23da58b_ibuypower_y60.jpg",
                            ProductName = "iBUYPOWER Y60 Gaming Desktop Computer",
                            Quantity = 9,
                            Status = 1,
                            SubcategoryId = 14,
                            UnitPrice = 1899.95
                        });
                });

            modelBuilder.Entity("ApplicationCore.Entities.Concrete.Subcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("SubcategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4810),
                            Status = 1,
                            SubcategoryName = "Chairs"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4815),
                            Status = 1,
                            SubcategoryName = "Desks"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4817),
                            Status = 1,
                            SubcategoryName = "Stands"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4818),
                            Status = 1,
                            SubcategoryName = "Headsets"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4819),
                            Status = 1,
                            SubcategoryName = "Keyboards"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4820),
                            Status = 1,
                            SubcategoryName = "Mice"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4821),
                            Status = 1,
                            SubcategoryName = "Mousepads"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4823),
                            Status = 1,
                            SubcategoryName = "Monitors"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4824),
                            Status = 1,
                            SubcategoryName = "Microphones"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4825),
                            Status = 1,
                            SubcategoryName = "Controllers"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4826),
                            Status = 1,
                            SubcategoryName = "Speakers"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4827),
                            Status = 1,
                            SubcategoryName = "Cameras"
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4828),
                            Status = 1,
                            SubcategoryName = "Laptops"
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2024, 5, 20, 22, 23, 7, 376, DateTimeKind.Local).AddTicks(4829),
                            Status = 1,
                            SubcategoryName = "Desktops"
                        });
                });

            modelBuilder.Entity("ApplicationCore.Entities.Concrete.Product", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Concrete.Subcategory", "Subcategory")
                        .WithMany("Products")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Concrete.Subcategory", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Concrete.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Concrete.Category", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Concrete.Subcategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
