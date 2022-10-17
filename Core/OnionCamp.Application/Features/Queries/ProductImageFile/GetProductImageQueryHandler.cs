using MediatR;
using OnionCamp.Application.Repositories.EntityRepositories;
using P = OnionCamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OnionCamp.Application.Features.Queries.ProductImageFile
{
    public class GetProductImageQueryHandler : IRequestHandler<GetProductImageQueryRequest, List<GetProductImageQueryResponse>>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IConfiguration configuration;

        public GetProductImageQueryHandler(IProductReadRepository productReadRepository, IConfiguration configuration)
        {
            _productReadRepository = productReadRepository;
            this.configuration = configuration;
        }

        public async Task<List<GetProductImageQueryResponse>> Handle(GetProductImageQueryRequest request, CancellationToken cancellationToken)
        {
            P.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            return product?.ProductImageFiles.Select(p => new GetProductImageQueryResponse
            {
                Path = $"{configuration["StorageUrl:AzureUrl"]}/{p.Path}",
                FileName = p.FileName,
                Id = p.Id
            }).ToList();

        }
    }
}
