using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS23_Carousel.Models;
using AMS23_Carousel.Models.Category;

namespace AMS23_Carousel.Data.Repository
{
    public class CategoryRepository : RepositoryBase<CategoryModel,Guid>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDataContext applicationDataContext) : base(applicationDataContext)
        {
            
        }
    }
}