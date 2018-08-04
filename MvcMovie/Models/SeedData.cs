using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                if(context.Movie.Any())
                {
                    return; //  如果有数据，什么也不做；否则，使用指定的数据填充数据库。
                }
                context.Movie.AddRange(
                   new Movie
                   {
                       Title = "When Harry Met Sally",
                       ReleaseDate = DateTime.Parse("1989-1-11"),
                       Genre = "Romantic Comedy",
                       Price = 7.99M,
                       Rating="二级"
                   },

                     new Movie
                     {
                         Title = "Ghostbusters ",
                         ReleaseDate = DateTime.Parse("1984-3-13"),
                         Genre = "Comedy",
                         Price = 8.99M,
                         Rating = "三级"
                     },

                     new Movie
                     {
                         Title = "Ghostbusters 2",
                         ReleaseDate = DateTime.Parse("1986-2-23"),
                         Genre = "Comedy",
                         Price = 9.99M,
                         Rating = "二级"
                     },

                   new Movie
                   {
                       Title = "Rio Bravo",
                       ReleaseDate = DateTime.Parse("1959-4-15"),
                       Genre = "Western",
                       Price = 3.99M,
                       Rating = "二级"
                   },
                    new Movie
                    {
                        Title = "秦时明月",
                        ReleaseDate = DateTime.Parse("2016-4-15"),
                        Genre = "动画片",
                        Price = 120.50M,
                        Rating = "一级"
                    },
                      new Movie
                      {
                          Title = "天行九歌",
                          ReleaseDate = DateTime.Parse("2016-4-15"),
                          Genre = "动画片",
                          Price = 120.50M,
                          Rating = "一级"
                      }
                  ); 
                context.SaveChanges();

            }
        }
    }
}
