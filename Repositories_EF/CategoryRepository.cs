using BusinessObjects_EF;
using DataAccessLayer_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_EF
{
    public class CategoryRepository : ICategoryRepository
    {
        CategoryDAO categoryDAO = new CategoryDAO();
        public List<Category> GetCategories()
        {
           return categoryDAO.GetCategories();
        }
    }
}
