# SUS.Atomic.Tests

Unit tests for the SUS.Atomic.Client library.

## Running Tests

To run all tests:

```bash
dotnet test
```

To run tests with detailed output:

```bash
dotnet test --verbosity detailed
```

To run tests with code coverage:

```bash
dotnet test --collect:"XPlat Code Coverage"
```

## Test Structure

- **Base/** - Tests for core base classes and functionality
  - `BaseEndpointTests.cs` - Tests for BaseEndpoint query building
  - `ExceptionTests.cs` - Tests for custom exception types

- **Extensions/** - Tests for extension methods
  - `ExtensionMethodsTests.cs` - Tests for fluent API extension methods

## Adding New Tests

When adding new tests:

1. Follow the Arrange-Act-Assert (AAA) pattern
2. Use descriptive test method names that explain what is being tested
3. Group related tests in the same test class
4. Add XML documentation comments to test classes
5. Ensure tests are independent and can run in any order

## Test Coverage

The test suite aims to cover:

- Core functionality of base classes
- Extension methods for fluent API
- Custom exception types
- Query parameter building
- URI generation

Note: Integration tests that call actual API endpoints are not included to avoid external dependencies.
