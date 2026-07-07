# 🚀 User Management API

![.NET Core](https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

A robust ASP.NET Core Web API built to manage user records efficiently. This project demonstrates backend development best practices, including the MVC pattern, custom middleware, and Swagger UI integration.

> ### 🎯 Quick Guide for Peer Reviewers (3-Minute Tour)
> *If you are grading this project, here is exactly where to find the rubric requirements:*
> - **CRUD Endpoints:** Check `Controllers/UsersController.cs`.
> - **Validation:** Check the `IsValidUser` method inside the controller (`400 BadRequest`).
> - **Middleware:** Check the `Middlewares/` folder for `ErrorHandlingMiddleware.cs`, `AuthenticationMiddleware.cs`, and `LoggingMiddleware.cs`.
> - **AI Usage (Copilot):** See `CopilotDocumentation.md` for details on how AI was used for debugging and scaffolding.

---

## 🌟 Key Features

- **✅ Full CRUD Operations**: Create, Read, Update, and Delete user profiles.
- **⚡ In-Memory Data Store**: Utilizes a highly performant `ConcurrentDictionary` for thread-safe operations.
- **🛡️ Input Validation**: Validates user data (checks for empty fields and valid email format).
- **⚙️ Custom Middleware Pipeline**:
  - **Error-Handling**: Global `try-catch` returning a standard JSON `500 Internal Server Error`.
  - **Authentication**: Secures API routes using an `Authorization: Bearer secret-token` header.
  - **Logging**: Keeps an audit trail of HTTP methods, paths, and status codes.
- **📖 Swagger UI**: Interactive OpenAPI documentation.

---

## 🚀 Getting Started

### 1. Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed on your machine.

### 2. Run the Application
Clone the repository and run the project:
```bash
git clone <your-repo-url>
cd UserManagementAPI
dotnet run
```

### 3. Test with Swagger
Open your browser and navigate to the Swagger UI:
```text
http://localhost:<port>/swagger
```
*(Note: Check your terminal for the exact localhost port).*

---

## 🔑 How to Test the Endpoints

To successfully hit the endpoints (except the Swagger UI), you **must** provide the following HTTP Header to pass the authentication middleware:

**Header:** `Authorization`
**Value:** `Bearer secret-token`

### Sample JSON for POST / PUT
You can copy/paste this dummy data in Swagger when creating or updating a user:
```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@techhive.com",
  "department": "IT"
}
```

---

## 🤖 AI Assistance Details
This project was developed as a case study simulating the use of Generative AI tools (like GitHub Copilot). The AI was instrumental in scaffolding the project, generating the CRUD logic, debugging missing validations, and establishing the custom middleware pipeline. For full details, check [CopilotDocumentation.md](CopilotDocumentation.md).
