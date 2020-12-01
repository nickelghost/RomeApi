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
    }
}