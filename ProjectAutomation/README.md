# Trados Studio Project Automation Samples

This repository contains sample projects demonstrating how to automate translation project workflows using the Trados Studio Project Automation API, including project creation, batch task execution, package management, and translation memory configuration.

## Projects

| Project | Description |
|---------|-------------|
| **Sdl.SDK.ProjectAutomation.Samples.Examples** | Console application demonstrating end-to-end project automation including project creation, file management, TM/termbase configuration, batch task settings (analyze, pre-translate, perfect match, export), project packages, return packages, and project statistics |
| **Sdl.SDK.ProjectAutomation.Samples.BatchAnalyze** | Console application for batch analyzing source files against a translation memory, with options for cross-file repetitions, internal fuzzy match leverage, sub-folder processing, and server publishing |
| **ProjectCreationSample** | Windows Forms application demonstrating project creation from a package or from scratch with batch task execution and project saving |
| **ProjectOperationsSample** | Windows Forms application demonstrating project creation with TM/termbase setup, project settings configuration, batch task execution, manual task creation, package creation, and project/file deletion |
| **BatchTaskSamples** | Sample batch task plugin (Simple Pseudo Translate) demonstrating how to create a custom Trados Studio batch task with configurable settings and a settings UI |

## Requirements

- .NET Framework 4.8
- Trados Studio installed

## Getting Started

1. Open the desired project solution (`.sln`) in Visual Studio
2. Restore NuGet packages
3. Build the solution

> **Note:** The **Sdl.SDK.ProjectAutomation.Samples.Examples** project expects sample files to be placed in `C:\ProjectFiles` before running. See the console instructions displayed at startup for details.

## Resources

- [Project Automation SDK Documentation](https://developers.rws.com/studio-api-docs/apiconcepts/projectautomation/overview.html)
- [Trados Studio API Developers Community](https://community.rws.com/developers-more/trados-portfolio/trados-studio-developers/)
