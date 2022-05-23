using MyMusic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;

namespace MyMusic.DBManage
{
    public class ArtistiManager
    {
        private static string connectionString = "Data Source=LAPTOP-6U512VIE\\SQLEXPRESS; Initial Catalog = Music;Integrated Security = true;Connection timeout = 3600;";
        public List<ArtistiViewModel> GetAll()
        {
            List<ArtistiViewModel> artistList = new List<ArtistiViewModel>();
            string sql = @"select * from Music.dbo.Artisti";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var artist = new ArtistiViewModel()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Nome = reader["Nome"].ToString(),
                    Cognome = reader["Cognome"].ToString(),
                    NomeArte = reader["NomeArte"].ToString(),
                    Tipo = reader["Tipo"].ToString(),
                };
                artistList.Add(artist);
            }
            return artistList;

        }

        public int EditArtisti(ArtistiViewModel artist)
        {
            string sql = @"update[Music].dbo.[Artisti]
                        set [Nome]=@Nome,
                            [Cognome]=@Cognome,
                            [NomeArte]=@NomeArte,
                            [Tipo]=@Tipo,
                        where ID=@ID";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", artist.ID);
            command.Parameters.AddWithValue("@Nome", artist.Nome);
            command.Parameters.AddWithValue("@Cognome", artist.Cognome);
            command.Parameters.AddWithValue("@NomeArte", artist.NomeArte);
            command.Parameters.AddWithValue("@Tipo", artist.Tipo);

            return command.ExecuteNonQuery();
        }

        public int AggiungiArtisti(ArtistiViewModel artist)
        {
            string sql = @"insert into [Music].[dbo].[Artisti]
                        ([Nome],[Cognome],[NomeArte],[Tipo])
                        values(@Nome,@Cognome,@NomeArte,@Tipo)";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", artist.ID);
            command.Parameters.AddWithValue("@Nome", artist.Nome);
            command.Parameters.AddWithValue("@Cognome", artist.Cognome);
            command.Parameters.AddWithValue("@NomeArte", artist.NomeArte);
            command.Parameters.AddWithValue("@Tipo", artist.Tipo);
            return command.ExecuteNonQuery();

        }
    }
}

