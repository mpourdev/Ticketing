// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ticketing.Infrastructures.Data.SqlServer;

#nullable disable

namespace Ticketing.Infrastructures.Data.SqlServer.Migrations
{
    [DbContext(typeof(TicketingDbContext))]
    [Migration("20220821184320_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ticketing.Core.Domain.Tickets.Entities.Ticket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Ticket", (string)null);
                });

            modelBuilder.Entity("Ticketing.Core.Domain.Tickets.Entities.TicketStatusHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<long>("TicketId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketStatusHistory", (string)null);
                });

            modelBuilder.Entity("Ticketing.Core.Domain.Tickets.Entities.TicketStatusHistory", b =>
                {
                    b.HasOne("Ticketing.Core.Domain.Tickets.Entities.Ticket", "Ticket")
                        .WithMany("TicketStatusHistories")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Ticketing.Core.Domain.Tickets.Entities.Ticket", b =>
                {
                    b.Navigation("TicketStatusHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
