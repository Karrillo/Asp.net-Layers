using LenguajesAvanzados.Core.Providers;
using LenguajesAvanzados.Mapper.Dtos.Providers;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Mapper.Mapper.Providers
{
    public class ProviderMapper : IMapper<Provider, ProviderDto>
    {
        public Provider MapFromDtoToModel(ProviderDto input)
        {
            return new Provider
            {
                Id = input.Id,
                State = input.State,
                NameCompany = input.NameCompany,
                IdPerson = input.IdPerson
            };
        }

        public List<Provider> MapFromDtoToModel(List<ProviderDto> inputList)
        {
            return inputList.Select(MapFromDtoToModel).ToList();
        }

        public ProviderDto MapFromModelTDto(Provider input)
        {
            return new ProviderDto
            {
                Id = input.Id,
                State = input.State,
                NameCompany = input.NameCompany,
                IdPerson = input.IdPerson
            };
        }

        public List<ProviderDto> MapFromModelToDto(List<Provider> inputList)
        {
            return inputList.Select(MapFromModelTDto).ToList();
        }
    }
}