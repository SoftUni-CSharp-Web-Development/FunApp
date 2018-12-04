using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunApp.Data;
using FunApp.Data.Common;
using FunApp.Data.Models;
using FunApp.Web.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace FunApp.Services.DataServices.Tests
{
    public class JokesServiceTests
    {
        [Fact]
        public void GetCountShouldReturnsCorrectNumber()
        {
            var jokesRepository = new Mock<IRepository<Joke>>();
            jokesRepository.Setup(r => r.All()).Returns(new List<Joke>
            {
                new Joke(),
                new Joke(),
                new Joke(),
            }.AsQueryable());
            var service = new JokesService(jokesRepository.Object, null);
            Assert.Equal(3, service.GetCount());
            jokesRepository.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public async Task GetCountShouldReturnsCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<FunAppContext>()
                .UseInMemoryDatabase(databaseName: "Find_User_Database") // Give a Unique name to the DB
                .Options;
            var dbContext = new FunAppContext(options);
            dbContext.Jokes.Add(new Joke());
            dbContext.Jokes.Add(new Joke());
            dbContext.Jokes.Add(new Joke());
            await dbContext.SaveChangesAsync();

            var repository = new DbRepository<Joke>(dbContext);
            var jokesService = new JokesService(repository, null);
            var count = jokesService.GetCount();
            Assert.Equal(3, count);
        }
    }
}
