using MyMusic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;

namespace MyMusic.DBManage
{
    public class BandManager
    {
        private static string connectionString = "Data Source=LAPTOP-6U512VIE\\SQLEXPRESS; Initial Catalog = Music;Integrated Security = true;Connection timeout = 3600;";
        public List<BandViewModel> GetAll()
        {
            List<BandViewModel> bandList = new List<BandViewModel>();
            string sql = @"select * from Music.dbo.Band";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var band = new BandViewModel()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Nome = reader["Nome"].ToString(),
                    IdArtista = Convert.ToInt32(reader["IdArtista"]),
                    Immagine = reader["Immagine"].ToString(),
                    Genere = reader["Genere"].ToString(),
                };
                bandList.Add(band);
            }
            return bandList;

        }

        public int EditBand(BandViewModel band)
        {
            string sql = @"update[Music].dbo.[Band]
                        set [Nome]=@Nome,
                            [IdArtista]=@IdArtista,
                            [Immagine]=@Immagine,
                            [Genere]=@Genere,
                        where ID=@ID";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", band.ID);
            command.Parameters.AddWithValue("@Nome", band.Nome);
            command.Parameters.AddWithValue("@IdArtista", band.IdArtista);
            command.Parameters.AddWithValue("@Immagine", band.Immagine);
            command.Parameters.AddWithValue("@Genere", band.Genere);

            return command.ExecuteNonQuery();
        }

        public int AggiungiBand(BandViewModel band)
        {
            string sql = @"insert into [Music].[dbo].[Band]
                        ([Nome],[IdArtista],[Immagine],[Genere])
                        values(@Nome,@IdArtista,@Immagine,@Genere)";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", band.ID);
            command.Parameters.AddWithValue("@Nome", band.Nome);
            command.Parameters.AddWithValue("@IdArtista", band.IdArtista);
            command.Parameters.AddWithValue("@Immagine", band.Immagine);
            command.Parameters.AddWithValue("@Genere", band.Genere);
            return command.ExecuteNonQuery();

        }
    }
}
