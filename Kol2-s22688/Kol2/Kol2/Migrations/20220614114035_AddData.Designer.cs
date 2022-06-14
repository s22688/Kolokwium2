﻿// <auto-generated />
using System;
using Kol2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kol2.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20220614114035_AddData")]
    partial class AddData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kol2.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Album");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "Duze miasto w wannie",
                            IdMusicLabel = 2,
                            PublishDate = new DateTime(2000, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdAlbum = 2,
                            AlbumName = "Slon w smietanie",
                            IdMusicLabel = 3,
                            PublishDate = new DateTime(2013, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Kol2.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicLabel");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "SPRecords1"
                        },
                        new
                        {
                            IdMusicLabel = 2,
                            Name = "SPRecords2"
                        },
                        new
                        {
                            IdMusicLabel = 3,
                            Name = "SPRecords3"
                        });
                });

            modelBuilder.Entity("Kol2.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NickName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musician");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            FirstName = "Jakub",
                            LastName = "Leniwy",
                            NickName = "Tuba"
                        },
                        new
                        {
                            IdMusician = 2,
                            FirstName = "Stefan",
                            LastName = "Twardy",
                            NickName = "Buba"
                        },
                        new
                        {
                            IdMusician = 3,
                            FirstName = "Stefan",
                            LastName = "Zeromski",
                            NickName = "Kuba"
                        });
                });

            modelBuilder.Entity("Kol2.Models.Musician_Track", b =>
                {
                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.HasKey("IdMusician", "IdTrack");

                    b.HasIndex("IdTrack");

                    b.ToTable("Musician_Track");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            IdTrack = 1
                        },
                        new
                        {
                            IdMusician = 2,
                            IdTrack = 2
                        });
                });

            modelBuilder.Entity("Kol2.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int?>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Track");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 4.7f,
                            IdMusicAlbum = 2,
                            TrackName = "Zoo1"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 3.7f,
                            IdMusicAlbum = 1,
                            TrackName = "Zoo4"
                        });
                });

            modelBuilder.Entity("Kol2.Models.Album", b =>
                {
                    b.HasOne("Kol2.Models.MusicLabel", "MusicLabel")
                        .WithMany("Album")
                        .HasForeignKey("IdMusicLabel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("Kol2.Models.Musician_Track", b =>
                {
                    b.HasOne("Kol2.Models.Musician", "Musician")
                        .WithMany("Musician_Track")
                        .HasForeignKey("IdMusician")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kol2.Models.Track", "Track")
                        .WithMany("Musician_Track")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musician");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Kol2.Models.Track", b =>
                {
                    b.HasOne("Kol2.Models.Album", "Album")
                        .WithMany("Track")
                        .HasForeignKey("IdMusicAlbum");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Kol2.Models.Album", b =>
                {
                    b.Navigation("Track");
                });

            modelBuilder.Entity("Kol2.Models.MusicLabel", b =>
                {
                    b.Navigation("Album");
                });

            modelBuilder.Entity("Kol2.Models.Musician", b =>
                {
                    b.Navigation("Musician_Track");
                });

            modelBuilder.Entity("Kol2.Models.Track", b =>
                {
                    b.Navigation("Musician_Track");
                });
#pragma warning restore 612, 618
        }
    }
}