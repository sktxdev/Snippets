using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

// from azure.storage.blob import BlobServiceClient, BlobClient, ContainerClient;


namespace SampleCode.DataAccess
{
    public class BlobRepository : IBlobRepository
    {
        private BlobServiceClient _blobServiceClient;

        public BlobRepository(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        // Create a container if it doesnt exist
        public void CreateBlobContainer(string containerId)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerId);
            containerClient.CreateIfNotExists();
        }


        public async Task<byte[]> DownloadBlob(string containerId, string blobId)
        {
            var blobClient = _blobServiceClient.GetBlobContainerClient(containerId);
            var result = await blobClient.GetBlobClient(blobId).DownloadContentAsync();
            var bytes = result.Value.Content.ToArray();
            return bytes;
            }

        public string ReadBlob(string containerId, string blobId)
        {

            var blobClient = _blobServiceClient.GetBlobContainerClient(containerId);
            var result = blobClient.GetBlobClient(blobId).DownloadContentAsync().Result;
            byte[] bytes = result.Value.Content.ToArray();
            return Encoding.Default.GetString(bytes);
        }


        public void UploadBlob(string containerId, string blobId, byte[] content, string contentType)
        {
            var blobClient = _blobServiceClient.GetBlobContainerClient(containerId);

            using (var ms = new MemoryStream(content))
            {
                var existingClient = _blobServiceClient.GetBlobContainerClient(containerId).GetBlobClient(blobId);
                Azure.Response<BlobContentInfo> response = existingClient.Upload(ms, true);
            }
        }
    }
}
