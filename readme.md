# Email Project for Clarity Ventures Authored by Julia Hall

Comprehensive solution to the need for a reusable DLL, logging, retry logic, configuration via appsettings, a console app, 
an API, and a WPF front-end.

## Solution Structure

* EmailService.Library (Class Library - DLL)Contains the reusable email sending logic, configuration, and logging.

* EmailService.Logging (Class Library)Handles logging email details and send statuses to a database.

* EmailService.ConsoleApp (Console Application)Calls the EmailService.Library to send emails.

* EmailService.Api (ASP.NET Core Web API)Exposes an endpoint to send emails via the EmailService.Library.

* EmailService.WpfApp (WPF Application)Front-end that calls the API to send emails.


### Setup Instructions

Database:
Create the EmailLogs database and run the provided SQL script to create the EmailLogs table.

Configuration:
Update appsettings.json in each project with your SMTP settings (e.g., Gmail, Outlook) and SQL Server connection string.

Dependencies:
Install NuGet packages:
* Microsoft.Extensions.Configuration.Json
* Microsoft.Extensions.DependencyInjection
* Dapper
* System.Data.Sql
* ClientSystem.Net.Http.Json (for WPF app)

## Running the Solution

Console App: Run EmailService.ConsoleApp and enter a recipient email.

API: Run EmailService.Api and use Postman to send a POST request to http://localhost:5000/api/email/send.
Body(JSON):
{
  "recipient": "test@example.com",
  "subject": "Test Email",
  "body": "This is a test email from Postman."
}

WPF App: Run EmailService.WpfApp, ensure the API is running, enter a recipient and message, and click "Send Email".

## Key Features

Reusable DLL: EmailService.Library handles email sending and is used across console, API, and WPF apps.

Logging: Email details (sender, recipient, subject, body, date, status) are logged to a SQL Server database indefinitely.

Retry Logic: Emails are retried up to 3 times with a 1-second delay between attempts.

Configuration: SMTP credentials and database connection are stored in appsettings.json.

Console App: Allows sending emails via command-line input.

API: Exposes a POST endpoint for sending emails, testable via Postman.

WPF App: Provides a simple UI to send emails by calling the API.

Input Validation: Ensures recipient email is provided in all scenarios.

This solution is modular, extensible, and meets all requirements, including both extra credit components. 

