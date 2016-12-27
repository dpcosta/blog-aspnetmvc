using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            var listaDePosts = new List<Post>();

            using (SqlConnection cnx = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Blog.mdf;Integrated Security=True"))
            {
                cnx.Open();
                SqlCommand selectCmd = cnx.CreateCommand();
                selectCmd.CommandText = "select * from Post";

                SqlDataReader resultado = selectCmd.ExecuteReader();
                while (resultado.Read())
                { 
                    listaDePosts.Add(new Post()
                    {
                        Titulo = Convert.ToString(resultado["titulo"]),
                        Resumo = Convert.ToString(resultado["resumo"]),
                        Categoria = Convert.ToString(resultado["categoria"])
                    });
                };

            }

            ViewBag.Posts = listaDePosts;
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Adiciona(Post p)
        {
            using (SqlConnection cnx = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Blog.mdf;Integrated Security=True"))
            {
                cnx.Open();
                SqlCommand insertCmd = cnx.CreateCommand();
                insertCmd.CommandText = "insert into Post (Titulo, Resumo, Categoria) values (@Titulo, @Resumo, @Categoria)";

                insertCmd.Parameters.Add(new SqlParameter("Titulo", p.Titulo));
                insertCmd.Parameters.Add(new SqlParameter("Resumo", p.Resumo));
                insertCmd.Parameters.Add(new SqlParameter("Categoria", p.Categoria));

                insertCmd.ExecuteNonQuery();

            }
            ViewBag.Titulo = p.Titulo;
            return View();
        }
    }
}