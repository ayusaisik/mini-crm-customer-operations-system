# Project Roadmap

This roadmap keeps the project simple, practical, and beginner-friendly. Each step should be completed and verified before moving to the next one.

## Step 1: Repository Setup and Planning

- [x] Create the initial README
- [x] Define the project scope
- [x] Create the implementation roadmap
- [x] Draft the database tables and relationships
- [x] Plan the API endpoint groups
- [x] Add repository ignore rules
- [ ] Initialize the Git repository if needed

## Step 2: Create the Backend Solution

- [ ] Create the solution file
- [ ] Create `src/CRM.Api`
- [ ] Create `tests/CRM.Tests`
- [ ] Add the API and test projects to the solution
- [ ] Add only the required backend packages
- [ ] Confirm the default API starts successfully

## Step 3: Add Basic Project Structure

- [ ] Add the planned API folders
- [ ] Configure application settings
- [ ] Add a basic health-check endpoint
- [ ] Configure Swagger
- [ ] Configure application logging
- [ ] Define a consistent API error response

## Step 4: Configure the Database

- [ ] Select SQL Server or PostgreSQL
- [ ] Add Entity Framework Core
- [ ] Create entity classes from the reviewed database draft
- [ ] Create the database context
- [ ] Add entity configurations and relationships
- [ ] Add the initial migration
- [ ] Create and verify the local database
- [ ] Add development seed data where useful

## Step 5: Implement Authentication and Authorization

- [ ] Create user and role models
- [ ] Add secure password hashing
- [ ] Implement registration and login
- [ ] Generate and validate JWT access tokens
- [ ] Add role-based authorization policies
- [ ] Protect administrative endpoints
- [ ] Test authentication flows in Swagger and Postman

## Step 6: Implement the Core CRM MVP

- [ ] Implement customer operations
- [ ] Implement company operations
- [ ] Implement contact operations
- [ ] Implement notes
- [ ] Implement activities
- [ ] Implement deals
- [ ] Implement tasks
- [ ] Implement tags and customer-tag assignments
- [ ] Add DTOs, services, validation, and mappings
- [ ] Add filtering, sorting, and pagination where needed

## Step 7: Add Dashboard and Audit Logging

- [ ] Add dashboard summary endpoints
- [ ] Add customer, deal, activity, and task counts
- [ ] Add audit log persistence
- [ ] Record important create, update, delete, and authentication events
- [ ] Restrict audit log access to authorized roles

## Step 8: Testing and API Verification

- [ ] Add unit tests for important service logic
- [ ] Add authentication and authorization tests
- [ ] Add integration tests for key API flows
- [ ] Verify validation and error responses
- [ ] Create a Postman collection
- [ ] Test all MVP endpoints

## Step 9: Docker Setup

- [ ] Add an API Dockerfile
- [ ] Add Docker Compose
- [ ] Add the selected database service
- [ ] Configure environment variables
- [ ] Verify migrations and startup in containers
- [ ] Document Docker commands

## Step 10: Documentation Review

- [ ] Update the README with final setup instructions
- [ ] Add database and API decisions
- [ ] Document authentication usage
- [ ] Document test commands
- [ ] Add example requests and responses
- [ ] Add screenshots
- [ ] Record learning notes

## Step 11: Frontend

- [ ] Choose React or Next.js
- [ ] Create the TypeScript frontend
- [ ] Add login and protected routes
- [ ] Add dashboard pages
- [ ] Add customer, company, contact, deal, and task pages
- [ ] Add reusable data tables and forms
- [ ] Add client-side validation
- [ ] Connect the frontend to the API
- [ ] Add frontend tests

## Step 12: Future Enhancements

- [ ] Add CSV import and export
- [ ] Add background jobs and reminders
- [ ] Add Redis caching
- [ ] Add email notifications
- [ ] Add advanced reports
- [ ] Add GitHub Actions
- [ ] Review production deployment options

