# Contributing to SUS.Atomic.Client

First off, thank you for considering contributing to SUS.Atomic.Client! It's people like you that make this library better for everyone.

## Code of Conduct

This project and everyone participating in it is governed by our commitment to providing a welcoming and inspiring community for all. Please be respectful and constructive in your interactions.

## How Can I Contribute?

### Reporting Bugs

Before creating bug reports, please check the existing issues to avoid duplicates. When you create a bug report, include as many details as possible:

- **Use a clear and descriptive title**
- **Describe the exact steps to reproduce the problem**
- **Provide specific examples** (code snippets, API calls, etc.)
- **Describe the behavior you observed** and what you expected
- **Include your environment details** (.NET version, OS, etc.)

### Suggesting Enhancements

Enhancement suggestions are tracked as GitHub issues. When creating an enhancement suggestion, include:

- **Use a clear and descriptive title**
- **Provide a detailed description** of the suggested enhancement
- **Explain why this enhancement would be useful** to most users
- **List any similar features** in other libraries if applicable

### Pull Requests

1. **Fork the repository** and create your branch from `main`
2. **Make your changes** following the coding standards below
3. **Add or update tests** if applicable
4. **Update documentation** if you're changing functionality
5. **Ensure the test suite passes** (`dotnet test`)
6. **Make sure your code builds** without warnings
7. **Write a clear commit message**

## Development Setup

### Prerequisites

- .NET 8.0 SDK or later
- Git
- A code editor (Visual Studio, VS Code, or Rider recommended)

### Setting Up Your Development Environment

```bash
# Clone your fork
git clone https://github.com/YOUR_USERNAME/sus-atomic-client.git
cd sus-atomic-client

# Add upstream remote
git remote add upstream https://github.com/SUS-Digital-Productions/sus-atomic-client.git

# Create a branch for your changes
git checkout -b feature/your-feature-name

# Restore dependencies
dotnet restore SUS.Atomic.Client/SUS.Atomic.Client.sln

# Build the solution
dotnet build SUS.Atomic.Client/SUS.Atomic.Client.sln

# Run tests
dotnet test SUS.Atomic.Client/SUS.Atomic.Client.sln
```

## Coding Standards

### C# Style Guidelines

This project follows standard C# conventions with a few specific preferences:

- **Indentation**: 4 spaces (configured in `.editorconfig`)
- **Braces**: Always use braces, even for single-line statements
- **Naming Conventions**:
  - PascalCase for public members, types, and methods
  - camelCase with `_` prefix for private fields
  - Async methods should end with `Async`
- **Documentation**: All public APIs must have XML documentation comments
- **Nullable References**: Enabled - handle nullability properly

### Code Quality

- **No warnings**: Code should compile without warnings
- **Follow existing patterns**: Stay consistent with the existing codebase
- **Keep it simple**: Prefer clarity over cleverness
- **Single Responsibility**: Each class/method should have one clear purpose

## Testing Guidelines

- Write tests for new functionality
- Maintain or improve code coverage
- Tests should be:
  - **Independent**: Not relying on order of execution
  - **Repeatable**: Same result every time
  - **Fast**: Quick to execute
  - **Clear**: Easy to understand what's being tested

## Documentation

- Update the README.md if you change functionality
- Add XML documentation comments to all public APIs
- Update CHANGELOG.md with your changes
- Include code examples for new features

## Commit Messages

Write clear, concise commit messages:

```
Add feature to filter assets by multiple schemas

- Implement ISchemaFilterable interface
- Add SchemaNames extension method
- Update tests and documentation
```

- Use present tense ("Add feature" not "Added feature")
- First line should be a brief summary (50 chars or less)
- Add detailed description if needed (wrapped at 72 chars)
- Reference issues and pull requests when relevant

## Pull Request Process

1. **Update your fork** with the latest upstream changes:
   ```bash
   git fetch upstream
   git rebase upstream/main
   ```

2. **Ensure your branch builds and passes tests**:
   ```bash
   dotnet build SUS.Atomic.Client/SUS.Atomic.Client.sln
   dotnet test SUS.Atomic.Client/SUS.Atomic.Client.sln
   ```

3. **Push your changes**:
   ```bash
   git push origin feature/your-feature-name
   ```

4. **Create a pull request** with:
   - Clear title describing the change
   - Detailed description of what changed and why
   - Reference to any related issues
   - Screenshots/examples if applicable

5. **Address review feedback** promptly and professionally

## Release Process

Releases are managed by maintainers:

1. Update version numbers in `.csproj` files
2. Update CHANGELOG.md
3. Create a Git tag (e.g., `v1.0.0`)
4. Create a GitHub Release
5. Automated workflow publishes to NuGet

## Questions?

Feel free to open an issue with the "question" label if you need help or clarification on anything.

## License

By contributing, you agree that your contributions will be licensed under the MIT License.

---

Thank you for contributing to SUS.Atomic.Client! 🎉
