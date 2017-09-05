using LenguajesAvanzados.Core.Purchases;
using LenguajesAvanzados.Mapper.Dtos.Purchases;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Mapper.Mapper.Purchases
{
    public class PurchaseMapper : IMapper<Purchase, PurchaseDto>
    {
        public Purchase MapFromDtoToModel(PurchaseDto input)
        {
            return new Purchase
            {
                Id = input.Id,
                Code = input.Code,
                Quantity = input.Quantity,
                Total = input.Total,
                IdProduct = input.IdProduct,
                IdInvoices = input.IdInvoices
            };
        }

        public List<Purchase> MapFromDtoToModel(List<PurchaseDto> inputList)
        {
            return inputList.Select(MapFromDtoToModel).ToList();
        }

        public PurchaseDto MapFromModelTDto(Purchase input)
        {
            return new PurchaseDto
            {
                Id = input.Id,
                Code = input.Code,
                Quantity = input.Quantity,
                Total = input.Total,
                IdProduct = input.IdProduct,
                IdInvoices = input.IdInvoices
            };
        }

        public List<PurchaseDto> MapFromModelToDto(List<Purchase> inputList)
        {
            return inputList.Select(MapFromModelTDto).ToList();
        }
    }
}