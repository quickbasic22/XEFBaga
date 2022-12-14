// <auto-generated />
using System;
using DataMigrations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataMigrations.Migrations
{
    [DbContext(typeof(BagaContext))]
    [Migration("20220915192444_DbFirst")]
    partial class DbFirst
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29");

            modelBuilder.Entity("DataMigrations.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("TripId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ActivityId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("DataMigrations.Models.ActivityTrip", b =>
                {
                    b.Property<int>("ActivityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TripId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("TripIdentifier")
                        .HasColumnType("TEXT");

                    b.HasKey("ActivityId", "TripId");

                    b.HasIndex("TripIdentifier");

                    b.ToTable("ActivityTrip");
                });

            modelBuilder.Entity("DataMigrations.Models.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("image");

                    b.HasKey("DestinationId");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("DataMigrations.Models.Lodging", b =>
                {
                    b.Property<int>("lodgingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DestinationId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsResort")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("Owner")
                        .HasColumnType("TEXT");

                    b.HasKey("lodgingId");

                    b.HasIndex("DestinationId");

                    b.ToTable("Lodgings");
                });

            modelBuilder.Entity("DataMigrations.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<int>("SocialSecurityNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("DataMigrations.Models.PersonPhoto", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Caption")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("PersonPhotos");
                });

            modelBuilder.Entity("DataMigrations.Models.Trip", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ActivityId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CostUSD")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Identifier");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("DataMigrations.Models.ActivityTrip", b =>
                {
                    b.HasOne("DataMigrations.Models.Activity", "Activity")
                        .WithMany("ActivityTrip")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataMigrations.Models.Trip", "Trip")
                        .WithMany("ActivityTrip")
                        .HasForeignKey("TripIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataMigrations.Models.Lodging", b =>
                {
                    b.HasOne("DataMigrations.Models.Destination", "Destination")
                        .WithMany("Lodgings")
                        .HasForeignKey("DestinationId");
                });

            modelBuilder.Entity("DataMigrations.Models.PersonPhoto", b =>
                {
                    b.HasOne("DataMigrations.Models.Person", "PhotoOf")
                        .WithOne("Photo")
                        .HasForeignKey("DataMigrations.Models.PersonPhoto", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
