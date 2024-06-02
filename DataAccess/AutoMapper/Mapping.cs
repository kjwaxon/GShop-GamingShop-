using ApplicationCore.DTO_s.Abstract;
using ApplicationCore.DTO_s.CategoryDTO;
using ApplicationCore.DTO_s.ProductDTO;
using ApplicationCore.DTO_s.SubcategoryDTO;
using ApplicationCore.Entities.Concrete;
using ApplicationCore.Entities.UserEntities.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Category,CreateCategoryDTO>().ReverseMap();
            CreateMap<Category,UpdateCategoryDTO>().ReverseMap();

            CreateMap<Subcategory, CreateSubcategoryDTO>().ReverseMap();
            CreateMap<Subcategory, UpdateSubcategoryDTO>().ReverseMap();

            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
        }
    }
}
