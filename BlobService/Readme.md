Packages to add:

For configuration:
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Azure.Storage.Blobs


Azurite Startup
References:
    https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=visual-studio
    https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet

docker run -p 10000:10000 -p 10001:10001 -p 10002:10002 -v ~/Azurite:/data mcr.microsoft.com/azure-storage/azurite

This runs the azurite storage emulator in a docker container with:
Port 10000 => Blobs
Port 10001 => Queue
Port 10002 => Table

Storage is in ~/Azurite on your local desktop


When starting up on an M1 Mac Mini you will see:

WARNING: The requested image's platform (linux/amd64) does not match the detected host platform (linux/arm64/v8) and no specific platform was requested
Azurite Blob service is starting at http://0.0.0.0:10000
Azurite Blob service is successfully listening at http://0.0.0.0:10000
Azurite Queue service is starting at http://0.0.0.0:10001
Azurite Queue service is successfully listening at http://0.0.0.0:10001
Azurite Table service is starting at http://0.0.0.0:10002
Azurite Table service is successfully listening at http://0.0.0.0:10002




To connect to the blob service and queue service, the connection string is:
DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;

To connect to the blob service, the connection string is:
DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;

To connect to the table service, the connection string is:




