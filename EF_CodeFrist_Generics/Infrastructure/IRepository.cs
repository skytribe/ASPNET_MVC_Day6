using System;
namespace EF_CodeFirst.Infrastructure
{
   public  interface IRepository
    {
        void CreateMovie(EF_CodeFirst.Models.Movie movie);
        void DeleteMovie(int id);
        void EditMovie(EF_CodeFirst.Models.Movie movie);
        EF_CodeFirst.Models.Movie FindMovie(int id);
        System.Collections.Generic.IList<EF_CodeFirst.Models.Movie> ListMovies();
    }
}
