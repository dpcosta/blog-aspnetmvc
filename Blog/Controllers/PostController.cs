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

            using (SqlConnection cnx = new SqlConnection("connection string"))
            {
                cnx.Open();
                SqlCommand selectCmd = cnx.CreateCommand();
                selectCmd.CommandText = "select * from Post";

                SqlDataReader resultado = selectCmd.ExecuteReader();
                while (resultado.Read())
                {
                    new Post() {
                        Titulo = Convert.ToString(resultado["titulo"]),
                        Resumo = Convert.ToString(resultado["resumo"]),
                        Categoria = Convert.ToString(resultado["categoria"])
                    };
                };

            }

            ViewBag.Posts = listaDePosts;
            return View();
        }
    }
}