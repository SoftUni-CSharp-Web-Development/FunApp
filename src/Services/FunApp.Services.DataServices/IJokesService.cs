using System.Collections.Generic;
using System.Threading.Tasks;
using FunApp.Data.Models;
using FunApp.Services.Models.Home;
using FunApp.Services.Models.Jokes;

namespace FunApp.Services.DataServices
{
    public interface IJokesService
    {
        IEnumerable<IndexJokeViewModel> GetRandomJokes(int count);

        int GetCount();

        Task<int> Create(int categoryId, string content);

        TViewModel GetJokeById<TViewModel>(int id);

        IEnumerable<JokeSimpleViewModel> GetAllByCategory(int categoryId);

        bool AddRatingToJoke(int jokeId, int rating);
    }
}