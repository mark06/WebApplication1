using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp1.Entities;
using WebApp1.DataLayer;

namespace WebApplication1.Controllers
{
    //[Authorize]
    public class MoviesController : Controller
    {
        MoviesOperations moviesOps = new MoviesOperations();
        GenresOperations genreOps = new GenresOperations();
        List<Movie> movies;
        // GET: /Movies/
        public ActionResult Index()
        {
            int movieCount = moviesOps.GetMovieCount();
            int perPage = 3;
            int noOfPages = movieCount / perPage;
            int currentPage = 1;
            
            int offset = (currentPage-1) * perPage;

            ViewBag.NoOfPages = noOfPages;
            ViewBag.CurrentPage = currentPage;

            movies = moviesOps.GetMovies(offset,perPage);

            return View(movies);
        }


        [HttpPost]
        public JsonResult Index(String currentPage)
        {
            bool success = true;
            int movieCount = moviesOps.GetMovieCount();
            int perPage = 3;
            int noOfPages = movieCount / perPage;
            if (currentPage == null)
            {
                currentPage = "1";
            }
            int thisPage = Int32.Parse(currentPage);
            int offset = (thisPage - 1) * perPage;

            ViewBag.NoOfPages = noOfPages;
            ViewBag.CurrentPage = currentPage;

            movies = moviesOps.GetMovies(offset, perPage);
            return Json(new { success = success, data = movies});
        }

        // GET: /Movies/Create
        public ActionResult Create()
        {

            List<Genre> genres = new List<Genre>();

            genres = genreOps.GetGenres();

            ViewBag.Genres = genres;

            return View();
        }

        // POST: /Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            movie.Genre = Request.Form["genre_select"];

            moviesOps.AddMovie(movie);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: /Movies/Edit/5
        public ActionResult Edit(int id)
        {
            Movie movie = moviesOps.GetMovie(id);

            List<Genre> genres = new List<Genre>();

            genres = genreOps.GetGenres();

            ViewBag.Genres = genres;

            return View(movie);
        }

        // POST: /Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            movie.Genre = Request.Form["genre_reselect"];

            moviesOps.AddMovie(movie);
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public JsonResult SearchMovie(string searchString)
        {
            bool success = true;
            List<Movie> foundMovies = new List<Movie>();
            try
            {
                foundMovies = moviesOps.SearchMovie(searchString);

            }
            catch (Exception e)
            {
                success = false;
            }
            return Json(new { success = success, data = foundMovies });
        }

        public ActionResult GetGenres()
        {
            List<Genre> genres = genreOps.GetGenres();

            return View(genres);
        }

        public JsonResult PostGenre(string newGenre)
        {
            bool success = true;
            try {
                genreOps.PostGenre(newGenre);
            }catch(Exception e)
            {
                success = false;
            }
            return Json(new { success=success, data= newGenre});
        }
    }
}
