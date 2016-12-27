using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.DAL
{
    public class PostDAO
    {
        private SqlConnection cnx;

        public PostDAO()
        {
            this.cnx = ConnectionFactory.CreateConnection();
            this.cnx.Open();
        }

        public IList<Post> Lista()
        {
            var lista = new List<Post>();
            SqlCommand selectCmd = cnx.CreateCommand();
            selectCmd.CommandText = "select * from Post";

            SqlDataReader resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                lista.Add(new Post()
                {
                    Titulo = Convert.ToString(resultado["titulo"]),
                    Resumo = Convert.ToString(resultado["resumo"]),
                    Categoria = Convert.ToString(resultado["categoria"])
                });
            };

            return lista;
        }

        public void Adiciona(Post p)
        {
            SqlCommand insertCmd = cnx.CreateCommand();
            insertCmd.CommandText = "insert into Post (Titulo, Resumo, Categoria) values (@Titulo, @Resumo, @Categoria)";

            insertCmd.Parameters.Add(new SqlParameter("Titulo", p.Titulo));
            insertCmd.Parameters.Add(new SqlParameter("Resumo", p.Resumo));
            insertCmd.Parameters.Add(new SqlParameter("Categoria", p.Categoria));

            insertCmd.ExecuteNonQuery();
        }
    }
}