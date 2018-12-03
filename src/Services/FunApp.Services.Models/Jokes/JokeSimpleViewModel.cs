using FunApp.Data.Models;
using FunApp.Services.Mapping;

namespace FunApp.Services.Models.Jokes
{
    public class JokeSimpleViewModel : IMapFrom<Joke>
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }
}
