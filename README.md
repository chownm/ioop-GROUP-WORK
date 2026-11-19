# Internship Tracker System (IOOP Group Work)

![C#](https://img.shields.io/badge/C%23-.NET%20Framework%204.8-512BD4?style=flat&logo=dotnet&logoColor=white)
![UI](https://img.shields.io/badge/GUI-Windows%20Forms-0078D4?style=flat)
![Database](https://img.shields.io/badge/Database-SQL%20Server%20LocalDB%20(ADO.NET)-CC2927?style=flat&logo=microsoftsqlserver&logoColor=white)
![IDE](https://img.shields.io/badge/IDE-Visual%20Studio%202022-5C2D91?style=flat)

A multi-role Windows Forms desktop application developed in **C# (.NET Framework 4.8)** and **SQL Server LocalDB** for the **Introduction to Object-Oriented Programming (IOOP)** group assignment. The **Internship Tracker System** streamlines the university internship lifecycle across four user roles — **Administrator**, **Company HR / Recruiter**, **Student**, and **University Supervisor** — covering internship postings, resume submissions, application screening, supervisor assignment, daily attendance check-ins, progress reports, performance evaluations, analytics, and database administration.

---

## Table of Contents

- [Features by User Role](#features-by-user-role)
- [Architecture & OOP Design](#architecture--oop-design)
- [Database Schema Overview](#database-schema-overview)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Contributors](#contributors)

---

## Features by User Role

All users sign in through a unified login form (`LoginPage`), which accepts either a **Username** or **Email** plus password against the `Users` table and routes users automatically by role (`admin`, `HR`, `student`, `supervisor`).

### Administrator (`Admin`)
- **Multi-Table User & Record Management (`ManageUsers`)** — Dynamically inspects and manages records across 13 database tables (`users`, `Students`, `Supervisors`, `Recruiters`, `CompanyProfile`, `StudentApplication`, `InternshipOffer`, `Administrators`, `Courses`, `Chapters`, `Check_In_Record`, `Student_Progress`, `Student_Evaluation_Report`) with CRUD controls, search, and input validation.
- **Recruiter Management (`ManageRecruiters`)** — Filter recruiters by company and create recruiter accounts transactionally across both `users` and `Recruiters` linked to `CompanyProfile`.
- **Supervisor Assignment (`AssignSupervisor`)** — Assign registered university supervisors to students.
- **Reporting & Sanitized CSV Export (`GenerateReports`)** — View pending applications and status-filtered activity logs, compute per-table aggregates, and export any table to UTF-8 CSV while automatically stripping sensitive columns (`id`, `password`, `token`, `secret`, `key`, `credential`) and appending summary statistics.
- **System Statistics (`ViewStatistics`)** — Dynamically queries `INFORMATION_SCHEMA.TABLES` to display record counts, application acceptance/rejection/pending breakdowns, average internship allowance, and numeric min/max/avg/total metrics with an auto-rotating highlight banner.
- **System Configuration & Maintenance (`SystemConfiguration`)** — Live record counts, SQL Server `.bak` database backup export, active user log viewer, and safe database reset (preserving schema and the active administrator).

### Company HR / Recruiter (`HR`)
- **Company Profile & Logo (`CompanyProfile` / `CP`)** — Create and update company information (`CompanyName`, `ContactPerson`, `Email`, `ContactNumber`, `Address`, `CompanyDescription`) and upload a company logo (`.jpg`, `.jpeg`, `.png`, `.bmp`) stored as binary PNG bytes in SQL Server.
- **Internship Offer Publishing (`ManageOffer` / `MO`)** — Publish internship opportunities with cascading **Department → Position** selectors across 7 departments (Management & Administration, HR, Finance & Accounting, IT, Sales & Marketing, Production/Operations, Maintenance & Support), start/end dates, monthly allowance (`RM`), and job descriptions.
- **Application Screening (`ViewApplication` / `VP`)** — Review incoming student applications for the HR user's company and **Accept** or **Reject** applicants.
- **Personal Account Settings (`PersonalProfileForm` / `PersonalProfile`)** — Update HR username, email, and password synchronized across `users` and `CompanyProfile`.

### Student (`Student`)
- **Profile Management (`StudentProfileForm` / `StudentProfile`)** — View student details (`StudentID`, `StudentName`, `Email`, `PhoneNumber`, `Course`) and update profile fields transactionally across `Students` and `Users`.
- **Browse Internships & Apply with Resume (`InternshipListForm`, `UploadResumeForm`)** — Browse published offers from `InternshipOffer`, preview and upload a resume image (`.jpg`, `.jpeg`, `.png`), and submit applications to `StudentApplication`.
- **Application Status Tracking (`ViewApplicationStatusForm`)** — Inspect all submitted applications joined with offer details and color-coded status indicators (Green = Accepted, Red = Rejected, Black = Pending).
- **Daily Attendance Check-In & History (`StudentCheckInForm`, `ViewCheckInRecordForm`)** — Log timestamped daily attendance records into `Check_In_Record` and review check-in history.
- **Internship Report Upload (`StudentReportUploadForm`)** — Preview and upload internship progress reports as binary files into `Student_Reports`.
- **Supervisor Evaluation Feedback (`ViewFeedbackForm`)** — Review supervisor scores (Performance, Communication Skills, Punctuality) and written feedback from `Student_Evaluation_Report`.
- **Account Security (`ChangePasswordForm`)** — Update account password with current-password verification. *(A standalone `StudentRegisterForm` / `StudentRegister` module is also included for transactional student onboarding.)*

### University Supervisor (`UniSupervisor`)
- **Student Directory & Profile Review (`Student_Table`, `Student_Profile_Review`)** — Browse all registered students and inspect full student contact and course details.
- **Attendance & Internship Progress Monitoring (`Student_Internship_Table`, `Student_Internship_Progress`, `Check_Internship_Progress`)** — View check-in histories for internship applicants and automatically calculate each student's **Monthly Attendance Rate (%)** against a 20-working-day baseline.
- **Performance Evaluation (`Evaluation_Form`, `Internship_Evaluation`)** — Submit validated `0–100` ratings for **Performance**, **Communication Skills**, and **Punctuality**, along with evaluation dates and written remarks to `Student_Evaluation_Report`.

---

## Architecture & OOP Design

- **Role-Based Modularity:** Organized into five domain folders (`Login`, `Admin`, `HR`, `Student`, `UniSupervisor`).
- **UI & Business Logic Separation:** WinForms views (`*Form.cs`) are paired with dedicated domain/data classes (`StudentProfile`, `InternshipList`, `CP`, `MO`, `VP`, `Internship_Evaluation`, `Check_Internship_Progress`, etc.).
- **Design Patterns & Utilities:**
  - **Singleton (`AdminManager.Instance`):** Thread-safe double-checked locking manager centralizing admin CRUD, statistics, and CSV reporting.
  - **Interface Contract (`IAdminManager`):** Defines reporting and export contracts for administrative operations.
  - **Centralized Validation (`ValidationHelper`):** Reusable email, phone, username, password strength, score/CGPA, file size/type validation, and HTML encoding (`System.Net.WebUtility.HtmlEncode`).
- **ADO.NET Data Access:** Uses `System.Data.SqlClient` with parameterized SQL queries (`SqlCommand.Parameters.AddWithValue`), `ConfigurationManager.ConnectionStrings["DatabaseInfo"]`, and `SqlTransaction` for atomic multi-table updates.

---

## Database Schema Overview

The bundled SQL Server LocalDB database (`Database1.mdf`) contains the following core tables:

| Table | Purpose |
| --- | --- |
| `Users` (`users`) | Shared authentication credentials (`Username`, `Email`, `password`) and `role` |
| `Administrators` | Administrator profile metadata and access levels |
| `Students` | Student profiles, course info, and assigned `SupervisorId` |
| `Supervisors` | University supervisor directory |
| `Recruiters` | Recruiter accounts linked to `Users` and `CompanyProfile` |
| `CompanyProfile` | Company information and binary `CompanyLogo` |
| `InternshipOffer` | Published internship roles, dates, allowance (`Salary`), and company |
| `StudentApplication` | Applications, binary `Resume` uploads, and review `Status` |
| `Check_In_Record` | Daily student attendance timestamps |
| `Student_Reports` | Uploaded binary student progress reports |
| `Student_Evaluation_Report` | Supervisor evaluation scores and written feedback |
| `Courses`, `Chapters`, `Student_Progress` | Academic course/chapter progress tracking managed by Admin |

---

## Project Structure

```text
ioop-GROUP-WORK/
├── FIXES_SUMMARY.md
├── ioop GROUP WORK.sln
└── ioop GROUP WORK/
    ├── App.config                         # LocalDB connection string ("DatabaseInfo")
    ├── Database1.mdf                      # Bundled SQL Server LocalDB database
    ├── Database1_log.ldf                  # LocalDB transaction log
    ├── Program.cs                         # Application entry point (LoginPage)
    ├── ioop GROUP WORK.csproj
    ├── packages.config
    ├── Login/                             # LoginPage WinForm & User auth/routing class
    ├── Admin/                             # AdminHome, AdminManager (Singleton), IAdminManager, ValidationHelper, 6 admin screens
    ├── HR/                                # HRHome, CompanyProfile/CP, ManageOffer/MO, ViewApplication/VP, PersonalProfile
    ├── Student/                           # StudentHome, Profile, InternshipList, UploadResume, Status, CheckIn, Reports, Feedback, Register
    └── UniSupervisor/                     # UniSupervisorHome, Student profile review, attendance tracker, Evaluation_Form
```

---

## Getting Started

### Prerequisites
- **Windows 10 / 11**
- **Visual Studio 2022** with the **.NET desktop development** workload
- **.NET Framework 4.8** Developer / Targeting Pack
- **Microsoft SQL Server Express LocalDB** (installable via the Visual Studio Installer or standalone SQL Server Express)

### Setup & Run Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/chownm/ioop-GROUP-WORK.git
   ```

2. **Open the solution:**
   Launch `ioop GROUP WORK.sln` in Visual Studio 2022 and allow NuGet to restore packages (or right-click the solution → **Restore NuGet Packages**).

3. **Configure the SQL Server LocalDB instance *(important)*:**
   `ioop GROUP WORK/App.config` currently targets the named instance `(LocalDB)\MSSQLLocalDB2025`:
   ```xml
   <add name="DatabaseInfo"
        connectionString="Data Source=(LocalDB)\MSSQLLocalDB2025;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;Connect Timeout=30"
        providerName="System.Data.SqlClient" />
   ```
   Choose one of the following options on your machine:
   - **Option A (Recommended):** Change `Data Source=(LocalDB)\MSSQLLocalDB2025` to the default instance `Data Source=(LocalDB)\MSSQLLocalDB` in `ioop GROUP WORK/App.config`.
   - **Option B:** Create and start the matching named LocalDB instance from Command Prompt:
     ```cmd
     sqllocaldb create MSSQLLocalDB2025
     sqllocaldb start MSSQLLocalDB2025
     ```

4. **Preserve database edits across builds *(optional)*:**
   In Solution Explorer, select `Database1.mdf` and change **Copy to Output Directory** from `Copy always` to `Copy if newer` so changes made while running the app are not overwritten on rebuild.

5. **Build and Run:**
   Press **`Ctrl + Shift + B`** to build and **`F5`** to launch the **Internship Tracker System** login screen.

---

## Contributors

- [@chownm](https://github.com/chownm)
- [@Stephord06](https://github.com/Stephord06)
- [@Bronouman](https://github.com/Bronouman)
- [@LHM2006APU](https://github.com/LHM2006APU) / [@LHM2006](https://github.com/LHM2006)
