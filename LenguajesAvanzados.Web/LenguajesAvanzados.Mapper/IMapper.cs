using System.Collections.Generic;

namespace LenguajesAvanzados.Mapper
{
    public interface IMapper<TModel, TDto>
    {
        TDto MapFromModelTDto(TModel model);
        TModel MapFromDtoToModel(TDto dto);
        List<TDto> MapFromModelToDto(List<TModel> modelList);
        List<TModel> MapFromDtoToModel(List<TDto> dtoList);
    }
}
