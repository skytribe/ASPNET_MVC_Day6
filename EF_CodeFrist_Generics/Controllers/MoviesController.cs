
using EF_CodeFirst.Infrastructure;
using EF_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EF_CodeFirst.Controllers
{
    public class MoviesController : Controller
    {

        private IGenericRepository _repos;


        public MoviesController(IGenericRepository repo)
        {
            _repos = repo;
        }


        // GET: Movies
        public ActionResult IndexAll()
        {

 

            var movies = from m in _repos.Query<Movie>()
                         select m;

            return View(movies.ToList());
        }


        // GET: Movies
        public ActionResult Index()
        {

            return View(_repos.Query<Movie>().ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            // id is comming from the route controller argument
            // NOT The property from the movie class
            Movie movie = null;

            movie = _repos.Find<Movie>(id);
            if (movie != null)
            {
                return View(movie);
            }


            return RedirectToAction("Index");
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repos.Add<Movie>(movie);

                _repos.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = _repos.Find<Movie>(id);
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie movie)
        {
            if (ModelState.IsValid)
            {
                var original = _repos.Find<Movie>(movie.Id);
                original.Name= movie.Name;
                original.Director = movie.Director;
                _repos.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            _repos.Delete<Movie>(id);
            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ActionName("Delete")]   // Requires this because both methods have same signature
        public ActionResult Delete(int id, Movie movie)
        {
            _repos.Delete<Movie>(id);

            _repos.SaveChanges();
            return RedirectToAction("Index");





        }
    }
}
