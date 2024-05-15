using AutoMapper;
using NossaLoja.Core.Application.ViewModels;
using NossaLoja.Core.Domain.Entities;

namespace NossaLoja.Core.Application.Mappers;

public static class ResponseErrorMap
{
    public static List<ResponseErrorVM> Get(List<ResponseError> responseErrors)
    {
        return ConfigurationResponseErrorToResponseErrorVM()
            .Map<List<ResponseError>, List<ResponseErrorVM>>(responseErrors);
    }

    private static IMapper ConfigurationResponseErrorToResponseErrorVM()
    {
        return new MapperConfiguration(x => 
        {
            x.CreateMap<ResponseError, ResponseErrorVM>();
        }).CreateMapper();
    }
}
