using ApplicationCore.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SeedData.EntitySeedData
{
    public class ProductSeedData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
                (
                    new Product
                    {
                        Id = 1,
                        ProductName = "DxRacer Gladiator L Black & White Gaming Chair",
                        Description = "The all-around office and gaming chair\nFits most body types\nErgonomic design\nHigh-quality faux leather\n2-year warranty",
                        UnitPrice = 299.99,
                        Quantity = 15,
                        ImagePath = "3fd2d97b-aea6-4609-aa59-66b4f616d1dd_dxracer_gladitor.jpg",
                        SubcategoryId = 1
                    },
                    new Product
                    {
                        Id = 2,
                        ProductName = "Secretlab TITAN Evo Gaming Chair",
                        Description = "More comfort. Deeper personalization. Exceptional durability. With research-backed design innovations engineered for serious performance, the Secretlab TITAN Evo is the first gaming chair of its kind. Elevate your game with pro-grade ergonomics — the choice of the world’s best players and professionals worldwide.",
                        UnitPrice = 519.99,
                        Quantity = 10,
                        ImagePath = "81521263-3c92-4c7c-836d-fc280a8695ce_secretlab_titanevo.jpg",
                        SubcategoryId = 1
                    },
                    new Product
                    {
                        Id = 3,
                        ProductName = "Seven Warrior Gaming Desk",
                        Description = "L Shaped Gaming Desk with LED Lights & Power Outlets, 50.4” Computer Desk with Monitor Stand & Carbon Fiber Surface, Corner Desk with Cup Holder, Gaming Table with Hooks",
                        UnitPrice = 99.99,
                        Quantity = 8,
                        ImagePath = "f7fed574-8f5e-44d3-b3ea-dc509e9938d9_sevenwarrior_desk.jpg",
                        SubcategoryId = 2

                    },
                    new Product
                    {
                        Id = 4,
                        ProductName = "ODK Gaming Desk",
                        Description = "48” Gaming Desk with LED Lights & Power Outlets, Computer Desk with Monitor Stand & Storage Shelves",
                        UnitPrice = 139.99,
                        Quantity = 5,
                        ImagePath = "b7d3b501-acde-4b29-8aad-0b912865c008_odk_desk.jpg",
                        SubcategoryId = 2
                    },
                    new Product
                    {
                        Id = 5,
                        ProductName = "Newolexx Gaming Headset Stand",
                        Description = "Black Metal Headset Stand",
                        UnitPrice = 8.99,
                        Quantity = 25,
                        ImagePath = "18122bc6-3ee1-439c-a24d-a1d064fe4fb0_newolexx_headsetstand.jpg",
                        SubcategoryId = 3
                    },
                    new Product
                    {
                        Id = 6,
                        ProductName = "ErGear Dual Monitor Stand",
                        Description = "ErGear Dual Monitor Mount up to 32” Screen, Max 10 kg Each Arm, Adjustable Dual Monitor Stand, Sturdy Steel Dual Monitor Arm with 180° Swivel, Tilt, 360° Rotation",
                        UnitPrice = 47.99,
                        Quantity = 22,
                        ImagePath = "48bb05e1-d96f-4a83-8a61-131d452fe404_ergear_monitorstand.jpg",
                        SubcategoryId = 3
                    },
                    new Product
                    {
                        Id = 7,
                        ProductName = "SteelSeries New Arctis Nova 3 Gaming Headset",
                        Description = "Multi-Platform Gaming Headset - Signature Arctis Sound - ClearCast Gen 2 Mic - PC, PS5/PS4, Xbox Series X|S, Switch, Mobile",
                        UnitPrice = 98.95,
                        Quantity = 12,
                        ImagePath = "2a5a7979-f9f9-452f-a44f-62d0f73c4430_steelseries_arcticnova3.jpg",
                        SubcategoryId = 4
                    },
                    new Product
                    {
                        Id = 8,
                        ProductName = "Logitech G PRO X Gaming Headset",
                        Description = "(2nd Generation) with Blue Voice, DTS Headphone 7.1 and 50 mm PRO-G Drivers, for PC, Xbox One, Xbox Series X|S,PS5,PS4, Nintendo Switch",
                        UnitPrice = 86.78,
                        Quantity = 9,
                        ImagePath = "6c3c8154-66f9-4eae-a8eb-7cb960173865_logitech_gprox.jpg",
                        SubcategoryId = 4
                    },
                    new Product
                    {
                        Id = 9,
                        ProductName = "Corsair K55 Gaming Keyboard",
                        Description = "RGB Membrane Wired Gaming Keyboard – Quiet, Responsive Switches – Spill Resistance – Ten-Zone RGB – Media Keys – iCUE Compatible – QWERTY NA – PC, Mac",
                        UnitPrice = 39.99,
                        Quantity = 10,
                        ImagePath = "39adc990-04ed-49c6-97bc-45bbcf5d190f_corsair_k55.jpg",
                        SubcategoryId = 5
                    },
                    new Product
                    {
                        Id = 10,
                        ProductName = "Razer Ornata V3 Gaming Keyboard",
                        Description = "TKL Gaming Keyboard: Low-Profile Keys - Mecha-Membrane Switches - UV-Coated Keycaps - Backlit Media Keys - 8-Zone RGB Lighting - Spill-Resistant - Magnetic Wrist Wrest",
                        UnitPrice = 59.99,
                        Quantity = 13,
                        ImagePath = "a9f4706c-762f-4053-94c0-879f534681ce_razer_ornatav3.jpg",
                        SubcategoryId = 5
                    },
                    new Product
                    {
                        Id = 11,
                        ProductName = "HyperX Pulsefire Haste Gaming Mouse",
                        Description = "Ultra-Lightweight, 59g, Honeycomb Shell, Hex Design, RGB, HyperFlex USB Cable, Up to 16000 DPI, 6 Programmable Buttons",
                        UnitPrice = 39.99,
                        Quantity = 11,
                        ImagePath = "c25ca3b8-b8ee-4f04-924a-7dd2642f78e4_hyperx_pulsefirehaste.jpg",
                        SubcategoryId = 6
                    },
                    new Product
                    {
                        Id = 12,
                        ProductName = "Logitech G502 HERO Gaming Mouse",
                        Description = "High Performance Wired Gaming Mouse, HERO 25K Sensor, 25,600 DPI, RGB, Adjustable Weights, 11 Programmable Buttons, On-Board Memory, PC / Mac",
                        UnitPrice = 34.99,
                        Quantity = 22,
                        ImagePath = "2581f2b7-fb87-4494-9f40-c0774d1cb57c_logitech_g502hero.jpg",
                        SubcategoryId = 6
                    },
                    new Product
                    {
                        Id = 13,
                        ProductName = "SteelSeries QcK Gaming Mousepad",
                        Description = "Large Cloth - Optimized For Gaming Sensors",
                        UnitPrice = 14.57,
                        Quantity = 25,
                        ImagePath = "4522b151-b587-4563-8d11-0893c820c10e_steelseries_qck.jpg",
                        SubcategoryId = 7
                    },
                    new Product
                    {
                        Id = 14,
                        ProductName = "Logitech G240 Cloth Gaming Mousepad",
                        Description = "Optimized for Gaming Sensors, Moderate Surface Friction, Non-Slip Mouse Mat - Black",
                        UnitPrice = 16.68,
                        Quantity = 23,
                        ImagePath = "410fd339-1d32-471e-91ac-79879385914a_logitech_g240.jpg",
                        SubcategoryId = 7
                    },
                    new Product
                    {
                        Id = 15,
                        ProductName = "ASUS VG247Q1A Gaming Monitor",
                        Description = "23.8” 1080P 165Hz 1ms Gaming Monitor with FreeSync",
                        UnitPrice = 119,
                        Quantity = 17,
                        ImagePath = "791b5fb4-3a81-4d40-b32d-f5cc620b760c_asus_vg247q1a.jpg",
                        SubcategoryId = 8
                    },
                    new Product
                    {
                        Id = 16,
                        ProductName = "MSI G27C4X Curved Gaming Monitor",
                        Description = "27” Curved 1080P, 1ms, 250Hz, FreeSync, HDMI, DisplayPort, Anti-Flicker, Anti-Glare, HDR Ready,Black",
                        UnitPrice = 163.19,
                        Quantity = 14,
                        ImagePath = "9fb194d1-a3ca-4057-bc94-d1654e73df74_msi_g27c4x.jpg",
                        SubcategoryId = 8
                    },
                    new Product
                    {
                        Id = 17,
                        ProductName = "Logitech Blue Yeti Gaming Microphone",
                        Description = "USB Microphone for Gaming, Streaming, Podcasting, Twitch, YouTube, Discord, Recording for PC and Mac, 4 Polar Patterns, Studio Quality Sound, Plug & Play-Blackout",
                        UnitPrice = 98.99,
                        Quantity = 4,
                        ImagePath = "2446aefa-5634-4e2c-8a41-837a0716cf83_logitech_blueyeti.jpg",
                        SubcategoryId = 9
                    },
                    new Product
                    {
                        Id = 18,
                        ProductName = "HyperX SoloCast Gaming Microphone",
                        Description = "USB Condenser Gaming Microphone, for PC, PS4, PS5 and Mac, Tap-to-Mute Sensor, Cardioid Polar Pattern, great for Streaming, Podcasts, Twitch, YouTube, Discord,Black",
                        UnitPrice = 87.75,
                        Quantity = 3,
                        ImagePath = "e5fdac31-72ae-4b57-a638-456c3af13365_hyperx_solocast.jpg",
                        SubcategoryId = 9
                    },
                    new Product
                    {
                        Id = 19,
                        ProductName = "Xbox Core Wireless Gaming Controller",
                        Description = "Carbon Black – Xbox Series X|S, Xbox One, Windows PC, Android, and iOS",
                        UnitPrice = 43.18,
                        Quantity = 33,
                        ImagePath = "0f7bd830-7f7d-4bc4-88c1-41c7ad5d99aa_xbox_core.jpg",
                        SubcategoryId = 10
                    },
                    new Product
                    {
                        Id = 20,
                        ProductName = "Razer Wolverine V2 Wired Gaming Controller",
                        Description = "Xbox Series X|S, Xbox One, PC: Remappable Front-Facing Buttons - Mecha-Tactile Action Buttons and D-Pad - Trigger Stop-Switches - White",
                        UnitPrice = 74,
                        Quantity = 9,
                        ImagePath = "f0806094-9f41-4736-af14-9d5c7f09195e_razer_wolverinev2.jpg",
                        SubcategoryId = 10
                    },
                    new Product
                    {
                        Id = 21,
                        ProductName = "Razer Leviathan V2 Gaming Speaker",
                        Description = "Soundbar Speaker - Bluetooth, USB-C, Chroma RGB - Black",
                        UnitPrice = 94.99,
                        Quantity = 3,
                        ImagePath = "02f1f821-003e-4599-90ff-e3a70a790cd6_razer_leviathanv2.jpg",
                        SubcategoryId = 11
                    },
                    new Product
                    {
                        Id = 22,
                        ProductName = "Redragon GS520 Gaming Speaker",
                        Description = "2.0 Channel PC Computer Stereo Speaker with 6 Colorful LED Modes, Enhanced Sound and Easy-Access Volume Control, USB Powered w/ 3.5mm Cable",
                        UnitPrice = 32.99,
                        Quantity = 14,
                        ImagePath = "1ab254fc-4757-4e56-b356-38d0b08eab47_redragon_gs520.jpg",
                        SubcategoryId = 11
                    },
                    new Product
                    {
                        Id = 23,
                        ProductName = "NexiGo N60 Gaming Camera",
                        Description = "1080P Webcam with Microphone, Adjustable FOV, Zoom, Software Control & Privacy Cover, USB HD Computer Web Camera, Plug and Play, for Zoom/Skype/Teams, Conferencing and Video Calling",
                        UnitPrice = 29.98,
                        Quantity = 30,
                        ImagePath = "f7fb93da-5fe5-4cb4-bc54-1c88cccd27b1_nexigo_n60.jpg",
                        SubcategoryId = 12
                    },
                    new Product
                    {
                        Id = 24,
                        ProductName = "NBPOWER Gaming Camera",
                        Description = "1080P 60FPS Streaming Camera Webcam with Microphone and Fill RGB Light,Autofocus,Works with Laptop/Desktop Computer/Winsdows/Mac OS/PC",
                        UnitPrice = 33.99,
                        Quantity = 21,
                        ImagePath = "c13a0919-5e0f-4802-9ad5-13ad5addacd7_nbpower_camera.jpg",
                        SubcategoryId = 12
                    },
                    new Product
                    {
                        Id = 25,
                        ProductName = "ASUS TUF Gaming A15 (2024) Gaming Laptop",
                        Description = "15.6” FHD 144Hz Display, NVIDIA® GeForce RTX™ 2050, AMD Ryzen™ 5 7535HS, 8GB DDR5, 512GB PCIe® Gen4 NVMe™ SSD, Wi-Fi 6, Windows 11",
                        UnitPrice = 643.49,
                        Quantity = 10,
                        ImagePath = "d51ab2c2-e81f-411a-9317-cc60fa85aecb_asus_a15.jpg",
                        SubcategoryId = 13
                    },
                    new Product
                    {
                        Id = 26,
                        ProductName = "Alienware X16 R1 Gaming Laptop",
                        Description = "16” QHD+ 240Hz Display, Intel Core i9-13900HK, 32GB LPDDR5 RAM, 1TB SSD, NVIDIA GeForce RTX 4080 12GB GDDR6, Windows 11 Home - Lunar Silver",
                        UnitPrice = 2042.85,
                        Quantity = 18,
                        ImagePath = "eed0728e-0c0b-4073-b172-41a8c1bd3002_alienware_x16r1.jpg",
                        SubcategoryId = 13
                    },
                    new Product
                    {
                        Id = 27,
                        ProductName = "CYBERPOWERPC Gamer Xtreme VR Gaming Desktop Computer",
                        Description = "Intel Core i5-11600KF 3.9GHz, GeForce RTX 3060 12GB, 16GB DDR4, 500GB PCI-E NVMe SSD, 1TB HDD, WiFi Ready & Win 11 Home",
                        UnitPrice = 1399,
                        Quantity = 7,
                        ImagePath = "6201ce85-239e-4fea-95d1-20937fb6ef69_cyberpower_xtreme.jpg",
                        SubcategoryId = 14
                    },
                    new Product
                    {
                        Id = 28,
                        ProductName = "iBUYPOWER Y60 Gaming Desktop Computer",
                        Description = "i7 14700KF, RTX 4070 12GB, 32 GB DDR5 5600 RGB (16GB x 2), 2TB NVME, WiFi Ready, Windows 11 Home",
                        UnitPrice = 1899.95,
                        Quantity = 9,
                        ImagePath = "803a26e8-c42d-4aa7-af43-07fcb23da58b_ibuypower_y60.jpg",
                        SubcategoryId = 14
                    }


                );
        }
    }
}
