using System;
using System.Collections.Generic;
using System.Text;
using Mapster;
using MediatR;
using MVRLJDGA.BusinessLogic.DTOs;
using MVRLJDGA.DataAccess.Interfaces;
using MVRLJDGA.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MVRLJDGA.BusinessLogic.UseCases.Books.Queries.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IEfRepository<Book> _bookRepository;

        public GetBookByIdHandler(IEfRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            if (book == null) return null;

            return book.Adapt<BookDto>();
        }
    }
}