using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Gameshop_AdoNet.Db
{
	public class Igra_Crud
	{
		//Implementirati metode GetAll, GetById, Insert, Update, Delete
		public List<Game> GetAll()
		{
			using (var conn = new SqlConnection(Properties.Settings.Default.connString))
			{
				conn.Open();
				var cmd = new SqlCommand("SELECT * FROM Game", conn);
				var dr = cmd.ExecuteReader();
				var rezultat = new List<Game>();
				while (dr.Read())
				{
					var igra = new Game();
					igra.Id = (int)dr["id"];
					igra.Title = (string)dr["title"];
					igra.IdGenre = (int?)dr["idGenre"];
					igra.IdDeveloper = (int?)dr["idDeveloper"];
					igra.IdPublisher = (int?)dr["IdPublisher"];
					igra.Price = (decimal?)dr["price"];
					igra.ReleaseDate = (DateTime?)dr["releaseDate"];
					rezultat.Add(igra);
				}
				dr.Close();				
				return rezultat;
			}
		}

		public Game GetById(int id)
		{
			using (var conn = new SqlConnection(Properties.Settings.Default.connString))
			{
				Game rezultat = null;
				conn.Open();
				var cmd = new SqlCommand("SELECT * FROM Game WHERE id = @id", conn);
				cmd.Parameters.AddWithValue("@id", id);
				var dr = cmd.ExecuteReader();
				if (dr.Read())
				{
					rezultat = new Game
					{
						Id = (int)dr["id"],
						Title = dr["title"] != DBNull.Value ? dr["title"].ToString() : null,
						IdGenre = dr["idGenre"] != DBNull.Value ? (int?)dr["idGenre"] : null,
						IdPublisher = dr["idPublisher"] != DBNull.Value ? (int?)dr["idPublisher"] : null,
						Price = dr["price"] != DBNull.Value ? (decimal?)dr["price"] : null,
						IdDeveloper = dr["idDeveloper"] != DBNull.Value ? (int?)dr["idDeveloper"] : null,
						ReleaseDate = dr["releaseDate"] != DBNull.Value ? (DateTime?)dr["releaseDate"] : null
					};
				}
				dr.Close();
				return rezultat;
			}

		}

		public int Insert(Game igra)
		{
			using (var conn = new SqlConnection(Properties.Settings.Default.connString))
			{
				conn.Open();
				var cmd = new SqlCommand(@"INSERT INTO [dbo].[Game]
							   ([title],[idGenre],[idPublisher],[price],[idDeveloper],[releaseDate]) OUTPUT INSERTED.id
								VALUES (@title,@idGenre,@idPublisher,@price,@idDeveloper,@releaseDate)", conn);
				cmd.Parameters.AddWithValue("@title", (object)igra.Title ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@idGenre", (object)igra.IdGenre ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@idPublisher", (object)igra.IdPublisher ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@price", (object)igra.Price ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@idDeveloper", (object)igra.IdDeveloper ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@releaseDate", (object)igra.ReleaseDate ?? DBNull.Value);
				var id = cmd.ExecuteScalar();
				return Convert.ToInt32(id);
			}
		}

		public int Update(Game igra)
		{
			using (var conn = new SqlConnection(Properties.Settings.Default.connString))
			{
				conn.Open();
				var cmd = new SqlCommand(@"UPDATE [dbo].[Game]
							   SET [title] = @title ,[idGenre]= @idGenre ,[idPublisher] = @idPublisher
								  ,[price] = @price ,[idDeveloper] = @idDeveloper,[releaseDate] = @releaseDate
							 WHERE id = @id", conn);
				cmd.Parameters.AddWithValue("@id", igra.Id);
				cmd.Parameters.AddWithValue("@title", (object)igra.Title ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@idGenre", (object)igra.IdGenre ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@idPublisher", (object)igra.IdPublisher ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@price", (object)igra.Price ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@idDeveloper", (object)igra.IdDeveloper ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@releaseDate", (object)igra.ReleaseDate ?? DBNull.Value);
				return cmd.ExecuteNonQuery();
			}
		}

		public void Delete(int id)
		{
			using (var conn = new SqlConnection(Properties.Settings.Default.connString))
			{
				conn.Open();
				var cmd = new SqlCommand("DELETE FROM Game WHERE id = @id", conn);
				cmd.Parameters.AddWithValue("@id", id);
				cmd.ExecuteNonQuery();
			}
		}
	}
	
}
