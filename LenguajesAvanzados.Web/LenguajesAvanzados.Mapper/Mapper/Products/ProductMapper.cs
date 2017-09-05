using LenguajesAvanzados.Core.Products;
using LenguajesAvanzados.Mapper;
using LenguajesAvanzados.Mapper.Dtos.Products;
using System.Collections.Generic;
using System.Linq;

namespace Crao.Mapper.Mappers.Products
{
    public class ProductMapper : IMapper<Product, ProductDto>
    {
        public Product MapFromDtoToModel(ProductDto input)
        {
            return new Product
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Code = input.Code,
                State = input.State,
                Price = input.Price,
                IdProvider = input.IdProvider,
            };
        }

        public List<Product> MapFromDtoToModel(List<ProductDto> inputList)
        {
            return inputList.Select(MapFromDtoToModel).ToList();
        }

        public ProductDto MapFromModelTDto(Product input)
        {
            return new ProductDto
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Code = input.Code,
                State = input.State,
                Price = input.Price,
                IdProvider = input.IdProvider,
            };
        }

        public List<ProductDto> MapFromModelToDto(List<Product> inputList)
        {
            return inputList.Select(MapFromModelTDto).ToList();
        }
    }
}