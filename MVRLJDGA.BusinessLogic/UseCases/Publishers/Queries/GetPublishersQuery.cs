using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MVRLJDGA.BusinessLogic.DTOs;


namespace MVRLJDGA.BusinessLogic.UseCases.Publishers.Queries
{
    public class GetPublishersQuery : IRequest<IEnumerable<PublisherDto>>
    {
    }
}