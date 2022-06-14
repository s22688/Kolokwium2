using Microsoft.EntityFrameworkCore.Migrations;

namespace Kol2.Migrations
{
    public partial class MigrationWithrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_MusicLabel_MusicLabelIdMusicLabel",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Track_Musician_MusicianIdMusician",
                table: "Musician_Track");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Track_Track_TrackIdTrack",
                table: "Musician_Track");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_Album_AlbumIdAlbum",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Track_AlbumIdAlbum",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Track_MusicianIdMusician",
                table: "Musician_Track");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Track_TrackIdTrack",
                table: "Musician_Track");

            migrationBuilder.DropIndex(
                name: "IX_Album_MusicLabelIdMusicLabel",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "AlbumIdAlbum",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "MusicianIdMusician",
                table: "Musician_Track");

            migrationBuilder.DropColumn(
                name: "TrackIdTrack",
                table: "Musician_Track");

            migrationBuilder.DropColumn(
                name: "MusicLabelIdMusicLabel",
                table: "Album");

            migrationBuilder.CreateIndex(
                name: "IX_Track_IdMusicAlbum",
                table: "Track",
                column: "IdMusicAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Track_IdTrack",
                table: "Musician_Track",
                column: "IdTrack");

            migrationBuilder.CreateIndex(
                name: "IX_Album_IdMusicLabel",
                table: "Album",
                column: "IdMusicLabel");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_MusicLabel_IdMusicLabel",
                table: "Album",
                column: "IdMusicLabel",
                principalTable: "MusicLabel",
                principalColumn: "IdMusicLabel",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Track_Musician_IdMusician",
                table: "Musician_Track",
                column: "IdMusician",
                principalTable: "Musician",
                principalColumn: "IdMusician",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Track_Track_IdTrack",
                table: "Musician_Track",
                column: "IdTrack",
                principalTable: "Track",
                principalColumn: "IdTrack",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Album_IdMusicAlbum",
                table: "Track",
                column: "IdMusicAlbum",
                principalTable: "Album",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_MusicLabel_IdMusicLabel",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Track_Musician_IdMusician",
                table: "Musician_Track");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Track_Track_IdTrack",
                table: "Musician_Track");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_Album_IdMusicAlbum",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Track_IdMusicAlbum",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Track_IdTrack",
                table: "Musician_Track");

            migrationBuilder.DropIndex(
                name: "IX_Album_IdMusicLabel",
                table: "Album");

            migrationBuilder.AddColumn<int>(
                name: "AlbumIdAlbum",
                table: "Track",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MusicianIdMusician",
                table: "Musician_Track",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrackIdTrack",
                table: "Musician_Track",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MusicLabelIdMusicLabel",
                table: "Album",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Track_AlbumIdAlbum",
                table: "Track",
                column: "AlbumIdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Track_MusicianIdMusician",
                table: "Musician_Track",
                column: "MusicianIdMusician");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Track_TrackIdTrack",
                table: "Musician_Track",
                column: "TrackIdTrack");

            migrationBuilder.CreateIndex(
                name: "IX_Album_MusicLabelIdMusicLabel",
                table: "Album",
                column: "MusicLabelIdMusicLabel");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_MusicLabel_MusicLabelIdMusicLabel",
                table: "Album",
                column: "MusicLabelIdMusicLabel",
                principalTable: "MusicLabel",
                principalColumn: "IdMusicLabel",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Track_Musician_MusicianIdMusician",
                table: "Musician_Track",
                column: "MusicianIdMusician",
                principalTable: "Musician",
                principalColumn: "IdMusician",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Track_Track_TrackIdTrack",
                table: "Musician_Track",
                column: "TrackIdTrack",
                principalTable: "Track",
                principalColumn: "IdTrack",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Album_AlbumIdAlbum",
                table: "Track",
                column: "AlbumIdAlbum",
                principalTable: "Album",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
