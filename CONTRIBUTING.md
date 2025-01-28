# Contributing to the Function App Template

See the [README](README.md) to get an overview of the project
To provide feedback, please follow the guidance in this document.

Use your best judgment and feel free to propose changes to anything in this repository, including these contribution guidelines.

## Creating Issues

- You can [create an issue](../../../issues/new/choose), but before doing that please read the bullets below and include as many details as possible.
- Perform a [cursory search](../../../issues) to see if a similar item has already been submitted.

## Recommended setup for contributing

**NOTE:** Always be sure to use **_only_** approved versions from the [AppDev Workstation Configuration][repo--appdev-workstation-configuration] guide.

### Initial Setup

- Install [Git][git] and clone this repository
- Install .net 8.0.x
- Install Visual Studio
- Install dependencies
  - `dotnet restore`
- Create a file named `local.settings.json` in the `.\src\PM.Template.FunctionApp\` directory.
  - NOTE: The `local.settings.json` file is in the `.gitignore` file and it should continue to be ignored
  - **NEVER COMMIT THIS FILE TO SOURCE CONTROL**
  - Add the following JSON to the file as a starting point

    ```json
    {
      "IsEncrypted": false,
      "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated"
    
        "OpenApi__Version": "v3",
        "OpenApi__DocVersion": "1.0.0",
        "OpenApi__DocTitle": "Swagger Function Template",
        "OpenApi__DocDescription": "This is a sample swagger API designed by [Kurt Opel](https://github.com/kurt-opel)."
      }
    }
    ```

- Create a file named `appsettings.local.json` in the `.\src\Pm.Template.FunctionApp\` directory.
  - NOTE: The `appsettings.local.json` file is in the `.gitignore` file and it should continue to be ignored
  - **NEVER COMMIT THIS FILE TO SOURCE CONTROL**
  - Add the following JSON to the file as a starting point

    ```json
    {
      "SampleString": "Sample Value"
    }
    ```

## Documentation styleguide

- Please reference GitHub's [basic writing and formatting syntax][gh-md-syntax-guidance]
- Use syntax-highlighted examples liberally
- Write one sentence per line.

## Making changes

- Create a [topic branch][topic-branch] named appropriately (`<initials>-issue-<issue#>[-additional-info]`).
  - Branches for new features belong in the `feature/` folder.
  - Branches for bug fixes belong in the `fix/` folder.
  - examples
    - `feature/mob-issue-123`
    - `feature/daf-issue-456-add-cancel-button`
    - `fix/mob-issue-222`
    - `fix/daf-issue-333-fix-typo`
- Once you are ready with your changes, don't forget to self review to quicken the review process ⚡.
  - [ ] ✔️ Confirm that the changes meet the user experience and goals laid out in the issue/requirements/etc.
  - [ ] 🧪 You've **tested the changes locally** to confirm desired functionality.
  - [ ] 📝 Ensure any documentation within the code is updated (README, CONTRIBUTING, etc.).
  - [ ] 🔍 Review the changes for grammar, spelling, etc.
  - [ ] 🎨All code, markdown, etc. is properly formatted, linted, etc.
  - [ ] 🧪 Unit tests are added/updated for changed methods.
  - [ ] 🧪 Unit tests are added for all new methods.
  - [ ] ✅ All unit tests pass.
  - [ ] 💯 Code coverage is at 100%.
  - [ ] etc.

## Commit messages

- Use the present tense ("Add feature" not "Added feature")
- Use the imperative mood ("Move cursor to..." not "Moves cursor to...")
- Limit the first line to 72 characters or less
- Reference issues and pull requests liberally after the first line

## Pull requests

Pull requests serve as the primary mechanism by which contributions are proposed and accepted.

- Open a pull request from your topic branch.
  - For additional guidance, read through the [GitHub Flow Guide][github-flow-guide].
- Don't forget to link the PR to the issue you are solving.
- Be prepared to address feedback on your pull request and iterate if necessary.
- We may ask for changes to be made before a PR can be merged, either using [suggested changes][gh-suggested-changes] or pull request comments.
  - You can apply suggested changes directly through the UI.
  - You can make any other changes in your local branch and push the changes when complete.
- As you update your PR and apply changes, reply to each conversation that required your attention.
- Do not resolve conversations created by other users; reviewers will resolve conversations they start.

<!-- reference urls -->

[gh-md-syntax-guidance]: https://docs.github.com/en/github/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax
[gh-suggested-changes]: https://docs.github.com/en/github/collaborating-with-issues-and-pull-requests/incorporating-feedback-in-your-pull-request
[git]: https://git-scm.com/
[github-flow-guide]: https://guides.github.com/introduction/flow/
[repo--appdev-workstation-configuration]: https://dev.azure.com/plantemorancode/AppDev%20Starter%20Kits/_git/appdev-workstation-config
[topic-branch]: https://www.git-scm.com/book/en/v2/Git-Branching-Branching-Workflows#Topic-Branches
