using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Introduzione
{
    public static class DAL //data access layer//
    {
        public static void insertPerson(Person p)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
            string query = "insert into [dbo].[Persons] values (newid(), @username, @password, @nome, @cognome, @eta, getdate())";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", p.Username);
                    command.Parameters.AddWithValue("@password", p.Password);
                    command.Parameters.AddWithValue("@nome", p.Nome);
                    command.Parameters.AddWithValue("@cognome", p.Cognome);
                    command.Parameters.AddWithValue("@eta", p.Eta);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static List<Person> getAllPersons()
        {
            List<Person> persone = new List<Person>();
            string connectionString = WebConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
            string query = "SELECT [ID],[Nome],[Cognome],[Eta] FROM [dbo].[Persons] order by CreationDate desc";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        Person p = new Person();
                        p.ID = Guid.Parse(row["ID"].ToString());
                        p.Nome = row["Nome"].ToString();
                        p.Cognome = row["Cognome"].ToString();
                        p.Eta = row["Eta"].ToString();
                        persone.Add(p);
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
            }
            return persone;
        }

        public static bool validateLogin(string username, string password)
        {
            bool toSender = false;
            string connectionString = WebConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
            string query = "SELECT [ID] FROM [dbo].[Persons] where [Username] = @username and [Password] = @password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                    if (dt.Rows.Count == 1)
                        toSender = true;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
            }
            return toSender;
        }
    }
}