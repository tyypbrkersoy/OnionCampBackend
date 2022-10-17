using MediatR;
using OnionCamp.Application.Abstractions.Storage;
using OnionCamp.Application.Repositories.EntityRepositories;
using P = OnionCamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCamp.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
        IProductReadRepository _productReadRepository;
        IProductImageFileWriteRepository _productImageFileWriteRepository;
        IStorageService _storageService;

        public UploadProductImageCommandHandler(IProductReadRepository productReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IStorageService storageService)
        {
            _productReadRepository = productReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _storageService = storageService;
        }

        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService
                .UploadAsync("photo-images", request.Files);

            P.Product product = await _productReadRepository.GetByIdAsync(request.Id);

            await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new P.ProductImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<P.Product>() { product }

            }).ToList());

            await _productImageFileWriteRepository.SaveAsync();

            return new();
        }
    }
}
