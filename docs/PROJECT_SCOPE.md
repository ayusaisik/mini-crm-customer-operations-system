# Project Scope

## Project Goal

The goal of the Mini CRM & Customer Operations Management System is to build a practical, real-world inspired application for organizing customer relationships and daily customer operations. The system will provide a central place to manage customers, companies, contacts, notes, activities, deals, tasks, tags, audit records, and dashboard summaries.

The first version will use a simple ASP.NET Core Web API structure that is easy to understand, maintain, test, and extend.

## MVP Scope

The minimum viable product will include:

- JWT-based user authentication
- Role-based authorization
- Basic user and role management
- Customer create, read, update, and delete operations
- Company and contact management
- Notes linked to customer records
- Customer activity tracking
- Deal and sales status tracking
- Task creation, assignment, and status tracking
- Customer tagging
- Basic dashboard counts and summaries
- Audit logs for important operations
- Request validation and consistent error responses
- Swagger documentation
- Unit tests for selected business logic
- Docker and Docker Compose support
- Updated project documentation and Postman collection

## Out of Scope for the First Version

The following features are intentionally excluded from the first version:

- Full production-ready frontend
- Multi-tenant organization support
- Complex Clean Architecture or microservices
- Real-time notifications
- Email and SMS integrations
- File and document storage
- Advanced analytics and forecasting
- Marketing automation
- Payment processing
- Third-party CRM integrations
- Mobile applications
- Redis caching
- Background job processing
- Kubernetes deployment
- Full production monitoring and observability

These items may be considered after the backend MVP is stable.

## Learning Goals

This project is intended to provide hands-on practice with:

- Planning a small but realistic business application
- Designing relational data models
- Building RESTful APIs with ASP.NET Core
- Using Entity Framework Core for data access
- Implementing JWT authentication and role-based authorization
- Separating controllers, services, DTOs, entities, and validation logic
- Handling errors and logging application events
- Recording audit information
- Writing unit and integration tests
- Documenting and testing APIs with Swagger and Postman
- Containerizing an application with Docker Compose
- Building a TypeScript frontend that consumes a protected API

