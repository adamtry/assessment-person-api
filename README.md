# Person API

API to search for Hackney residents and their associated data.

## Stack

- .NET Core as a web framework.
- nUnit as a test framework.

## Contributing

### Setup

1. Install [Docker][docker-download]
2. Clone this repository.
3. Rename the initial template.
4. Open it in your IDE.


### Development

To serve the application, run it using your IDE of choice, we use Visual Studio CE and JetBrains Rider.

### NuGet Packages
At Hackney, we have created the NuGet Package to prevent the duplication of common code when implementing our APIs. Hence our NuGet packages will store the common code that can then be used in the relevant projects. For full details on the different features implemented within our packages please read [this ReadMe](https://github.com/LBHackney-IT/lbh-core/blob/release/README.md)

##### Using the package
For full details on how to use the package(s) within this repository please read
[this wiki page](https://github.com/LBHackney-IT/lbh-core/wiki/Using-the-package(s)-from-the-Hackney.Core-repository).


### Release process

We use a pull request workflow, where changes are made on a branch and approved by one or more other maintainers before the developer can merge into `master` branch.

![Circle CI Workflow Example](docs/circle_ci_workflow.png)

Then we have an automated six step deployment process, which runs in CircleCI.

1. Automated tests (nUnit) are run to ensure the release is of good quality.
2. The application is deployed to development automatically, where we check our latest changes work well.
3. We manually confirm a staging deployment in the CircleCI workflow once we're happy with our changes in development.
4. The application is deployed to staging.
5. We manually confirm a production deployment in the CircleCI workflow once we're happy with our changes in staging.
6. The application is deployed to production.

Our staging and production environments are hosted by AWS. We would deploy to production per each feature/config merged into  `master`  branch.

### Creating A PR

To help with making changes to code easier to understand when being reviewed, we've added a PR template.
When a new PR is created on a repo that uses this API template, the PR template will automatically fill in the `Open a pull request` description textbox.
The PR author can edit and change the PR description using the template as a guide.

## Static Code Analysis

### Using [FxCop Analysers](https://www.nuget.org/packages/Microsoft.CodeAnalysis.FxCopAnalyzers)

FxCop runs code analysis when the Solution is built.

Both the API and Test projects have been set up to **treat all warnings from the code analysis as errors** and therefore, fail the build.

However, we can select which errors to suppress by setting the severity of the responsible rule to none, e.g `dotnet_analyzer_diagnostic.<Category-or-RuleId>.severity = none`, within the `.editorconfig` file.
Documentation on how to do this can be found [here](https://docs.microsoft.com/en-us/visualstudio/code-quality/use-roslyn-analyzers?view=vs-2019).

## Testing

### Run the tests

```sh
$ make test
```

### Agreed Testing Approach
- Use nUnit, FluentAssertions and Moq
- Always follow a TDD approach
- Tests should be independent of each other
- Gateway tests should interact with a real test instance of the database
- Test coverage should never go down
- All use cases should be covered by E2E tests
- Optimise when test run speed starts to hinder development
- Unit tests and E2E tests should run in CI
- Test database schemas should match up with production database schema
- Have integration tests which test from the PostgreSQL database to API Gateway

## Contacts

### Active Maintainers

- **Adam Tracy**, Associate Software Engineer at London Borough of Hackney (adam.tracy@hackney.gov.uk)

[docker-download]: https://www.docker.com/products/docker-desktop
