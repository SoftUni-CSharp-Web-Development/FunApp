using System.Collections.Generic;

namespace FunApp.Services.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<IndexJokeViewModel> Jokes { get; set; }
    }
}
