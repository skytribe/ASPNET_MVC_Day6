
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

        private IRepository _repos;


        public MoviesController(IRepository repo)
        {
            _repos = repo;
        }


        // GET: Movies
        public ActionResult IndexAll()
        {

            //var x = new GenericRepository();
            //var y = from i in x<Movie> where i=="SciFi" select i;


            return View(_repos.ListMovies().ToList());
        }


        // GET: Movies
        public ActionResult Index()
        {

            //    return null;
            return View(_repos.ListMovies().ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            // id is comming from the route controller argument
            // NOT The property from the movie class
            Movie movie = null;

            movie = _repos.FindMovie(id);
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
                _repos.CreateMovie(movie);
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            // 
            var movie = _repos.FindMovie(id);
            _repos.EditMovie(movie);
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repos.EditMovie(movie);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            _repos.DeleteMovie(id);
            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ActionName("Delete")]   // Requires this because both methods have same signature
        public ActionResult Delete(int id, Movie movie)
        {
            _repos.DeleteMovie(id);


            return RedirectToAction("Index");





        }
    }
}
