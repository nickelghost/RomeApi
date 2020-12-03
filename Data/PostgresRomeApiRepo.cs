using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RomeApi.Models;

namespace RomeApi.Data
{
    public class PostgresRomeApiRepo : IRomeApiRepo
    {
        private readonly RomeApiContext _context;

        public PostgresRomeApiRepo(RomeApiContext context)
        {
            _context = context;
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryGroup>> GetAllCategoryGroups()
        {
            var cgs = await _context.CategoryGroups
                .OrderBy(cg => cg.Rank)
                .Include(cg => cg.Categories)
                .ToListAsync();
            return cgs;
        }

        public async Task<CategoryGroup> GetCategoryGroup(Guid id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            var cg = await _context.CategoryGroups.FindAsync(id);
            return cg;
        }

        public async Task CreateCategoryGroup(CategoryGroup categoryGroup)
        {
            if (categoryGroup == null) throw new ArgumentNullException(nameof(categoryGroup));
            try
            {
                var maxRank = await _context.CategoryGroups.MaxAsync(cg => cg.Rank);
                categoryGroup.Rank = maxRank + 1;
            }
            catch (InvalidOperationException)
            {
                categoryGroup.Rank = 1;
            }
            await _context.CategoryGroups.AddAsync(categoryGroup);
        }

        public void DeleteCategoryGroup(CategoryGroup cg)
        {
            _context.CategoryGroups.Remove(cg);
        }

        public async Task<Category> GetCategory(Guid id, bool includeChildren = false, bool includeTasks = false)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            var builder = _context.Categories;
            if (includeChildren) builder.Include(c => c.ChildCategories);
            if (includeTasks) builder.Include(c => c.Topics);
            var category = await builder.FindAsync(id);
            return category;
        }

        public async Task CreateCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            // The category to be saved needs to either be in a group, or a child of another category.
            // Otherwise, it has no way of appearing in the website UI.
            if (category.CategoryGroupId == null && category.ParentCategoryId == null)
            {
                throw new NullReferenceException("CategoryGroupId or ParentCategoryId has to be provided");
            }

            if (category.CategoryGroupId != null && category.ParentCategoryId != null)
            {
                throw new NullReferenceException("You can't provide both parent category and category group");
            }


            try
            {
                double maxRank;
                if (category.CategoryGroupId != null)
                {
                    maxRank = await _context.Categories
                        .Where(c => c.CategoryGroupId == category.CategoryGroupId)
                        .MaxAsync(c => c.Rank);
                }
                else
                {
                    maxRank = await _context.Categories
                        .Where(c => c.ParentCategoryId == category.ParentCategoryId)
                        .MaxAsync(c => c.Rank);
                }

                category.Rank = maxRank + 1;
            }
            catch (InvalidOperationException)
            {
                category.Rank = 1;
            }

            await _context.Categories.AddAsync(category);
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}