# Trados Studio Language Platform Samples

This repository contains sample projects demonstrating how to work with Trados Studio's Language Platform, including translation memory automation, translation provider plugins, and AI companion integration.

## Projects

| Project | Description |
|---------|-------------|
| **Sdl.SDK.LanguagePlatform.Samples.AICompanion** | Sample AI Companion plugin demonstrating how to integrate an AI translation provider into Trados Studio with configurable connections and prompts |
| **Sdl.SDK.LanguagePlatform.Samples.BatchExport** | Console application for batch exporting translation memories from a specified folder to TMX files |
| **Sdl.SDK.LanguagePlatform.Samples.BatchImport** | Console application for batch importing TMX files from a folder into master translation memories |
| **Sdl.SDK.LanguagePlatform.Samples.TmAutomation** | Console application demonstrating TM automation tasks such as creating, importing, exporting, searching, and managing translation memories |
| **Sdl.SDK.LanguagePlatform.Samples.TmLookup** | Windows Forms application for performing translation memory lookups with a graphical user interface |
| **TMAutomation** | Windows Forms application demonstrating file-based and server-based translation memory operations including creating, importing, exporting, and searching TMs |
| **TranslationProvider** | Sample translation provider plugin (List Provider) that performs simple translations based on delimiter-separated list files |

## Requirements

- .NET Framework 4.8
- Trados Studio installed

## Getting Started

1. Open the desired project solution (`.sln`) in Visual Studio
2. Restore NuGet packages
3. Build the solution

## Resources

- [Language Platform SDK Documentation](https://developers.rws.com/studio-api-docs/apiconcepts/translationmemory/overview.html)
- [Trados Studio API Developers Community](https://community.rws.com/developers-more/trados-portfolio/trados-studio-developers/)
