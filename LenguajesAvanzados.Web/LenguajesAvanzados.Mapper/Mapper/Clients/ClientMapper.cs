using LenguajesAvanzados.Core.Clients;
using LenguajesAvanzados.Mapper.Dtos.Clients;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Mapper.Mapper.Clients
{
    public class ClientMapper : IMapper<Client, ClientDto>
    {
        public Client MapFromDtoToModel(ClientDto input)
        {
            return new Client
            {
                Id = input.Id,
                State = input.State,
                IdPerson = input.IdPerson
            };
        }

        public List<Client> MapFromDtoToModel(List<ClientDto> inputList)
        {
            return inputList.Select(MapFromDtoToModel).ToList();
        }

        public ClientDto MapFromModelTDto(Client input)
        {
            return new ClientDto
            {
                Id = input.Id,
                State = input.State,
                IdPerson = input.IdPerson
            };
        }

        public List<ClientDto> MapFromModelToDto(List<Client> inputList)
        {
            return inputList.Select(MapFromModelTDto).ToList();
        }
    }
}