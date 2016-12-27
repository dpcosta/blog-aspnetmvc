using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.DAL
{
    public class PostEFDAO
    {
        private BlogContext context;

        public PostEFDAO()
        {
            this.context = new BlogContext();
        }

        public IList<Post> Lista()
        {
            return context.Posts.ToList();
        }

        public void Adiciona(Post p)
        {
            context.Posts.Add(p);
            context.SaveChanges();
        }

        public IList<Post> ListaPostsDaCategoria(string categoria)
        {
            var posts = from p in context.Posts where p.Categoria.Contains(categoria) select p;
            return posts.ToList();
        }

        public void Remove(int id)
        {
            Post p = context.Posts.Find(id);
            context.Posts.Remove(p);
            context.SaveChanges();
        }

        public Post BuscaPeloId(int id)
        {
            return context.Posts.Find(id);
        }

        public void Atualiza(Post p)
        {
            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}