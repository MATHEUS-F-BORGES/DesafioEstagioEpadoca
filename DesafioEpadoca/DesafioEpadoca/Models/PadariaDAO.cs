using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DesafioEpadoca.Models
{
    public class PadariaDAO : IDisposable
    {
        private SqlConnection connection;

        public PadariaDAO()
        {
            string strConn = "Data Source=DESKTOP-LP39CDD;Initial Catalog=DesafioepadocaBD;Integrated Security=true";
            connection = new SqlConnection(strConn);
            connection.Open();
        }
        public void Dispose()
        {
            connection.Close();
        }
        public void Create(Padaria padaria)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO padaria VALUES(@Nome, @Endereco)";

            cmd.Parameters.AddWithValue("@Nome", padaria.Nome);
            cmd.Parameters.AddWithValue("@Endereco", padaria.Endereco);

            cmd.ExecuteNonQuery();
        }

        public List<Padaria> Read()
        {

            List<Padaria> lista = new List<Padaria>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM padaria";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Padaria p = new Padaria();
                p.IdPadaria = (int)reader["IdPadaria"];
                p.Nome = (string)reader["Nome"];
                p.Endereco = (string)reader["Endereco"];

                lista.Add(p);
            }

            return lista;
        }


        public String ExisteNome(String nome)
        {

                Padaria p = new Padaria();  
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM Padaria WHERE (Nome = @nome)";
                cmd.Parameters.AddWithValue("@nome", nome);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                p.IdPadaria = (int)reader["IdPadaria"];
                p.Nome = (string)reader["Nome"];
                p.Endereco = (string)reader["Endereco"];

               
            }

            reader.Close();
            return p.Nome;


        }


    }
    }
