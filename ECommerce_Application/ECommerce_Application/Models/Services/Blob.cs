using Azure.Storage;
using Azure.Storage.Blobs;
using ECommerce_Application.Models.Interfaces;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Services
{
    public class Blob : IImage
    {
        private IConfiguration _storageConfig { get; set; }

        public Blob(IConfiguration storageConfig)
        {
            _storageConfig = storageConfig;
        }

        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            // createing a reference to the existing container name
            StorageCredentials storageCredentials =
    new StorageCredentials(_storageConfig["AzureStorageAccount"], _storageConfig["AzureKey"]);
            CloudStorageAccount storage = new CloudStorageAccount(storageCredentials, true);
            CloudBlobClient client = storage.CreateCloudBlobClient();
            CloudBlobContainer cbc = client.GetContainerReference(containerName.ToLower());
            await cbc.CreateIfNotExistsAsync();

            await cbc.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            return cbc;
        }
        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            var container = await GetContainer(containerName);
            CloudBlob cb = container.GetBlobReference(imageName);

            return cb;
        }

        public async Task UploadImage(string fileName, byte[] image, string contentType)
        {

            // Create StorageSharedKeyCredentials object by reading
            // the values from the configuration (appsettings.json)
            StorageCredentials storageCredentials =
                new StorageCredentials(_storageConfig["AzureStorageAccount"], _storageConfig["AzureKey"]);
            CloudStorageAccount storage = new CloudStorageAccount(storageCredentials, true);
            CloudBlobClient client = storage.CreateCloudBlobClient();
            // Create the blob client.

            // Upload the file
            var blobContainer = client.GetContainerReference(_storageConfig["ImageContainer"]);
            await blobContainer.CreateIfNotExistsAsync();
            var blobFile = blobContainer.GetBlockBlobReference(fileName);
            blobFile.Properties.ContentType = contentType;
            await blobFile.UploadFromByteArrayAsync(image, 0, image.Length);
        }
    }
}
