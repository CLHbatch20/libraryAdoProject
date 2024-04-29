using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Application.DTOs;
using Ado.Net.Core.Application.Interfaces.Repositories;
using Ado.Net.Core.Application.Interfaces.Services;
using Ado.Net.Core.Domain.Entities;
using Ado.Net.Infrastructure.Repositories;

namespace Ado.Net.Core.Application.Implementation.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository categoryRepo = new CategoryRepository();
        public CategoryDTO CreateCategory(CreateCategoryRequestModel request)
        {
            var exist = categoryRepo.Get(request.Name);
            if(exist != null)
            {
                return null;
            }
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description,
            };
            categoryRepo.Add(category);
            var categoryDTO = new CategoryDTO
            {
                Name = request.Name,
                Description = request.Description
            };
            return categoryDTO;
        }

        public CategoryDTO GetCategory(string name)
        {
            var category = categoryRepo.Get(name);
            if(category == null)
            {
                return null;
            }
            var categoryDTO = new CategoryDTO
            {
                Name = category.Name,
                Description = category.Description,
            };
            return categoryDTO;
        }
    }
}