using MediatR;
using MVRLJDGA.DataAccess.Interfaces;
using MVRLJDGA.Entities; // Usamos tus entidades reales
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MVRLJDGA.BusinessLogic.UseCases.Questions.Queries.GetQuestions
{
   
    public class GetQuestionsHandler : IRequestHandler<GetQuestionsQuery, List<Book>>
    {
        private readonly IEfRepository<Book> _bookRepository;

       
        public GetQuestionsHandler(IEfRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {

            var books = await _bookRepository.ListAsync();

            return books.ToList();
        }
    }
}

