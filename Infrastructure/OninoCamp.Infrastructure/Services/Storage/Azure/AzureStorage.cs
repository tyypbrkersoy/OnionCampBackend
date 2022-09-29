﻿using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OnionCamp.Application.Abstractions.Storage.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OninoCamp.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : Storage,  IAzureStorage
    {
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _containerClient;

        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }

        
        public async Task DeleteAsync(string containerName, string fileName)
        {
            _containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = _containerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string containerName)
        {
            _containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _containerClient.GetBlobs().Select(b => b.Name).ToList();
        }

        public bool HasFile(string containerName, string fileName)
        {
            _containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _containerClient.GetBlobs().Any(b => b.Name == fileName);
        }

        public async Task<List<(string fileName, string pathOrContainer)>> UploadAsync(string containerName, IFormFileCollection files)
        {
            _containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _containerClient.CreateIfNotExistsAsync();
            await _containerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<(string fileName, string pathOrContainer)> datas = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(containerName, file.Name, HasFile);

                BlobClient blobClient = _containerClient.GetBlobClient(fileNewName);
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add((fileNewName, $"{containerName}/{fileNewName}"));
            }
            return datas;
        }
    }
}
