# Azure Function Scalable Batch Sample App

C# apps for Azure Functions sample code.

## Requiements

* Visual Studio 2017 or Visual Studio for Mac

## Note

before build, change the code of ```local.settings.json``` to your connection strings.

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "{YOUR STORAGE ACCOUNT CONNECTION STRING}",
    "AzureWebJobsDashboard": "{YOUR STORAGE ACCOUNT CONNECTION STRING}",
    "StocksConnectionString": "{YOUR COSMOS DB CONNECTION STRING}"
  }
}
```