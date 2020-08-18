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
        public Task UploadImage(string fileName, byte[] image, string contentType);
        public Task<CloudBlobContainer> GetContainer(string containerName);
        public Task<CloudBlob> GetBlob(string imageName, string containerName);
    }
}
