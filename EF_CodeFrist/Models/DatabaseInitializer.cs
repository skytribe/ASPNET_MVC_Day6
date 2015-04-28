using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_CodeFirst.Models
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var movies = new List<Movie> 
             {
                 new Movie {Name="Star Wars", Director="Lucas"},
                 new Movie {Name="Memento", Director="Nolan"},
                 new Movie {Name="King Kong", Director="Jackson"}
             };

            movies.ForEach(m => context.Movies.Add(m));
        }
    }


}