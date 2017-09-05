using LenguajesAvanzados.Core.Sales;
using LenguajesAvanzados.Mapper.Dtos.Sales;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Mapper.Mapper.Sales
{
    public class SaleMapper : IMapper<Sale, SaleDto>
    {
        public Sale MapFromDtoToModel(SaleDto input)
        {
            return new Sale
            {
                Id = input.Id,
                Code = input.Code,
                Quantity = input.Quantity,
                Total = input.Total,
                IdProduct = input.IdProduct,
                IdInvoices = input.IdInvoices
            };
        }

        public List<Sale> MapFromDtoToModel(List<SaleDto> inputList)
        {
            return inputList.Select(MapFromDtoToModel).ToList();
        }

        public SaleDto MapFromModelTDto(Sale input)
        {
            return new SaleDto
            {
                Id = input.Id,
                Code = input.Code,
                Quantity = input.Quantity,
                Total = input.Total,
                IdProduct = input.IdProduct,
                IdInvoices = input.IdInvoices
            };
        }

        public List<SaleDto> MapFromModelToDto(List<Sale> inputList)
        {
            return inputList.Select(MapFromModelTDto).ToList();
        }
    }
}