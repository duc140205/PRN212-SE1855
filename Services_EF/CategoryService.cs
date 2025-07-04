using BusinessObjects_EF;
using Repositories_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_EF
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository categoryRepository;
        public CategoryService()
        {
            categoryRepository = new CategoryRepository();
        }
        public List<Category> GetCategories()
        {
            return categoryRepository.GetCategories();
        }
    }
}
