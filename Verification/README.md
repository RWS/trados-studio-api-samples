# Trados Studio Verification Samples

This repository contains sample projects demonstrating how to create verification plug-ins for Trados Studio using the Verification API, including identical segment checks, custom verification settings, and custom message UI with edit-and-apply functionality.

## Projects

| Project | Description |
|---------|-------------|
| **Sdl.Verification.Sdk.IdenticalCheck** | Sample global verification plug-in that checks whether target segments are identical to source segments based on configurable context display codes, with a settings UI for specifying the context to verify |
| **Sdl.Verification.Sdk.IdenticalCheck.Extended** | Extended version of the identical segment verifier that adds tag-aware verification using a text generator, and reports messages with extended data to support a custom message UI with suggestions |
| **Sdl.Verification.Sdk.EditAndApplyChanges.MessageUI** | Sample custom message control plug-in that provides a UI for displaying verification messages with source and target segment controls, suggestion lists, and the ability to edit and apply changes directly from the message window |

## Requirements

- .NET Framework 4.8
- Trados Studio installed

## Getting Started

1. Open `Sdl.Verification.Sdk.SampleProjects.sln` in Visual Studio
2. Restore NuGet packages
3. Build the solution

## Resources

- [Verification SDK Documentation](https://developers.rws.com/studio-api-docs/apiconcepts/verification/overview.html)
- [Trados Studio API Developers Community](https://community.rws.com/developers-more/trados-portfolio/trados-studio-developers/)
