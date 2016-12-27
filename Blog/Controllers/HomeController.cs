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

        //GET: Home/OlaMundoCSharp
        public ActionResult OlaMundoCSharp()
        {
            ViewBag.Linguagem = "C#";
            return View("Index");
        }

        //GET: Home/OlaMundoJavascript
        public ActionResult OlaMundoJavascript()
        {
            ViewBag.Linguagem = "Javascript";
            return View("Index");
        }
    }
}