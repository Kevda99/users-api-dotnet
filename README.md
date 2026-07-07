# User Management API

A robust ASP.NET Core Web API built for TechHive Solutions to manage user records efficiently. This project demonstrates backend development best practices, including the Model-View-Controller (MVC) pattern, custom middleware, and Swagger UI integration.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete user profiles.
- **In-Memory Data Store**: Utilizes a highly performant, thread-safe `ConcurrentDictionary` to handle concurrent API requests.
- **Input Validation**: Ensures that incoming requests contain valid user data (e.g., verifying required fields and email formats).
- **Custom Middleware Pipeline**:
  - **Error-Handling**: Wraps endpoints in a global `try-catch` to guarantee that unhandled exceptions return a standardized `500 Internal Server Error` in JSON format.
  - **Authentication**: Secures API routes by validating incoming requests for an `Authorization` header containing a specific Bearer token (`Bearer secret-token`).
  - **Logging**: Keeps an audit trail of the HTTP method, request path, and status code for all authorized requests.
- **Swagger Documentation**: Features an interactive OpenAPI UI to test endpoints easily during development.

## Tech Stack

- **Framework**: .NET 8 / ASP.NET Core
- **Language**: C#
- **Documentation**: Swashbuckle (Swagger)

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed on your machine.

### Installation & Execution

1. Clone this repository (or download the source code):
   ```bash
   git clone <your-repo-url>
   ```
2. Navigate to the project directory:
   ```bash
   cd UserManagementAPI
   ```
3. Run the application:
   ```bash
   dotnet run
   ```
4. Open your browser and navigate to the Swagger UI to test the endpoints interactively:
   ```text
   http://localhost:<port>/swagger
   ```
   *(Note: The `<port>` will be displayed in your terminal output).*

### API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/users` | Retrieves a list of all users. |
| `GET` | `/api/users/{id}` | Retrieves a specific user by their ID. |
| `POST` | `/api/users` | Creates a new user. |
| `PUT` | `/api/users/{id}` | Updates an existing user's information. |
| `DELETE` | `/api/users/{id}` | Deletes a user by their ID. |

**Important:** To test these endpoints (except for the Swagger UI page itself), you must provide the following HTTP Header to bypass the authentication middleware:
`Authorization: Bearer secret-token`

## AI Assistance Details

This project was developed as a case study simulating the use of Generative AI tools (like GitHub Copilot). The AI was instrumental in scaffolding the project, generating the CRUD logic, debugging missing validations, and establishing the custom middleware pipeline. For more details on the AI interactions and enhancements, check the [CopilotDocumentation.md](CopilotDocumentation.md) file.
