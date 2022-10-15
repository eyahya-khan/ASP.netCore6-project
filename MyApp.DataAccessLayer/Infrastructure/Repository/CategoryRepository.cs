﻿using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public object GetT(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
           _context.Categories.Update(category);
        }
    }
}
