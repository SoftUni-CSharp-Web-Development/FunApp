using System;
using System.Collections.Generic;
using System.Text;
using FunApp.Data.Common;

namespace FunApp.Data.Models
{
    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Jokes = new HashSet<Joke>();
        }

        public string Name { get; set; }

        public virtual ICollection<Joke> Jokes { get; set; }
    }
}
