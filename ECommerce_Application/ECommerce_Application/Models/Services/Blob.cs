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
    /// <summary>
    /// Referencing the Interface Image
    /// </summary>
    public class Blob : IImage
    {
        private IConfiguration _storageConfig { get; set; }

        private readonly IConfiguration _config;

        public Blob(IConfiguration storageConfig, IConfiguration config)
        {
            _storageConfig = storageConfig;
            _config = config;
        }


        /// <summary>
        /// Get the container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>

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



        /// <summary>
        /// Get the blob
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public async Task<string> GetBlob(string imageName, string containerName)
        {
            var container = await GetContainer(containerName);
            CloudBlob cb = container.GetBlobReference(imageName);
            string FileURL = cb.Uri.AbsoluteUri;

            return FileURL;

        }
        /// <summary>
        /// Gets all Images inside the Blob Container
        /// </summary>
        /// <returns>List of all the Image URL's</returns>
        public async Task<List<string>> GetAllBlobs()
        {
            var container = await GetContainer(_config["ImageContainer"]);
            List<string> FileUrls = new List<string>();
            foreach(IListBlobItem item in container.ListBlobs(null, false))
            {
                FileUrls.Add(item.Uri.AbsoluteUri);
            }

            return FileUrls;

        }


        /// <summary>
        /// Upload the image
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="image"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
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
