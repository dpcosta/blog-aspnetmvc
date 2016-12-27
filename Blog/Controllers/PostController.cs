using Blog.DAL;
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
        private PostEFDAO dao;

        public PostController()
        {
            this.dao = new PostEFDAO();
        }

        // GET: Post
        public ActionResult Index()
        {
            ViewBag.Posts = dao.Lista();
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Adiciona(Post p)
        {
            dao.Adiciona(p);
            ViewBag.Titulo = p.Titulo;
            return View();
        }

        [Route("Post/Categoria/{categoria}")]
        public ActionResult Categoria(string categoria)
        {
            ViewBag.Posts = dao.ListaPostsDaCategoria(categoria);
            return View("Index");
        }

        public ActionResult Remover(int id)
        {
            dao.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            ViewBag.Post = dao.BuscaPeloId(id);
            return View();
        }

        public ActionResult Atualiza(Post p)
        {
            dao.Atualiza(p);
            return RedirectToAction("Index");
        }
        
    }
}