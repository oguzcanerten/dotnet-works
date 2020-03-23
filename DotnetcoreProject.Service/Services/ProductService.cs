using DotnetcoreProject.Core.Models;
using DotnetcoreProject.Core.Repositories;
using DotnetcoreProject.Core.Service;
using DotnetcoreProject.Core.UnirOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotnetcoreProject.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork,IRepository<Product> repository): base(unitOfWork, repository)
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
           return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}
