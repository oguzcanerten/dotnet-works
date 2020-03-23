using DotnetcoreProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetcoreProject.Core.UnirOfWorks
{
    public interface IUnitOfWork
    {
        // DI olarak geçnmek yerine uow'de geçtim.
        IProductRepository Products { get; }
        ICategoryRepository categories { get; }
        Task CommitAsync();
        void Commit();
    }
}
