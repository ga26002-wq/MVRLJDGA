using MediatR;
using Mapster;
using MVRLJDGA.BusinessLogic.DTOs;
using MVRLJDGA.DataAccess.Interfaces;
using MVRLJDGA.Entities;
using MVRLJDGA.BusinessLogic.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MVRLJDGA.BusinessLogic.UseCases.Books.Queries.GetBooks
{
    public class GetBooksHandler : IRequestHandler<GetBooksQuery, List<BookDto>>
    {
        private readonly IEfRepository<Book> _bookRepository;

        public GetBooksHandler(IEfRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var spec = new BookWithPublisherSpec();

            var books = await _bookRepository.ListAsync(spec);

            var booksDto = books.Select(b => new BookDto

            {
                Id = b.Id,
                Title = b.Title,
                SalePrice = b.SalePrice,
                Stock = b.Stock,
                ImageUrl = b.ImageUrl,
                PublisherId = b.PublisherId,
               
                PublisherName = b.Publisher != null ? b.Publisher.PublisherName : "Sin Editorial"
            }).ToList();

           
            return booksDto;
        }
    }
}

