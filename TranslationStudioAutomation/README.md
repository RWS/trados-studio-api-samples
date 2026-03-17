# Trados Studio Translation Studio Automation Samples

This repository contains sample projects demonstrating how to extend and automate Trados Studio using the Translation Studio Automation Integration API, including custom views, view parts, actions, notifications, editor operations, and content connectors.

## Projects

| Project | Description |
|---------|-------------|
| **Sdl.Actions.Samples** | Sample actions demonstrating how to create ribbon group actions, context menu actions, and controller-specific actions in Trados Studio |
| **Sdl.AutoSuggest.Sample** | Sample AutoSuggest provider that copies source segment words as translation suggestions in the editor |
| **Sdl.CustomWizardSteps.Sample** | Sample demonstrating how to add custom wizard pages to Trados Studio package import workflows using WPF views and MVVM |
| **Sdl.EditorOperations.Sample** | Sample view part docked in the Editor view demonstrating document listing, event tracking, segment selections, and integration tests |
| **Sdl.FilesOperations.Sample** | Sample view part docked in the Files view demonstrating file-level operations and interactions with the Files controller |
| **Sdl.License.Sample** | Sample demonstrating how to check Trados Studio license features and conditionally enable plugin functionality |
| **Sdl.Logging.Samples** | Sample demonstrating the plugin logging framework, including initializing loggers via `IPluginLoggerFactory` and writing log entries |
| **Sdl.Notifications.Samples** | Sample demonstrating the Studio notifications system, including creating, grouping, completing, and clearing notifications with custom commands |
| **Sdl.PackagesOperations.Sample** | Sample view part docked in the Projects view demonstrating package operations such as opening packages and executing external jobs with progress reporting |
| **Sdl.ProjectsOperations.Sample** | Sample view part docked in the Projects view demonstrating project listing, selection tracking, and project change events |
| **Sdl.SegmentOperations.Sample** | Sample view part docked in the Editor view demonstrating segment-level operations such as tracking active segment changes and copying segments |
| **Sdl.StudioAutomation.ReferencePlugin** | Reference plugin demonstrating a content connector workflow with incoming translation requests, project creation, Wikipedia search integration, and project quote reporting |
| **Sdl.StudioInitializer.Sample** | Sample application initializer that tracks Studio startup time and prompts the user on early application closure |
| **Sdl.View.Sample** | Sample demonstrating how to create a custom view in Trados Studio with activation and deactivation tracking |
| **Sdl.ViewParts.Sample** | Sample demonstrating how to create a custom view that allows multiple dockable view parts, including project-scoped and content view parts |

## Requirements

- .NET Framework 4.8
- Trados Studio installed

## Getting Started

1. Open `Sdl.StudioAutomation.Samples.sln` in Visual Studio
2. Restore NuGet packages
3. Build the solution

## Resources

- [Translation Studio Automation SDK Documentation](https://developers.rws.com/studio-api-docs/apiconcepts/integration/overview.html)
- [Trados Studio API Developers Community](https://community.rws.com/developers-more/trados-portfolio/trados-studio-developers/)
