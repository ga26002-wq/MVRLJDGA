using MediatR;
using MVRLJDGA.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVRLJDGA.BusinessLogic.UseCases.Books.Commands.CreateBook
{
    public record CreateBookCommand(BookDto BookDto) : IRequest<long>;
}