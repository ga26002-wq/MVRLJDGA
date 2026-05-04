using MediatR;
using Mapster;
using MVRLJDGA.BusinessLogic.DTOs;
using MVRLJDGA.DataAccess.Interfaces;
using MVRLJDGA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
            var books = await _bookRepository.ListAsync();
            return books.Adapt<List<BookDto>>();
        }
    }
}