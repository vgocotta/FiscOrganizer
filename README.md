# FiscOrganizer

A high-performance file management tool built with **.NET 9** designed to automate the organization of Brazilian Digital Tax Bookkeeping (SPED) files.

## 🚀 The Problem
In Brazil, companies are required to submit extensive digital tax reports (SPED) in text format. When auditors or accountants retrieve these historical files from government servers (Receitanet BX), they are often downloaded in bulk into a single, chaotic directory without meaningful naming conventions.

For a tax revision firm, manually sorting hundreds of these files by company, date, and report type is error-prone and time-consuming.

## 💡 The Solution
**FiscOrganizer** acts as a specialized ETL (Extract, Transform, Load) tool for the local file system. It:
1.  **Scans** a target directory for raw tax files.
2.  **Parses** the content (headers) of each file to extract metadata (CNPJ/Tax ID, Reporting Period, File Type).
3.  **Restructures** the files into a clean, hierarchical folder tree based on the extracted metadata.

## 🛠 Tech Stack
* **Core:** .NET 9 (C# 12)
* **UI:** Windows Forms (Modernized)
* **Concepts:**
    * Asynchronous File I/O
    * Text Parsing & Regex
    * FileSystem Manipulation

## ✨ Key Features
* **Metadata Extraction:** Reads specific structural fields within standard SPED text files (EFD ICMS/IPI, EFD Contribuições, ECD, ECF) to identify the file owner and context.
* **Smart Organization:** Automatically moves and renames files creating a structure like: `root/{Company_Name}/{Year}/{Report_Type}/file.txt`.
* **Legacy Support, Modern Core:** While the UI uses the robust Windows Forms, the underlying logic runs on the latest .NET 9 runtime for maximum performance.

## 📦 How to Run
1.  Clone this repository.
2.  Open the solution in Visual Studio 2022.
3.  Ensure you have the **.NET 9 SDK** installed.
4.  Build and Run.

## 🚧 Roadmap & Future Improvements
* [ ] Implementation of Unit Tests for the file parser logic.
* [ ] Separation of the Core Logic into a standalone Class Library (DLL) or CLI tool.
* [ ] Add support for zipped files.

---
*Built by [Vitor Cotta](https://github.com/vgocotta)*
