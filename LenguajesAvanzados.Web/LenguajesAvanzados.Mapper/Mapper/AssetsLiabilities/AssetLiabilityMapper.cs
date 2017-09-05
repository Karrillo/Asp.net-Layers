using LenguajesAvanzados.Core.AssetsLiabilities;
using LenguajesAvanzados.Mapper.Dtos.AssetsLiabilities;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Mapper.Mapper.AssetsLiabilities
{
    public class AssetLiabilityMapper : IMapper<AssetLiability, AssetLiabilityDto>
    {
        public AssetLiability MapFromDtoToModel(AssetLiabilityDto input)
        {
            return new AssetLiability
            {
                Id = input.Id,
                Date = input.Date,
                Name = input.Name,
                Type = input.Type,
                Rode = input.Rode,
                Code = input.Code,
                Description = input.Description,
                IdUser = input.IdUser,
                IdAccount = input.IdAccount,
                IdCategory = input.IdCategory,
                IdInvoice = input.IdInvoice
            };
        }

        public List<AssetLiability> MapFromDtoToModel(List<AssetLiabilityDto> inputList)
        {
            return inputList.Select(MapFromDtoToModel).ToList();
        }

        public AssetLiabilityDto MapFromModelTDto(AssetLiability input)
        {
            return new AssetLiabilityDto
            {
                Id = input.Id,
                Date = input.Date,
                Name = input.Name,
                Type = input.Type,
                Rode = input.Rode,
                Code = input.Code,
                Description = input.Description,
                IdUser = input.IdUser,
                IdAccount = input.IdAccount,
                IdCategory = input.IdCategory,
                IdInvoice = input.IdInvoice
            };
        }

        public List<AssetLiabilityDto> MapFromModelToDto(List<AssetLiability> inputList)
        {
            return inputList.Select(MapFromModelTDto).ToList();
        }
    }
}
