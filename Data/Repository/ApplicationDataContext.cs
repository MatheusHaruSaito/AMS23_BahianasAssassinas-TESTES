using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AMS23_Carousel.Models;
using Microsoft.EntityFrameworkCore;

namespace AMS23_Carousel.Data.Repository
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options){}
        public DbSet<CategoryModel> Category{get;set;}
    }
}