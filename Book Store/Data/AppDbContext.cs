using Book_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(x=>x.books)
                .WithOne(x => x.Author)
                .HasForeignKey(x=>x.AuthorId);

            modelBuilder.Entity<Author>().HasData(
              new Author
              {
                  Id = 1,
                  Name = "John",
                  Bio = "",
                  dateOfBirth = new DateTime(2000, 10, 17)
              },
              new Author
              {
                  Id = 2,
                  Name = "Arnold",
                  Bio = "",
                  dateOfBirth = new DateTime(1890, 9, 10)
              }
            );

            modelBuilder.Entity<Book>().HasData(
               new Book { Id = 1, Title = "C# Programming Basics", Genre = "Technology", publicationDate = new DateOnly(2020, 1, 1), AuthorId = 1 },
               new Book { Id = 2, Title = "Advanced C# Techniques", Genre = "Technology", publicationDate = new DateOnly(2021, 2, 15), AuthorId = 1 },
               new Book { Id = 3, Title = "Learning Python", Genre = "Technology", publicationDate = new DateOnly(2019, 3, 20), AuthorId = 2 },
               new Book { Id = 4, Title = "Mastering Python", Genre = "Technology", publicationDate = new DateOnly(2018, 4, 5), AuthorId = 2 },
               new Book { Id = 5, Title = "Java for Beginners", Genre = "Technology", publicationDate = new DateOnly(2017, 5, 10), AuthorId = 1 },
               new Book { Id = 6, Title = "Advanced Java Concepts", Genre = "Technology", publicationDate = new DateOnly(2016, 6, 15), AuthorId = 2 },
               new Book { Id = 7, Title = "JavaScript Essentials", Genre = "Technology", publicationDate = new DateOnly(2020, 7, 20), AuthorId = 1 },
               new Book { Id = 8, Title = "React.js Guide", Genre = "Technology", publicationDate = new DateOnly(2021, 8, 25), AuthorId = 2 },
               new Book { Id = 9, Title = "Vue.js in Action", Genre = "Technology", publicationDate = new DateOnly(2019, 9, 30), AuthorId = 1 },
               new Book { Id = 10, Title = "Angular for Professionals", Genre = "Technology", publicationDate = new DateOnly(2018, 10, 5), AuthorId = 2 },
               new Book { Id = 11, Title = "Machine Learning with Python", Genre = "Technology", publicationDate = new DateOnly(2017, 11, 10), AuthorId = 1 },
               new Book { Id = 12, Title = "Deep Learning Techniques", Genre = "Technology", publicationDate = new DateOnly(2016, 12, 15), AuthorId = 2 },
               new Book { Id = 13, Title = "Data Science Essentials", Genre = "Technology", publicationDate = new DateOnly(2020, 1, 20), AuthorId = 1 },
               new Book { Id = 14, Title = "Big Data Analytics", Genre = "Technology", publicationDate = new DateOnly(2021, 2, 25), AuthorId = 2 },
               new Book { Id = 15, Title = "Cloud Computing Basics", Genre = "Technology", publicationDate = new DateOnly(2019, 3, 30), AuthorId = 1 },
               new Book { Id = 16, Title = "AWS for Beginners", Genre = "Technology", publicationDate = new DateOnly(2018, 4, 5), AuthorId = 2 },
               new Book { Id = 17, Title = "Azure in Action", Genre = "Technology", publicationDate = new DateOnly(2017, 5, 10), AuthorId = 1 },
               new Book { Id = 18, Title = "GCP Fundamentals", Genre = "Technology", publicationDate = new DateOnly(2016, 6, 15), AuthorId = 2 },
               new Book { Id = 19, Title = "Kubernetes Guide", Genre = "Technology", publicationDate = new DateOnly(2020, 7, 20), AuthorId = 1 },
               new Book { Id = 20, Title = "Docker Deep Dive", Genre = "Technology", publicationDate = new DateOnly(2021, 8, 25), AuthorId = 2 },
               new Book { Id = 21, Title = "Microservices Architecture", Genre = "Technology", publicationDate = new DateOnly(2019, 9, 30), AuthorId = 1 },
               new Book { Id = 22, Title = "DevOps Essentials", Genre = "Technology", publicationDate = new DateOnly(2018, 10, 5), AuthorId = 2 },
               new Book { Id = 23, Title = "Agile Development", Genre = "Technology", publicationDate = new DateOnly(2017, 11, 10), AuthorId = 1 },
               new Book { Id = 24, Title = "Scrum Master Guide", Genre = "Technology", publicationDate = new DateOnly(2016, 12, 15), AuthorId = 2 },
               new Book { Id = 25, Title = "Project Management Basics", Genre = "Business", publicationDate = new DateOnly(2020, 1, 20), AuthorId = 1 },
               new Book { Id = 26, Title = "Leadership Skills", Genre = "Business", publicationDate = new DateOnly(2021, 2, 25), AuthorId = 2 },
               new Book { Id = 27, Title = "Effective Communication", Genre = "Business", publicationDate = new DateOnly(2019, 3, 30), AuthorId = 1 },
               new Book { Id = 28, Title = "Negotiation Techniques", Genre = "Business", publicationDate = new DateOnly(2018, 4, 5), AuthorId = 2 },
               new Book { Id = 29, Title = "Time Management", Genre = "Business", publicationDate = new DateOnly(2017, 5, 10), AuthorId = 1 },
               new Book { Id = 30, Title = "Financial Analysis", Genre = "Business", publicationDate = new DateOnly(2016, 6, 15), AuthorId = 2 },
               new Book { Id = 31, Title = "Investing 101", Genre = "Finance", publicationDate = new DateOnly(2020, 7, 20), AuthorId = 1 },
               new Book { Id = 32, Title = "Stock Market Basics", Genre = "Finance", publicationDate = new DateOnly(2021, 8, 25), AuthorId = 2 },
               new Book { Id = 33, Title = "Real Estate Investment", Genre = "Finance", publicationDate = new DateOnly(2019, 9, 30), AuthorId = 1 },
               new Book { Id = 34, Title = "Personal Finance Management", Genre = "Finance", publicationDate = new DateOnly(2018, 10, 5), AuthorId = 2 },
               new Book { Id = 35, Title = "Retirement Planning", Genre = "Finance", publicationDate = new DateOnly(2017, 11, 10), AuthorId = 1 },
               new Book { Id = 36, Title = "Insurance Essentials", Genre = "Finance", publicationDate = new DateOnly(2016, 12, 15), AuthorId = 2 },
               new Book { Id = 37, Title = "Health and Wellness", Genre = "Health", publicationDate = new DateOnly(2020, 1, 20), AuthorId = 1 },
               new Book { Id = 38, Title = "Nutrition Basics", Genre = "Health", publicationDate = new DateOnly(2021, 2, 25), AuthorId = 2 });
           base.OnModelCreating(modelBuilder);
        }
    }
}
