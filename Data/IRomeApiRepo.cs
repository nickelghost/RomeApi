using System;
using System.Collections.Generic;
using RomeApi.Models;

namespace RomeApi.Data
{
    // TODO: Split this into resource-based repos
    // TODO: Make those async
    public interface IRomeApiRepo
    {
        void SaveChanges();
        IEnumerable<CategoryGroup> GetAllCategoryGroups();
        CategoryGroup GetCategoryGroup(Guid id);
        void CreateCategoryGroup(CategoryGroup categoryGroup);
        void DeleteCategoryGroup(CategoryGroup categoryGroup);
    }
}