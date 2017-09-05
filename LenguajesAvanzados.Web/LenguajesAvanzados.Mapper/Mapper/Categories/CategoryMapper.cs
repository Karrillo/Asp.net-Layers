using LenguajesAvanzados.Core.Categories;
using LenguajesAvanzados.Mapper.Dtos.Categories;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Mapper.Mapper.Categories
{
    public class CategoryMapper : IMapper<Category, CategoryDto>
    {
        public Category MapFromDtoToModel(CategoryDto input)
        {
            return new Category
            {
                Id = input.Id,
                Type = input.Type
            };
        }

        public List<Category> MapFromDtoToModel(List<CategoryDto> inputList)
        {
            return inputList.Select(MapFromDtoToModel).ToList();
        }

        public CategoryDto MapFromModelTDto(Category input)
        {
            return new CategoryDto
            {
                Id = input.Id,
                Type = input.Type
            };
        }

        public List<CategoryDto> MapFromModelToDto(List<Category> inputList)
        {
            return inputList.Select(MapFromModelTDto).ToList();
        }
    }
}