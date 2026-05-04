using MediatR;
using MVRLJDGA.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVRLJDGA.BusinessLogic.UseCases.Books.Queries.GetBooks
{
    public record GetBooksQuery : IRequest<List<BookDto>>;
}