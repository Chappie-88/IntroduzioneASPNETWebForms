using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Introduzione
{
    public static class DAL //data access layer
    {
        public static void insertPerson(Person p)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
            string query = "insert into [dbo].[Persons] ([ID],[Username],[Password],[Nome],[Cognome],[Eta],[CreationDate],[Deleted]) values (newid(), @username, @password, @nome, @cognome, @eta, getdate(), 0)";
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

        public static Person getPersonByID(Guid id)
        {
            Person person = null;
            string connectionString = WebConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
            string query = "select * from [dbo].[Persons] where [ID] = @id and [Deleted] = 0";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                    person = new Person();
                    person.ID = Guid.Parse(dt.Rows[0]["ID"].ToString());
                    person.Nome = dt.Rows[0]["Nome"].ToString();
                    person.Cognome = dt.Rows[0]["Cognome"].ToString();
                    person.Eta = dt.Rows[0]["Eta"].ToString();
                    person.Username = dt.Rows[0]["Username"].ToString();
                    person.Password = dt.Rows[0]["Password"].ToString();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
                return person;
            }
        }

        public static string updatePerson(Person p)
        {
            string outputMessage = string.Empty;
            string connectionString = WebConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
            string query = "update [dbo].[Persons] set [Username]=@username, [Password]=@password, [Nome]=@nome, [Cognome]=@cognome, [Eta]=@eta where [ID] = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", p.ID);
                    command.Parameters.AddWithValue("@username", p.Username);
                    command.Parameters.AddWithValue("@password", p.Password);
                    command.Parameters.AddWithValue("@nome", p.Nome);
                    command.Parameters.AddWithValue("@cognome", p.Cognome);
                    command.Parameters.AddWithValue("@eta", p.Eta);
                    connection.Open();
                    command.ExecuteNonQuery();
                    outputMessage = "User was succesfully updated";
                }
                catch (Exception ex)
                {
                    outputMessage = "Error updating user";
                }
                finally
                {
                    connection.Close();
                }
            }
            return outputMessage;
        }

        public static void deletePerson(Guid id)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
            string query = "update [dbo].[Persons] set [Deleted] = 1 where [ID] = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
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
            string query = "SELECT [ID],[Nome],[Cognome],[Eta] FROM [dbo].[Persons] where [Deleted] = 0 order by CreationDate desc";
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
            string query = "SELECT [ID] FROM [dbo].[Persons] where [Username] = @username and [Password] = @password and [Deleted] = 0";
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