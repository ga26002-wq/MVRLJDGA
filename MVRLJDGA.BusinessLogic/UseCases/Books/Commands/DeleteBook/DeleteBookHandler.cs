using MediatR;
using MVRLJDGA.DataAccess.Interfaces;
using MVRLJDGA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MVRLJDGA.BusinessLogic.UseCases.Books.Commands.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IEfRepository<Book> _bookRepository;

        public DeleteBookHandler(IEfRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            if (book == null) return false;

            await _bookRepository.DeleteAsync(book);
            return true;
        }
    }
}