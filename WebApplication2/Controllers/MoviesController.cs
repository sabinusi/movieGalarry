using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.viewModel;


namespace WebApplication2.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random(string year,string month)
        {
            var movie = new Movie() { name = "Fast furious" };
            var cutomers = new List<Customer> {
                new Customer {Name="sabinusi" },
                new Customer {Name="mlambo" }
            };
            var viewMovies = new RandomMovieViewModel()
            {
                Moive = movie,
                Customer = cutomers

            };
            return View(viewMovies );
        }
       
    }
}