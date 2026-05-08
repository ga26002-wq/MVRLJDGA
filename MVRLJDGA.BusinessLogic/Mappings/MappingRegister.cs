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

            config.NewConfig<User, UserDto>()
                .Map(dest => dest.RoleTitle, src => src.Role != null ? src.Role.Title : string.Empty);

            config.NewConfig<UserDto, User>();
        }
    }
}