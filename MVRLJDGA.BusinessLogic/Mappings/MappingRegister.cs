using Mapster;
using MVRLJDGA.BusinessLogic.DTOs;
using MVRLJDGA.Entities;

namespace MVRLJDGA.BusinessLogic.Mappings
{
    public class MappingRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Book, BookDto>();
            config.NewConfig<BookDto, Book>();
        }
    }
}