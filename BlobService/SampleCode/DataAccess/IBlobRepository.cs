using System;
using System.Threading.Tasks;

namespace SampleCode.DataAccess
{
    public interface IBlobRepository
    {
        // Create a top level container, e.g., quickstartblobsddfacddf-a44f-4f67-9f18-f44edbb6101e (see azure doc)
        void CreateBlobContainer(string containerId);
        Task<byte[]> DownloadBlob(string containerId, string blobId);
        void UploadBlob(string containerId, string blobId, byte[] content, string contentType);
    }
}
