using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using SampleCode.Models;
using SampleCode.Services;
using Newtonsoft.Json;

namespace SampleCode
{
    class Program
    {
        private static string connectionString;

        static void Main(string[] args)
        {


            var builder = new ConfigurationBuilder()
                               .AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();
            connectionString = config["AzureBlobConnectionString"];
            BlobTest(connectionString);

        }


        public static void BlobTest(string connectionString)
        {
            var content = new Content();
            content.Id = Guid.NewGuid().ToString();
            content.Title = "Document Title";
            content.Description = "Document Description";

            var jsonContent = JsonConvert.SerializeObject(content, Formatting.Indented);


            var blobId = content.Id + ".json";
            var containerId = "documents";
            var contentType = "text/plain";

            var blobService = new BlobService(connectionString);
            blobService.CreateBlobContainer(containerId);
            var contents = Encoding.ASCII.GetBytes(jsonContent);

            blobService.UploadBlob(containerId, blobId, contents, contentType);


            byte[] result = blobService.GetBlob(containerId, blobId).Result;
            var str = Encoding.Default.GetString(result);

            if (jsonContent.Equals(str))
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }

        }

    }
}
