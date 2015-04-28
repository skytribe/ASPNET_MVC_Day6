using EF_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_CodeFirst.Infrastructure
{
    public class EFRepository : EF_CodeFirst.Infrastructure.IRepository
    {
        // This is the only place I talk to the data controller....

        private DataContext _dc = new DataContext();

        public IList<Movie> ListMovies()
        {
            return (from m in _dc.Movies select m).ToList();

        }

        public Movie FindMovie(int id)
        {
            return _dc.Movies.Find(id);
        }

        public void CreateMovie(Movie movie)
        {
            _dc.Movies.Add(movie);
            _dc.SaveChanges();

        }

        public void EditMovie(Movie movie)
        {
            var original = this.FindMovie(movie.Id);
            original.Name = movie.Name;
            original.Director = movie.Director;
            _dc.SaveChanges();

        }

        public void DeleteMovie(int id)
        {
            var original = this.FindMovie(id);
            if (original != null)
            {
                _dc.Movies.Remove(original);
                _dc.SaveChanges();
            }

        }

    }
}