using LenguajesAvanzados.Core.Users;
using LenguajesAvanzados.Mapper.Dtos.Users;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Mapper.Mapper.Users
{
    public class UserMapper : IMapper<User, UserDto>
    {
        public User MapFromDtoToModel(UserDto input)
        {
            return new User
            {
                Id = input.Id,
                Name = input.Name,
                Password = input.Password,
                Type = input.Type,
                State = input.State
            };
        }

        public List<User> MapFromDtoToModel(List<UserDto> inputList)
        {
            return inputList.Select(MapFromDtoToModel).ToList();
        }

        public UserDto MapFromModelTDto(User input)
        {
            return new UserDto
            {
                Id = input.Id,
                Name = input.Name,
                Password = input.Password,
                Type = input.Type,
                State = input.State
            };
        }

        public List<UserDto> MapFromModelToDto(List<User> inputList)
        {
            return inputList.Select(MapFromModelTDto).ToList();
        }
    }
}