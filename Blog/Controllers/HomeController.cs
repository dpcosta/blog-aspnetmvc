using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Linguagem = "ASP.NET MVC";
            return View();
        }

        // GET: Home/About
        public ActionResult About()
        {
            return View();
        }

        // GET: Home/Categorias
        public ActionResult Categorias()
        {
            return View();
        }

        //GET: Home/OlaMundo
        public ActionResult OlaMundo(string linguagem)
        {
            ViewBag.Linguagem = linguagem;
            return View("Index");
        }

    }
}