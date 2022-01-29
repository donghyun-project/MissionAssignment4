using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionAssignment4.Models
{
    public class MovieApplicationContext : DbContext
    {
        // Constructor
        public MovieApplicationContext (DbContextOptions<MovieApplicationContext> options) : base(options)
        {
            // leave it blank for now
        }

        public DbSet<MovieApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Seed data

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );

            mb.Entity<MovieApplicationResponse>().HasData(
                new MovieApplicationResponse
                {
                    MovieId = 1,
                    Title = "Spider-Man: Homecoming",
                    Year = 2017,
                    CategoryId = 1,
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieApplicationResponse
                {
                    MovieId = 2,
                    Title = "Spider-Man: Far from Home",
                    Year = 2019,
                    CategoryId = 1,
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieApplicationResponse
                {
                    MovieId = 3,
                    Title = "Spider-Man: No Way Home",
                    Year = 2021,
                    CategoryId = 1,
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
            );
        }
    }
}
