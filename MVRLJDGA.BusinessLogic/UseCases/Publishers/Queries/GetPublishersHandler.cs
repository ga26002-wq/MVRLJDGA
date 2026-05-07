using MediatR;
using MVRLJDGA.DataAccess.Interfaces;
using MVRLJDGA.Entities;
using MVRLJDGA.BusinessLogic.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVRLJDGA.BusinessLogic.UseCases.Publishers.Queries
{
    public class GetPublishersHandler : IRequestHandler<GetPublishersQuery, IEnumerable<PublisherDto>>
    {
        private readonly IEfRepository<Publisher> _publisherRepository;

        public GetPublishersHandler(IEfRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<IEnumerable<PublisherDto>> Handle(GetPublishersQuery request, CancellationToken cancellationToken)
        {
            var publishers = await _publisherRepository.ListAsync();

            return publishers.Select(p => new PublisherDto
            {
                Id = p.Id,
                PublisherName = p.PublisherName
            });
        }
    }
}