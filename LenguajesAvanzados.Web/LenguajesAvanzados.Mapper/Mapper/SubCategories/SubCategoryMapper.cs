using LenguajesAvanzados.Core.SubCategories;
using LenguajesAvanzados.Mapper.Dtos.SubCategories;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Mapper.Mapper.SubCategories
{
    public class SubCategoryMapper : IMapper<SubCategory, SubCategoryDto>
    {
        public SubCategory MapFromDtoToModel(SubCategoryDto input)
        {
            return new SubCategory
            {
                Id = input.Id,
                Name = input.Name,
                IdCategory = input.IdCategory
            };
        }

        public List<SubCategory> MapFromDtoToModel(List<SubCategoryDto> inputList)
        {
            return inputList.Select(MapFromDtoToModel).ToList();
        }

        public SubCategoryDto MapFromModelTDto(SubCategory input)
        {
            return new SubCategoryDto
            {
                Id = input.Id,
                Name = input.Name,
                IdCategory = input.IdCategory
            };
        }

        public List<SubCategoryDto> MapFromModelToDto(List<SubCategory> inputList)
        {
            return inputList.Select(MapFromModelTDto).ToList();
        }
    }
}