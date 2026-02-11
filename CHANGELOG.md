# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Custom exception types (`AtomicApiException`, `AtomicClientException`) for better error handling
- Comprehensive XML documentation comments on base classes and key methods
- EditorConfig file for consistent code style across the project
- GitHub Actions CI/CD workflows:
  - Build and test workflow
  - Automated NuGet publishing workflow
  - Code quality checks workflow
- Enhanced README with installation instructions, usage examples, and API coverage
- CHANGELOG file to track version history

### Changed
- Replaced generic `Exception` with `AtomicApiException` in error responses
- Removed debug `Console.WriteLine()` from production code in `BaseEndpoint.GetURI()`

### Fixed
- Fixed typo: `IOwnerFillterable` renamed to `IOwnerFilterable` (backward compatible with obsolete attribute)

### Deprecated
- `IOwnerFillterable<Type>` interface (use `IOwnerFilterable<Type>` instead)

## [0.1.8] - Previous Release

### Added
- Initial implementation of AtomicAssets, AtomicMarket, and AtomicTools clients
- Fluent API pattern for query building
- Support for all AtomicHub API endpoints
- Generic type parameters for custom data models
- HttpClientFactory integration support
