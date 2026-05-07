using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MVRLJDGA.BusinessLogic.UseCases.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public DeleteBookCommand(long id)
        {
            Id = id;
        }
    }
}