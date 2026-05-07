using Mapster;
using MVRLJDGA.BusinessLogic.DTOs;
using MVRLJDGA.Entities;

namespace MVRLJDGA.BusinessLogic.Mappings
{
    public class MappingRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
          
            config.NewConfig<Book, BookDto>()
                .Map(dest => dest.ImageUrl, src => src.ImageUrl)
                .Map(dest => dest.PublisherName, src => src.Publisher.PublisherName);

         
            config.NewConfig<BookDto, Book>()
                .Map(dest => dest.ImageUrl, src => src.ImageUrl);
        }
    }
}