using LenguajesAvanzados.Core.Persons;
using LenguajesAvanzados.Mapper.Dtos.Persons;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Mapper.Mapper.Persons
{
    public class PersonMapper : IMapper<Person, PersonDto>
    {
        public Person MapFromDtoToModel(PersonDto input)
        {
            return new Person
            {
                Id = input.Id,
                Name = input.Name,
                FirstName = input.FirstName,
                SecondName = input.SecondName,
                Email = input.Email,
                Phone = input.Phone,
                CellPhone= input.CellPhone,
                Address = input.Address,
                identification = input.identification
            };
        }

        public List<Person> MapFromDtoToModel(List<PersonDto> inputList)
        {
            return inputList.Select(MapFromDtoToModel).ToList();
        }

        public PersonDto MapFromModelTDto(Person input)
        {
            return new PersonDto
            {
                Id = input.Id,
                Name = input.Name,
                FirstName = input.FirstName,
                SecondName = input.SecondName,
                Email = input.Email,
                Phone = input.Phone,
                CellPhone = input.CellPhone,
                Address = input.Address,
                identification = input.identification
            };
        }

        public List<PersonDto> MapFromModelToDto(List<Person> inputList)
        {
            return inputList.Select(MapFromModelTDto).ToList();
        }
    }
}
