// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PressYourLuck.Models;

namespace PressYourLuck.Migrations
{
    [DbContext(typeof(AuditContext))]
    partial class AuditContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PressYourLuck.Models.Audit", b =>
                {
                    b.Property<int>("AuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("AuditTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuditId");

                    b.ToTable("Audits");

                    b.HasData(
                        new
                        {
                            AuditId = 1,
                            Amount = 1000.0,
                            AuditTypeId = 1,
                            CreatedDate = new DateTime(2021, 11, 17, 2, 6, 1, 148, DateTimeKind.Local).AddTicks(9598),
                            PlayerName = "Manan"
                        },
                        new
                        {
                            AuditId = 2,
                            Amount = 9000.0,
                            AuditTypeId = 2,
                            CreatedDate = new DateTime(2021, 11, 17, 2, 6, 1, 152, DateTimeKind.Local).AddTicks(6310),
                            PlayerName = "Kosha"
                        });
                });

            modelBuilder.Entity("PressYourLuck.Models.AuditType", b =>
                {
                    b.Property<int>("AuditTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuditTypeId");

                    b.ToTable("AuditTypes");

                    b.HasData(
                        new
                        {
                            AuditTypeId = 1,
                            Name = "Cash-In"
                        },
                        new
                        {
                            AuditTypeId = 2,
                            Name = "Cash-Out"
                        },
                        new
                        {
                            AuditTypeId = 3,
                            Name = "Win"
                        },
                        new
                        {
                            AuditTypeId = 4,
                            Name = "Lose"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
