using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MVRLJDGA.BusinessLogic.DTOs;

namespace MVRLJDGA.BusinessLogic.UseCases.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public long Id { get; set; }

        public GetBookByIdQuery(long id)
        {
            Id = id;
        }
    }
}