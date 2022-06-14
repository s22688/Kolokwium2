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
    [Migration("20220614103748_First")]
    partial class First
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

                    b.Property<int?>("MusicLabelIdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("MusicLabelIdMusicLabel");

                    b.ToTable("Album");
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
                });

            modelBuilder.Entity("Kol2.Models.Musician_Track", b =>
                {
                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.Property<int?>("MusicianIdMusician")
                        .HasColumnType("int");

                    b.Property<int?>("TrackIdTrack")
                        .HasColumnType("int");

                    b.HasKey("IdMusician", "IdTrack");

                    b.HasIndex("MusicianIdMusician");

                    b.HasIndex("TrackIdTrack");

                    b.ToTable("Musician_Track");
                });

            modelBuilder.Entity("Kol2.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumIdAlbum")
                        .HasColumnType("int");

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int?>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("AlbumIdAlbum");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("Kol2.Models.Album", b =>
                {
                    b.HasOne("Kol2.Models.MusicLabel", "MusicLabel")
                        .WithMany("Album")
                        .HasForeignKey("MusicLabelIdMusicLabel");

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("Kol2.Models.Musician_Track", b =>
                {
                    b.HasOne("Kol2.Models.Musician", "Musician")
                        .WithMany("Musician_Track")
                        .HasForeignKey("MusicianIdMusician");

                    b.HasOne("Kol2.Models.Track", "Track")
                        .WithMany("Musician_Track")
                        .HasForeignKey("TrackIdTrack");

                    b.Navigation("Musician");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Kol2.Models.Track", b =>
                {
                    b.HasOne("Kol2.Models.Album", "Album")
                        .WithMany("Track")
                        .HasForeignKey("AlbumIdAlbum");

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
