using MyMusic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;


namespace MyMusic.DBManage
{
    public class BraniManager
    {
        private static string connectionString = "Data Source=LAPTOP-6U512VIE\\SQLEXPRESS; Initial Catalog = Music;Integrated Security = true;Connection timeout = 3600;";
        public List<BranoViewModel> GetAll()
        {
            List<BranoViewModel> braniList = new List<BranoViewModel>();
            string sql = @"select * from Music.dbo.Brani";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var brano = new BranoViewModel()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Titolo = reader["Titolo"].ToString(),
                    Band = reader["Band"].ToString(),
                    Album = reader["Album"].ToString(),
                    AnnoUscita = Convert.ToInt32(reader["AnnoUscita"]),
                    Durata = Convert.ToDecimal(reader["Durata"]),
                    Genere = reader["Genere"].ToString()
                };
                braniList.Add(brano);
            }
            return braniList;

        }

        public int EditBrano(BranoViewModel brano)
        {
            string sql = @"update[Music].dbo.[Brani]
                        set [Titolo]=@Titolo,
                            [Band]=@Band,
                            [Album]=@Album,
                            [AnnoUscita]=@AnnoUscita,
                            [Durata]=@Durata,
                            [Genere]=@Genere
                        where ID=@ID";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", brano.ID);
            command.Parameters.AddWithValue("@Titolo", brano.Titolo);
            command.Parameters.AddWithValue("@Band", brano.Band);
            command.Parameters.AddWithValue("@Album", brano.Album);
            command.Parameters.AddWithValue("@AnnoUscita", brano.AnnoUscita);
            command.Parameters.AddWithValue("@Durata", brano.Durata);
            command.Parameters.AddWithValue("@Genere", brano.Genere);
            return command.ExecuteNonQuery();
        }

        public int AggiungiBrano(BranoViewModel brano){
            string sql = @"insert into [Music].[dbo].[Brani]
                        ([Titolo],[Band],[Album],[AnnoUscita],[Durata],[Genere])
                        values(@Titolo,@Band,@Album,@AnnoUscita,@Durata,@Genere)";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Titolo", brano.Titolo);
            command.Parameters.AddWithValue("@Band", brano.Band);
            command.Parameters.AddWithValue("@Album", brano.Album);
            command.Parameters.AddWithValue("@AnnoUscita", brano.AnnoUscita);
            command.Parameters.AddWithValue("@Durata", brano.Durata);
            command.Parameters.AddWithValue("@Genere", brano.Genere);
            return command.ExecuteNonQuery();

        }
    }


    //command.Parameters.AddWithValue("@application_ex_id",((object) logSearch.LogID) ?? DBNull.Value);




}
