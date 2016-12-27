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

        // GET: /About
        [Route("Sobre")]
        public ActionResult About()
        {
            return View();
        }

        // GET: /Categorias
        [Route("Categorias")]
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