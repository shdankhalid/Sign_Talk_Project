﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240622143809_initiat")]
    partial class initiat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Mode", b =>
                {
                    b.Property<int>("ModeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModeId"));

                    b.Property<string>("A")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("E")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("F")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("G")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("H")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("I")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("J")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("K")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("L")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("M")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("N")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModeId");

                    b.ToTable("Modes");

                    b.HasData(
                        new
                        {
                            ModeId = 1,
                            A = "I need medicine.",
                            B = "Waiting...",
                            C = "I'm thirsty.",
                            D = "Thank you.",
                            E = "I need more.",
                            F = "I like this.",
                            G = "I don't like this.",
                            H = "Call the doctor.",
                            I = "I need less.",
                            J = "Stop.",
                            K = "I want to go out.",
                            L = "I'm hungry.",
                            M = "It's too noisy.",
                            ModeName = "Home",
                            N = "I have a headache."
                        },
                        new
                        {
                            ModeId = 2,
                            A = "I need to see a doctor.",
                            B = "Waiting...",
                            C = "I need help with mobility.",
                            D = "I am in pain.",
                            E = "I need help with feeding.",
                            F = "I am feeling better.",
                            G = "I am feeling worse.",
                            H = "Can you explain the treatment plan?",
                            I = "Can you call my family?",
                            J = "I am having trouble breathing.",
                            K = "I need help finding the pharmacy.",
                            L = "Could you adjust the room temperature?",
                            M = "Can I have a glass of water?",
                            ModeName = "Hospital",
                            N = "Can I have a pen and paper?"
                        },
                        new
                        {
                            ModeId = 3,
                            A = "Need help, please.",
                            B = "Waiting...",
                            C = "Please call an ambulance.",
                            D = "Can you tell me the time?",
                            E = "Are there any restaurants around here?",
                            F = "Are there any Mosques around here?",
                            G = "Where is the nearest hospital?",
                            H = "Is there a pharmacy nearby?",
                            I = "I need to find an ATM.",
                            J = "Phone charger?",
                            K = "Is there a police station nearby?",
                            L = "Can you help me find a taxi?",
                            M = "I'm lost, can you guide me?",
                            ModeName = "Street",
                            N = "Where is the nearest subway station."
                        });
                });

            modelBuilder.Entity("Entities.Sensor_Data", b =>
                {
                    b.Property<int>("DataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DataId"));

                    b.Property<int>("ModeId")
                        .HasColumnType("int");

                    b.Property<int>("Sensor1_Value")
                        .HasColumnType("int");

                    b.Property<int>("Sensor2_Value")
                        .HasColumnType("int");

                    b.Property<int>("Sensor3_Value")
                        .HasColumnType("int");

                    b.Property<int>("Sensor4_Value")
                        .HasColumnType("int");

                    b.Property<int>("Sensor5_Value")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("DataId");

                    b.HasIndex("ModeId");

                    b.HasIndex("UserID");

                    b.ToTable("Sensors_data");
                });

            modelBuilder.Entity("Entities.SignClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SensorDataID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Word")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SensorDataID")
                        .IsUnique();

                    b.ToTable("SignClassifications");
                });

            modelBuilder.Entity("Entities.SmartGlove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<float>("Version")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("OwnerID");

                    b.ToTable("SmartGloves");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            DateTime = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Ahmed12@gmail.com",
                            Gender = true,
                            Name = "Ahmed",
                            Password = "123",
                            Phone = "0123456789"
                        });
                });

            modelBuilder.Entity("Entities.Sensor_Data", b =>
                {
                    b.HasOne("Entities.Mode", "Mode")
                        .WithMany()
                        .HasForeignKey("ModeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.User", "user")
                        .WithMany("SensorData")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mode");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Entities.SignClassification", b =>
                {
                    b.HasOne("Entities.Sensor_Data", "SensorData")
                        .WithOne("SignClassification")
                        .HasForeignKey("Entities.SignClassification", "SensorDataID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SensorData");
                });

            modelBuilder.Entity("Entities.SmartGlove", b =>
                {
                    b.HasOne("Entities.User", "Owner")
                        .WithMany("SmartGloves")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Entities.Sensor_Data", b =>
                {
                    b.Navigation("SignClassification");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Navigation("SensorData");

                    b.Navigation("SmartGloves");
                });
#pragma warning restore 612, 618
        }
    }
}
