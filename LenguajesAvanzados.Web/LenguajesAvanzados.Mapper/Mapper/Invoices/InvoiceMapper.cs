using LenguajesAvanzados.Core.Invoices;
using LenguajesAvanzados.Mapper.Dtos.Invoices;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Mapper.Mapper.Invoices
{
    public class InvoiceMapper : IMapper<Invoice, InvoiceDto>
    {
        public Invoice MapFromDtoToModel(InvoiceDto input)
        {
            return new Invoice
            {
                Id = input.Id,
                Date = input.Date,
                State = input.State,
                LimitDate = input.LimitDate,
                Code = input.Code,
                Total = input.Total,
                Tax = input.Tax,
                Discount = input.Discount,
                IdClient = input.IdClient,
                IdProvider = input.IdProvider,
                IdUser = input.IdUser
            };
        }

        public List<Invoice> MapFromDtoToModel(List<InvoiceDto> inputList)
        {
            return inputList.Select(MapFromDtoToModel).ToList();
        }

        public InvoiceDto MapFromModelTDto(Invoice input)
        {
            return new InvoiceDto
            {
                Id = input.Id,
                Date = input.Date,
                State = input.State,
                LimitDate = input.LimitDate,
                Code = input.Code,
                Total = input.Total,
                Tax = input.Tax,
                Discount = input.Discount,
                IdClient = input.IdClient,
                IdProvider = input.IdProvider,
                IdUser = input.IdUser
            };
        }

        public List<InvoiceDto> MapFromModelToDto(List<Invoice> inputList)
        {
            return inputList.Select(MapFromModelTDto).ToList();
        }
    }
}