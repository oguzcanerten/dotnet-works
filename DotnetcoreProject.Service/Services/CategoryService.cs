using DotnetcoreProject.Core.Models;
using DotnetcoreProject.Core.Repositories;
using DotnetcoreProject.Core.Service;
using DotnetcoreProject.Core.UnirOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetcoreProject.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
           return await _unitOfWork.categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
