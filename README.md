# Mini CRM & Customer Operations Management System

## Project Purpose

This project is a real-world inspired mini CRM system for managing customers, companies, contacts, notes, activities, deals, tasks, audit logs, and dashboard reports. The goal is to build a practical and beginner-friendly application that demonstrates common customer operations workflows without introducing unnecessary architectural complexity.

## Features

### MVP Features

- User authentication with JWT
- Role-based authorization
- User and role management
- Customer management
- Company and contact management
- Customer notes and activity tracking
- Deal and sales pipeline tracking
- Task assignment and status tracking
- Tags for customer organization
- Dashboard summary reports
- Audit logging for important operations
- Swagger API documentation
- Basic unit tests
- Docker Compose setup

### Future Features

- React or Next.js administration panel
- Advanced search and filtering
- Pagination and sorting
- CSV import and export
- Background jobs and scheduled reminders
- Email notifications
- Redis caching
- File attachments
- Integration tests
- CI/CD with GitHub Actions

## Tech Stack

### Planned Backend

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server or PostgreSQL
- JWT Authentication
- Role-based Authorization
- Swagger
- Postman
- Logging
- Audit Logging
- xUnit
- Docker / Docker Compose

### Planned Frontend

- React or Next.js
- TypeScript
- Axios or Fetch
- Protected Routes
- Data Tables
- Form Validation

## Architecture

The project will use a simple, feature-oriented folder structure within a single ASP.NET Core Web API project:

```text
src/
  CRM.Api/
    Controllers/
    Data/
    Entities/
    DTOs/
    Services/
    Interfaces/
    Middlewares/
    Helpers/
    Mappings/
    Validators/

tests/
  CRM.Tests/
```

This structure is planned for later steps and has not been created yet.

## Database Schema

The initial database draft covers users, roles, customers, companies, contacts, notes, activities, deals, tasks, tags, customer-tag relationships, and audit logs.

See [docs/DATABASE_DRAFT.md](docs/DATABASE_DRAFT.md).

## API Endpoints

The planned API is organized into endpoint groups for authentication, users, customers, companies, contacts, notes, activities, deals, tasks, dashboard reporting, and audit logs.

See [docs/API_PLAN.md](docs/API_PLAN.md).

## Authentication & Authorization

JWT authentication and role-based authorization will be added in a later step. Access rules for administrative and standard user operations will be defined during backend implementation.

## Audit Logging

Audit logging will be added later to record important create, update, delete, authentication, and authorization-related events.

## Docker Setup

Dockerfiles and Docker Compose configuration will be added later for the API, database, and any supporting services.

## Running the Project

The backend project has not been created yet. Setup and run instructions will be added in the next implementation steps.

## Running Tests

Tests and test commands will be added later.

## Screenshots

Screenshots will be added after the API and frontend interfaces are implemented.

## What I Learned

Learning notes and implementation takeaways will be documented as the project develops.

## Future Improvements

- React or Next.js admin panel
- Advanced filtering and search
- Pagination and sorting
- CSV import and export
- Background jobs
- Redis cache
- Integration tests
- GitHub Actions workflows

