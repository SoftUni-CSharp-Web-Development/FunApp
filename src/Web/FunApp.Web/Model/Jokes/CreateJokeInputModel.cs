using System.ComponentModel.DataAnnotations;
using FunApp.Services.Models.Jokes;

namespace FunApp.Web.Model.Jokes
{
    public class CreateJokeInputModel
    {
        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [ValidCategoryId]
        public int CategoryId { get; set; }
    }
}
