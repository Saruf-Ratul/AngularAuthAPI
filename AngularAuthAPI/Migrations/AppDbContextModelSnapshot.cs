﻿// <auto-generated />
using System;
using AngularAuthAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AngularAuthAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AngularAuthAPI.Models.Apoinment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ModelYear")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Problem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RuningMilage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Apoinments", (string)null);
                });

            modelBuilder.Entity("AngularAuthAPI.Models.Dashboard", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("dashboards", (string)null);
                });

            modelBuilder.Entity("AngularAuthAPI.Models.tbAppointment", b =>
                {
                    b.Property<decimal>("App_ID")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("APP_Confirm")
                        .HasColumnType("bit");

                    b.Property<bool?>("APP_Re_Confirm")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("App_Entry_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("App_Serial")
                        .HasColumnType("int");

                    b.Property<byte?>("App_TypeId")
                        .HasColumnType("tinyint");

                    b.Property<int?>("Appby_Secu_EMPID")
                        .HasColumnType("int");

                    b.Property<int?>("Bay_Id")
                        .HasColumnType("int");

                    b.Property<string>("Chesis_No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Computer_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Computer_UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Confirmby_Secu_EMPID")
                        .HasColumnType("int");

                    b.Property<string>("Cust_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerRequest")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EMPID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End_Time")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("KM")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Level_Id")
                        .HasColumnType("int");

                    b.Property<string>("MobleNO_SMS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model_Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("Print_count")
                        .HasColumnType("tinyint");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Reminder1_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Reminder2_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Reminder3_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Schedule_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Schedule_Time")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SysDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vReg_No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("App_ID");

                    b.ToTable("tbAppointment", (string)null);
                });

            modelBuilder.Entity("AngularAuthAPI.Models.tbAppType", b =>
                {
                    b.Property<byte>("App_TypeId")
                        .HasColumnType("tinyint");

                    b.Property<string>("App_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_Active")
                        .HasColumnType("bit");

                    b.HasKey("App_TypeId");

                    b.ToTable("tbAppType", (string)null);
                });

            modelBuilder.Entity("AngularAuthAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Active")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Admin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ResetPasswordExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
