using MyMusic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;


namespace MyMusic.DBManage
{
    public class AlbumManager
    {
        private static string connectionString = "Data Source=LAPTOP-6U512VIE\\SQLEXPRESS; Initial Catalog = Music;Integrated Security = true;Connection timeout = 3600;";
        public List<AlbumViewModel> GetAll()
        {
            List<AlbumViewModel> albumList = new List<AlbumViewModel>();
            string sql = @"select * from Music.dbo.Album";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var album = new AlbumViewModel()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Titolo = reader["Titolo"].ToString(),
                    IdBrani = Convert.ToInt32(reader["IdBrani"]),
                    IdBand = Convert.ToInt32(reader["IdBand"]),
                    AnnoUscita = Convert.ToInt32(reader["AnnoUscita"]),
                };
                albumList.Add(album);
            }
            return albumList;

        }

        public int EditAlbum(AlbumViewModel album)
        {
            string sql = @"update[Music].dbo.[Album]
                        set [Titolo]=@Titolo,
                            [IdBrani]=@IdBrani,
                            [IdBand]=@IdBand,
                            [AnnoUscita]=@AnnoUscita,
                        where ID=@ID";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", album.ID);
            command.Parameters.AddWithValue("@Titolo", album.Titolo);
            command.Parameters.AddWithValue("@IdBrani", album.IdBrani);
            command.Parameters.AddWithValue("@IdBand", album.IdBand);
            command.Parameters.AddWithValue("@AnnoUscita", album.AnnoUscita);
        
            return command.ExecuteNonQuery();
        }

        public int AggiungiAlbum(AlbumViewModel album)
        {
            string sql = @"insert into [Music].[dbo].[Album]
                        ([Titolo],[IdBrani],[IdBand],[AnnoUscita])
                        values(@Titolo,@IdBrani,@IdBand,@AnnoUscita)";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Titolo", album.Titolo);
            command.Parameters.AddWithValue("@IdBrani", album.IdBrani);
            command.Parameters.AddWithValue("@IdBand", album.IdBand);
            command.Parameters.AddWithValue("@AnnoUscita", album.AnnoUscita);
            return command.ExecuteNonQuery();

        }
    }






}
