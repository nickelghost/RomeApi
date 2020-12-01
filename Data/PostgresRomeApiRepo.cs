using System;
using System.Collections.Generic;
using System.Linq;
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

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<CategoryGroup> GetAllCategoryGroups()
        {
            var cgs = _context.CategoryGroups
                .OrderBy(cg => cg.Rank)
                .Include(cg => cg.Categories)
                .ToList();
            return cgs;
        }

        public CategoryGroup GetCategoryGroup(Guid id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            var cg = _context.CategoryGroups.Find(id);
            return cg;
        }

        public void CreateCategoryGroup(CategoryGroup categoryGroup)
        {
            if (categoryGroup == null) throw new ArgumentNullException(nameof(categoryGroup));
            try
            {
                var maxRank = _context.CategoryGroups.Max(cg => cg.Rank);
                categoryGroup.Rank = maxRank + 1;
            }
            catch (InvalidOperationException)
            {
                categoryGroup.Rank = 1;
            }
            _context.CategoryGroups.Add(categoryGroup);
        }

        public void DeleteCategoryGroup(CategoryGroup cg)
        {
            _context.CategoryGroups.Remove(cg);
        }
    }
}