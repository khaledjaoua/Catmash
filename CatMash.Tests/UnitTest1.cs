using CatMash.Repository;
using CatMash.Repository.Models;
using CatMash.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CatMash.Test
{
    [TestClass]
    public class CatMashServiceTests
    {
        [TestMethod]
        public void FetchCatsTest()
        {
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory data
            IEnumerable<Cats> cats = new List<Cats>
            {
                new Cats
                {
                    CatMashId= 1,
                    Note = 5,
                    Id="MTgwODA3MA",
                    Url="http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg"
                },
                new Cats
                {
                    CatMashId= 2,
                    Note = 1,
                    Url= "http://25.media.tumblr.com/tumblr_m4bgd9OXmw1qioo2oo1_500.jpg",
                    Id= "bmp"
                },
                new Cats
                {
                    CatMashId= 3,
                    Note = 15,
                    Url= "http://24.media.tumblr.com/tumblr_lzxok2e2kX1qgjltdo1_1280.jpg",
                    Id= "c8a"
                },
                new Cats
                {
                    CatMashId= 4,
                    Note = 7,
                    Url= "http://25.media.tumblr.com/tumblr_m33r7lpy361qzi9p6o1_500.jpg",
                    Id= "3kj"
                }

            };

            var options = new DbContextOptionsBuilder<CatMashDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            CatMashDbContext context = new CatMashDbContext(options);
            var service = new CatMashService(context);
            service.AddRange(cats);

            var actual = service.GetAll();

            // Asset
            Assert.AreEqual(4, actual.Count());
            Assert.AreEqual("MTgwODA3MA", actual.First().Id);
        }

        [TestMethod]
        public void CreateCatsTest()
        {
            var options = new DbContextOptionsBuilder<CatMashDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            CatMashDbContext context = new CatMashDbContext(options);
            //// Act - Add the book
            var service = new CatMashService(context);
            service.Add(new Cats
            {
                CatMashId = 1,
                Note = 5,
                Url = "https://example.com",
                Id = "bmp"
            });
            //// Assert
            Assert.AreEqual(1, context.Cats.Count());
            Assert.AreEqual("https://example.com", context.Cats.Single().Url);
        }
    }
}