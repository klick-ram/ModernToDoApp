# ModernToDoApp

TModernToDoApp is a modern ToDo application built using Blazor WebAssembly for the frontend, ASP.NET Core Web API for the backend microservices, and follows best practices in software development such as dependency injection and clean architecture. 
The application allows you to manage tasks with basic CRUD operations (Create, Read, Update, Delete) using a mock data repository.

## Project Structure

The solution consists of the following projects:

- **ModernToDoApp.Web**: Blazor WebAssembly project for the frontend.
- **ModernToDoApp.App_Host**: App Host project for hosting the services.
- **DutyService**: ASP.NET Core Web API project for managing tasks.
- **UserService**: ASP.NET Core Web API project for managing users.
- **NotificationService**: ASP.NET Core Web API project for managing notifications.
- **TaskDAL**: Class Library project for data access logic.

## Getting Started

### Prerequisites

- .NET SDK 8.0 or later
- A code editor like Visual Studio or Visual Studio Code

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/ModernToDoApp.git
   cd ModernToDoApp
