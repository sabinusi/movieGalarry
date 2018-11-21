using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.viewModel
{
    public class RandomMovieViewModel
    {
        public Movie Moive { set; get; }
        public List<Customer> Customer { set; get; }
    }
}