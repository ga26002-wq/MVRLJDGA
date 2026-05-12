using Mapster;
using MediatR;
using MVRLJDGA.DataAccess.Interfaces;
using MVRLJDGA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVRLJDGA.BusinessLogic.UseCases.Books.Commands.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IEfRepository<Book> _bookRepository;

        public UpdateBookHandler(IEfRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookDto.Id);
            if (book == null) return false;

          
            request.BookDto.Adapt(book);

            book.PublisherId = request.BookDto.PublisherId;

            await _bookRepository.UpdateAsync(book);
            return true;
        }
    }
}