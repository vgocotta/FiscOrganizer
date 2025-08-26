FiscOrganizer

FiscOrganizer
Windows desktop utility (WinForms, .NET 9) to organize Brazilian SPED files by company, period, and finality.

It recognizes EFD ICMS IPI, EFD Contribuições, ECD, and ECF files, optionally renames them in a standard pattern, moves them into a clean folder structure, and logs all actions.
UI messages are in Portuguese (pt-BR).

✨ Features

Detects SPED file type by reading the first line (pipe-delimited) and locating the first CNPJ field.

Supports:

EFD ICMS IPI

EFD Contribuições (.txt, moves matching .rec if present)

ECD

ECF

Organizes into per-company folders named Razão Social - CNPJ.

Per-type subfolders; EFD ICMS IPI additionally nests a CNPJ subfolder.

Optional renaming pattern:

TYPE - CNPJ - yyyyMMdd - yyyyMMdd - FINALITY - N.txt


Option to separate rectified files into a RETIFICADOS subfolder.

Option to move unidentified files to an ERROS folder.

Real-time log panel with detailed operations.

📁 Folder Structure (example)
<DESTINATION>/Razao Social - 12345678000199/EFD CONTRIBUIÇÕES/(files...)
└── RETIFICADOS/(rectified files...)

<DESTINATION>/Razao Social - 12345678000199/EFD ICMS IPI/12345678000199/(files...)
<DESTINATION>/Razao Social - 12345678000199/ECD/(files...)
<DESTINATION>/Razao Social - 12345678000199/ECF/(files...)
<DESTINATION>/ERROS/(unidentified .txt files, if enabled)


If a .rec file exists for EFD Contribuições (same base name), it is moved alongside the .txt.

⚙️ Requirements

Windows 10/11

.NET 9 SDK

Visual Studio 2022 (latest) or dotnet CLI

🚀 Getting Started
Visual Studio

Open the solution

Set FiscOrganizer as the startup project

Build and run

CLI
dotnet build
dotnet run --project FiscOrganizer

🖱️ Usage

Select individual files (.txt) or choose a folder to scan recursively.

Choose the destination folder.

Options:

Rename files

Move unidentified files to ERROS

Separate rectified files into RETIFICADOS

Click “Organize” and follow the log panel.

⚠️ Note: The application moves files. Work on copies or backups when necessary.

🔍 How Recognition Works (summary)

Reads the first line of each file (expects | separated fields).

Locates the first CNPJ field index and maps it to a specific SPED processor.

Extracts CNPJ, Razão Social, period start/end dates, and finality (Original/Retificadora).

Unrecognized files are treated as ERROS (optional move).

🤝 Contributing

Issues and pull requests are welcome.
When reporting recognition issues, include:

Sample file names (sanitize sensitive data)

The first line of affected SPED files

⚠️ Disclaimer

This tool organizes files; it does not validate SPED content or compliance.
Use at your own discretion.
