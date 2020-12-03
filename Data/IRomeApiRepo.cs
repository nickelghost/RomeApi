using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RomeApi.Models;

namespace RomeApi.Data
{
    // TODO: Split this into resource-based repos
    public interface IRomeApiRepo
    {
        Task SaveChanges();
        Task<IEnumerable<CategoryGroup>> GetAllCategoryGroups();
        Task<CategoryGroup> GetCategoryGroup(Guid id);
        Task CreateCategoryGroup(CategoryGroup categoryGroup);
        void DeleteCategoryGroup(CategoryGroup categoryGroup);
        Task<Category> GetCategory(Guid id, bool includeChildren = false, bool includeTasks = false);
        Task CreateCategory(Category category);
        void DeleteCategory(Category category);
    }
}