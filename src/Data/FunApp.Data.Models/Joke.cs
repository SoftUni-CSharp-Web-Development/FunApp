using FunApp.Data.Common;

namespace FunApp.Data.Models
{
    public class Joke : BaseModel<int>
    {
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
