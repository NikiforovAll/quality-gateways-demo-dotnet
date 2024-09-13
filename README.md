# Quality Gateways [![Build](https://github.com/NikiforovAll/quality-gateways-demo-dotnet/actions/workflows/build.yml/badge.svg?branch=main)](https://github.com/NikiforovAll/quality-gateways-demo-dotnet/actions/workflows/build.yml)


[![GitHub Actions Build History](https://buildstats.info/github/chart/nikiforovall/quality-gateways-demo-dotnet?branch=main&includeBuildsFromPullRequest=false)](https://github.com/NikiforovAll/quality-gateways-demo-dotnet/actions)

Code quality is especially important in a team environment. The only way to achieve this is by enforcing quality gates (QG). Quality gates are automated checks that the code meet quality standards.

The are two main aspects of enforcing quality gates:
1. Make sure that code quality is enforced, so it is not possible to merge code that does not meet the quality standards.
2. Keep the feedback loop as short as possible, so developers can fix the issues as soon as possible. Developers will rebel against QG if they impact their productivity and developer experience (DevEX).

Quality Attributes:

* Consistent formatting
* Consistent naming
* Consistent code style
* No spelling mistakes
* No code smells
* No security vulnerabilities
* No performance issues


## Developer Feedback Loop

1. IDE/Linter
2. Pre-commit hooks
3. CI/CD
    1. Automated tests
    2. Code quality checks
    3. Security checks
4. Code Review

Assume we have initial code that does not meet the quality standards.

![code-before](./assets/code-before.png)

1. First of all, the developer will receive feedback from the IDE and linter.
2. Before committing the code, Husky will run pre-commit hooks. And if any of the checks fail, the commit will be rejected.
3. The CI/CD pipeline will run the same checks (and maybe other checks such as automated tests). And if any of the checks fail, the pipeline will fail.

☝️ Note, not all checks are equal. For example, you don't really want to run the entire test suite in the pre-commit hook. You want to run only the fast checks.

## Running the demo

Prerequisites:

* `dotnet tool restore`
* `npm install -g cspell`

Run it:

```bash
dotnet run husky
```

This command runs the following checks sequentially:

```json
{
    "$schema": "https://alirezanet.github.io/Husky.Net/schema.json",
    "tasks": [
        {
            "name": "format",
            "group": "pre-commit",
            "command": "dotnet",
            "args": ["csharpier", ".", "--check"]
        },
        {
            "name": "style",
            "group": "pre-commit",
            "command": "dotnet",
            "args": ["format", "style", ".", "--verify-no-changes"]
        },
        {
            "name": "analyzers",
            "group": "pre-commit",
            "command": "dotnet",
            "args": ["format", "analyzers", ".", "--verify-no-changes"]
        },
        {
            "name": "spelling",
            "group": "pre-commit",
            "command": "cspell",
            "args": ["lint", "**.cs", "--no-progress", "--no-summary"]
        }
    ]
}
```

We can run the checks individually:

```bash
dotnet husky run --name format
```

```bash
dotnet husky run --name style
```

```bash
dotnet husky run --name analyzers
```

```bash
dotnet husky run --name spelling
```


## References

- <https://alirezanet.github.io/Husky.Net/>
- <https://csharpier.com/>
- <https://docs.sonarsource.com/sonarcloud/>
- <https://rules.sonarsource.com/csharp/>
- <https://github.com/bkoelman/CSharpGuidelinesAnalyzer>
- <https://github.com/streetsidesoftware/cspell>
- <https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/configuration-options>
- <https://microsoft.github.io/code-with-engineering-playbook/developer-experience/>
