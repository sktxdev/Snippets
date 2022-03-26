using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using SampleCode.DataAccess;

namespace SampleCode.Services
{
    public class BlobService : IBlobService
    {

        private IBlobRepository _blobRepository;

        public BlobService(string connectionString)
        {
            _blobRepository = new BlobRepository(connectionString);
        }


        public void CreateBlobContainer(string containerId)
        {
            _blobRepository.CreateBlobContainer(containerId);
        }

        public async Task<byte[]> GetBlob(string containerId, string blobId)
        {
            return await _blobRepository.DownloadBlob(containerId, blobId);
        }

        public void UploadBlob(string containerId, string blobId, byte[] content, string contentType)
        {
            _blobRepository.UploadBlob(containerId, blobId, content, contentType);
        }
    }
}
