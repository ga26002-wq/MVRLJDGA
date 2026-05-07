using MediatR;
using MVRLJDGA.DataAccess.Interfaces;
using MVRLJDGA.Entities;
using MVRLJDGA.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading; // <--- ESTO FALTABA
using System.Threading.Tasks; // <--- ESTO FALTABA

namespace MVRLJDGA.BusinessLogic.UseCases.Books.Commands.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, long>
    {
        private readonly IEfRepository<Book> _bookRepository;

        public CreateBookHandler(IEfRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<long> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                PublisherId = request.BookDto.PublisherId,
                Title = request.BookDto.Title,
                SalePrice = request.BookDto.SalePrice,
                Stock = request.BookDto.Stock
            };

            var createdBook = await _bookRepository.AddAsync(book);

            return createdBook.Id;
        }
    }
  }