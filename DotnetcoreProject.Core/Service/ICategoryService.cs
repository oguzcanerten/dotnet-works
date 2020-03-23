using DotnetcoreProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetcoreProject.Core.Service
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

        // Categoryle ilgili metodlar (helper vs.)

    }
}
