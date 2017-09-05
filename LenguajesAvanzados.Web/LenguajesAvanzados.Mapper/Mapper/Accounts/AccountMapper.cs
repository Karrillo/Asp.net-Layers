using LenguajesAvanzados.Core.Accounts;
using LenguajesAvanzados.Mapper.Dtos.Accounts;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Mapper.Mapper.Accounts
{
    public class AccountMapper : IMapper<Account, AccountDto>
    {
        public Account MapFromDtoToModel(AccountDto input)
        {
            return new Account
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public List<Account> MapFromDtoToModel(List<AccountDto> inputList)
        {
            return inputList.Select(MapFromDtoToModel).ToList();
        }

        public AccountDto MapFromModelTDto(Account input)
        {
            return new AccountDto
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public List<AccountDto> MapFromModelToDto(List<Account> inputList)
        {
            return inputList.Select(MapFromModelTDto).ToList();
        }
    }
}