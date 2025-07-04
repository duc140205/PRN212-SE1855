using BusinessObjects_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_EF
{
    public interface ICategoryRepository
    {
        public List<Category> GetCategories();
    }
}
