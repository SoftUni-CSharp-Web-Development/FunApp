using FunApp.Data.Models;
using FunApp.Services.Mapping;

namespace FunApp.Web.Areas.Administration.Models.Categories
{
    public class CreateCategoryInputModel : IMapTo<Category>
    {
        public string Name { get; set; }
    }
}
