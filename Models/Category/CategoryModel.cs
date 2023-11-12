using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS23_Carousel.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            Id = Guid.NewGuid();
            IsActive = true;
        }
        public Guid Id{get;set;}
         public string Name{get;set;} ="null";
        public string Description{get;set;} ="null";
        public bool IsActive{get;set;}
    }
}