# SUS.Atomic.Client

[![Build and Test](https://github.com/SUS-Digital-Productions/sus-atomic-client/actions/workflows/build.yml/badge.svg)](https://github.com/SUS-Digital-Productions/sus-atomic-client/actions/workflows/build.yml)
[![NuGet](https://img.shields.io/nuget/v/SUS.AtomicAssets.Client.svg)](https://www.nuget.org/packages/SUS.AtomicAssets.Client/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A comprehensive, fully compatible .NET client library for interacting with Atomic Assets, Atomic Market, and Atomic Tools blockchain APIs. This library provides strongly-typed, fluent API access to all AtomicHub endpoints.

## 📦 Packages

| Package | Description | NuGet |
|---------|-------------|-------|
| **SUS.Atomic.Base** | Core base classes and interfaces | [![NuGet](https://img.shields.io/nuget/v/SUS.Atomic.Base.svg)](https://www.nuget.org/packages/SUS.Atomic.Base/) |
| **SUS.AtomicAssets.Client** | AtomicAssets API client | [![NuGet](https://img.shields.io/nuget/v/SUS.AtomicAssets.Client.svg)](https://www.nuget.org/packages/SUS.AtomicAssets.Client/) |
| **SUS.AtomicMarket.Client** | AtomicMarket API client | [![NuGet](https://img.shields.io/nuget/v/SUS.AtomicMarket.Client.svg)](https://www.nuget.org/packages/SUS.AtomicMarket.Client/) |
| **SUS.AtomicTools.Client** | AtomicTools API client | [![NuGet](https://img.shields.io/nuget/v/SUS.AtomicTools.Client.svg)](https://www.nuget.org/packages/SUS.AtomicTools.Client/) |

## ✨ Features

- 🎯 **Strongly Typed** - Full type safety with generic data models
- 🔗 **Fluent API** - Intuitive method chaining for query building
- 🚀 **Async/Await** - Modern async patterns throughout
- 📝 **Comprehensive** - Supports all AtomicHub API endpoints
- 🧩 **Modular** - Install only the packages you need
- 🔒 **Type Safe** - Nullable reference types enabled
- 📖 **Well Documented** - XML documentation on all public APIs

## 🚀 Quick Start

### Installation

Install the packages you need via NuGet Package Manager:

```bash
# For AtomicAssets API
dotnet add package SUS.AtomicAssets.Client

# For AtomicMarket API
dotnet add package SUS.AtomicMarket.Client

# For AtomicTools API
dotnet add package SUS.AtomicTools.Client
```

### Basic Usage

#### AtomicAssets Client

```csharp
using SUS.AtomicAssets.Client;
using SUS.AtomicAssets.Client.Responses;

// Initialize the client
var client = new AtomicAssetsClient<
    TemplateImmutableData,
    AssetImmutableData,
    AssetMutableData,
    CombinedData,
    SchemaFormat
>("https://wax.api.atomicassets.io/atomicassets/v1");

// Get all assets with filters
var assets = await client
    .Assets
    .All()
    .Limit(10)
    .Order(ascending: false)
    .Execute();

// Get a single asset by ID
var asset = await client
    .Assets
    .Single("1099511627776")
    .Execute();

// Get assets for a specific owner
var ownerAssets = await client
    .Assets
    .All()
    .Owner("myaccount")
    .CollectionName("mycollection")
    .Execute();
```

#### AtomicMarket Client

```csharp
using SUS.AtomicMarket.Client;

// Initialize the client
var marketClient = new AtomicMarketClient<
    TemplateImmutableData,
    AssetImmutableData,
    AssetMutableData,
    CombinedData
>("https://wax.api.atomicassets.io/atomicmarket/v1");

// Get active sales
var sales = await marketClient
    .Sales
    .V1
    .All()
    .State("1") // 1 = active
    .Limit(20)
    .Execute();

// Get sales by collection
var collectionSales = await marketClient
    .Sales
    .V1
    .All()
    .CollectionName("alien.worlds")
    .Execute();

// Get auction details
var auction = await marketClient
    .Auctions
    .Single("12345")
    .Execute();
```

#### AtomicTools Client

```csharp
using SUS.AtomicTools.Client;

// Initialize the client
var toolsClient = new AtomicToolsClient(
    "https://wax.api.atomicassets.io/atomictools/v1"
);

// Get all links
var links = await toolsClient
    .Links
    .All()
    .Limit(10)
    .Execute();

// Get configuration
var config = await toolsClient.Config.Execute();
```

## 🔧 Advanced Usage

### Using HttpClientFactory

For better performance and connection pooling in production applications:

```csharp
// In Startup.cs or Program.cs
services.AddHttpClient();

// In your service
public class MyService
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public MyService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task GetAssets()
    {
        var client = new AtomicAssetsClient<...>("...");
        var assets = await client
            .Assets
            .All()
            .Execute(_httpClientFactory);
    }
}
```

### Custom Data Models

The library supports custom data models for immutable/mutable data:

```csharp
// Define your custom models
public class MyTemplateData
{
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("rarity")]
    public string Rarity { get; set; }
}

public class MyAssetData
{
    [JsonProperty("level")]
    public int Level { get; set; }
}

// Use them in the client
var client = new AtomicAssetsClient<
    MyTemplateData,    // Template immutable data
    MyAssetData,       // Asset immutable data
    MyAssetData,       // Asset mutable data
    object,            // Combined data
    object             // Schema format
>("https://...");
```

### Query Filters

The library supports extensive filtering options:

```csharp
var filteredAssets = await client
    .Assets
    .All()
    .CollectionName("mycollection")
    .SchemaName("myschema")
    .TemplateId("12345")
    .Owner("myaccount")
    .Match("searchterm")
    .Limit(50)
    .Page(1)
    .Order(ascending: false)
    .Execute();
```

## 📚 API Coverage

### AtomicAssets Client

- ✅ Assets (All, Single, Stats, Logs)
- ✅ Collections (All, Single, Stats, Logs)
- ✅ Schemas (All, Single, Stats, Logs)
- ✅ Templates (All, Single, Stats, Logs)
- ✅ Offers (All, Single)
- ✅ Transfers (All)
- ✅ Burns (All, Single)
- ✅ Accounts (All, Single)
- ✅ Config

### AtomicMarket Client

- ✅ Sales V1 & V2 (All, Single, Templates)
- ✅ Auctions (All, Single)
- ✅ Buyoffers (All, Single)
- ✅ Template Buyoffers (All, Single)
- ✅ Marketplaces (All, Single)
- ✅ Assets (All)
- ✅ Stats (Collections, Accounts, Schemas, Graphs)
- ✅ Prices (Assets, Sales, Templates)
- ✅ Config

### AtomicTools Client

- ✅ Links (All)
- ✅ Config

## 🛠️ Development

### Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022 / VS Code / Rider

### Building

```bash
git clone https://github.com/SUS-Digital-Productions/sus-atomic-client.git
cd sus-atomic-client
dotnet build SUS.Atomic.Client/SUS.Atomic.Client.sln
```

### Running Tests

```bash
dotnet test SUS.Atomic.Client/SUS.Atomic.Client.sln
```

## 📝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 🔐 Publishing to NuGet

This repository includes automated publishing to NuGet via GitHub Actions:

1. **Automatic on Release**: Create a GitHub release with a tag like `v1.0.0` to automatically publish
2. **Manual Trigger**: Go to Actions → "Publish to NuGet" → Run workflow and specify the version

### Setup

Add your NuGet API key as a GitHub secret:
1. Go to repository Settings → Secrets and variables → Actions
2. Create a new secret named `NUGET_API_KEY`
3. Paste your NuGet API key as the value

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Built for the [AtomicHub](https://atomichub.io/) ecosystem
- Supports WAX and other EOSIO-based blockchains
- Fully compatible with official Atomic API specifications

## 📧 Support

- GitHub Issues: [Create an issue](https://github.com/SUS-Digital-Productions/sus-atomic-client/issues)
- Documentation: [GitHub Wiki](https://github.com/SUS-Digital-Productions/sus-atomic-client/wiki)

## 🔗 Links

- [AtomicHub](https://atomichub.io/)
- [Atomic Assets API Docs](https://atomicassets.io/docs)
- [NuGet Gallery](https://www.nuget.org/packages?q=SUS.Atomic)

---

Made with ❤️ by [SUS Digital Productions](https://github.com/SUS-Digital-Productions)
