# Plante Moran SPO FunctionApp Template

[![Backup Repo][img-gh-action-badge--backup-repo]][gh-action--backup-repo]
[![Build Test and Deploy][img-gh-action-badge--build-test-deploy]][gh-action--build-test-deploy]

This is an Azure Function App template for creating new Function Apps.

## Getting Started

To get started, use this template to create a new repository. For more information, see [creating a repository from a template][create-repo-from-template].

### Create a new repository for the template
1. On the repository _Code_ tab, click the `Use this template` button and choose `Create a new repository`.
1. On the _Create a new repository_ page...
    1. select the _Include all branches_ checkbox
    1. select the _Owner_
    1. enter the new repository name in the _Repository name_ text box
    1. when you are satisfied with the settings, click the `Create repository` button

### Clone the new repo to your machine
```bash
git clone https://github.com/kurt-opel/<new-repo-name>.git
```

### Update the Function App project names
1. Remove the _PM.Template.FunctionApp_, and _PM.Template.FunctionApp.Models_ projects from the solution
1. Navigate to the _src_ directory on your local machine.
1. Update the _PM.Template.FunctionApp_ folder name to _PM.[you-app-name-here].FunctionApp_.
1. Update the _PM.Template.FunctionApp.Models_ folder name to _PM.[you-app-name-here].FunctionApp.Models_.
1. Update the names of the projects in their respective folders with the same naming convention.
1. Repeat the same process of removing and renaming for the Test Project.
1. Back in the solution, add the updated projects back to the solution.
1. Find the pm-template-functionapp.sln.DotSettings file in the _misc_ folder and rename to the name of your solution.

### Update the Function App project namespaces
1. In Visual Studio, select _Class view_ from the _View_ menu to show the Class view.
1. Leveraging the Class View, change all the namespaces to match the new project names.

## Contributing

To contribute to this repository, please see the [contribution guidelines][contributing].

<!--## Register Webhooks

To register this Webhook with an EZT Tasks List or EZT Documents Library, please see [register webhooks][register].
-->
<!-- internal reference urls -->
[contributing]: CONTRIBUTING.md

<!-- external reference urls -->
[create-repo-from-template]: https://docs.github.com/en/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template

<!-- GitHub actions -->
[gh-action--backup-repo]:  https://github.com/kurt-opel/pm-template-functionapp/actions/workflows/backup-repo.yml
[gh-action--build-test-deploy]:  https://github.com/kurt-opel/pm-template-functionapp/actions/workflows/build-test-deploy.yml

<!-- GitHub badges -->
[img-gh-action-badge--backup-repo]: https://github.com/kurt-opel/pm-template-functionapp/actions/workflows/backup-repo.yml/badge.svg
[img-gh-action-badge--build-test-deploy]: https://github.com/kurt-opel/pm-template-functionapp/actions/workflows/build-test-deploy.yml/badge.svg
