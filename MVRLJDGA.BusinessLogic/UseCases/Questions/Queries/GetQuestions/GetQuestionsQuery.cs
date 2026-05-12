using MediatR;
using MVRLJDGA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVRLJDGA.BusinessLogic.UseCases.Questions.Queries.GetQuestions
{
    
    public record GetQuestionsQuery : IRequest<List<Book>>;
}