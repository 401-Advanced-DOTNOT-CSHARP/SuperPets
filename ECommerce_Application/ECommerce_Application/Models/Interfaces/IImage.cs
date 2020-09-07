using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Interfaces
{
    public interface IImage
    {
        /// <summary>
        /// Upload the image to the blob
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="image"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public Task UploadImage(string fileName, byte[] image, string contentType);

        /// <summary>
        /// Get the blob container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public Task<CloudBlobContainer> GetContainer(string containerName);

        /// <summary>
        /// Get the blob which contains the image name and container name
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public Task<string> GetBlob(string imageName, string containerName);
        /// <summary>
        /// Gets all Images inside the Blob Container
        /// </summary>
        /// <returns>List of all the Image URL's</returns>
        public Task<List<string>> GetAllBlobs();
    }
}
