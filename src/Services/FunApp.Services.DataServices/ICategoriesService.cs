using System.Collections.Generic;
using System.Text;
using FunApp.Services.Models.Categories;

namespace FunApp.Services.DataServices
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);

        int? GetCategoryId(string name);
    }
}
