# API Plan

This document describes the planned REST API surface. It is a planning document only; no controllers or backend implementation exist yet.

## General Conventions

- Planned base path: `/api`
- JSON request and response bodies
- JWT bearer authentication for protected endpoints
- Role-based authorization for administrative endpoints
- Standard HTTP status codes
- Consistent validation and error response format
- Filtering, sorting, and pagination for list endpoints where needed

## Auth

Base path: `/api/auth`

| Method | Endpoint | Purpose | Access |
| --- | --- | --- | --- |
| POST | `/register` | Register a user if registration is enabled | Public or Admin |
| POST | `/login` | Authenticate and return a JWT | Public |
| GET | `/me` | Return the current user profile | Authenticated |
| POST | `/refresh` | Refresh an access token if refresh tokens are added | Authenticated |
| POST | `/logout` | End the current session if token revocation is added | Authenticated |

## Users

Base path: `/api/users`

| Method | Endpoint | Purpose | Access |
| --- | --- | --- | --- |
| GET | `/` | List users | Admin |
| GET | `/{id}` | Get a user by ID | Admin |
| POST | `/` | Create a user | Admin |
| PUT | `/{id}` | Update a user | Admin |
| PATCH | `/{id}/status` | Activate or deactivate a user | Admin |
| PATCH | `/{id}/role` | Change a user's role | Admin |
| DELETE | `/{id}` | Delete or archive a user | Admin |

## Customers

Base path: `/api/customers`

| Method | Endpoint | Purpose | Access |
| --- | --- | --- | --- |
| GET | `/` | List, search, filter, sort, and paginate customers | Authenticated |
| GET | `/{id}` | Get customer details | Authenticated |
| POST | `/` | Create a customer | Authenticated |
| PUT | `/{id}` | Update a customer | Authenticated |
| DELETE | `/{id}` | Delete or archive a customer | Authorized role |
| GET | `/{id}/summary` | Get a customer operation summary | Authenticated |
| GET | `/{id}/tags` | List customer tags | Authenticated |
| POST | `/{id}/tags/{tagId}` | Assign a tag to a customer | Authenticated |
| DELETE | `/{id}/tags/{tagId}` | Remove a customer tag | Authenticated |

## Companies

Base path: `/api/companies`

| Method | Endpoint | Purpose | Access |
| --- | --- | --- | --- |
| GET | `/` | List, search, filter, and paginate companies | Authenticated |
| GET | `/{id}` | Get company details | Authenticated |
| POST | `/` | Create a company | Authenticated |
| PUT | `/{id}` | Update a company | Authenticated |
| DELETE | `/{id}` | Delete or archive a company | Authorized role |
| GET | `/{id}/customers` | List customers associated with a company | Authenticated |
| GET | `/{id}/contacts` | List contacts associated with a company | Authenticated |

## Contacts

Base path: `/api/contacts`

| Method | Endpoint | Purpose | Access |
| --- | --- | --- | --- |
| GET | `/` | List, search, filter, and paginate contacts | Authenticated |
| GET | `/{id}` | Get contact details | Authenticated |
| POST | `/` | Create a contact | Authenticated |
| PUT | `/{id}` | Update a contact | Authenticated |
| DELETE | `/{id}` | Delete a contact | Authorized role |

## Notes

Base path: `/api`

| Method | Endpoint | Purpose | Access |
| --- | --- | --- | --- |
| GET | `/customers/{customerId}/notes` | List notes for a customer | Authenticated |
| POST | `/customers/{customerId}/notes` | Add a note to a customer | Authenticated |
| GET | `/notes/{id}` | Get a note by ID | Authenticated |
| PUT | `/notes/{id}` | Update a note | Author or authorized role |
| DELETE | `/notes/{id}` | Delete a note | Author or authorized role |
| PATCH | `/notes/{id}/pin` | Pin or unpin a note | Authenticated |

## Activities

Base path: `/api/activities`

| Method | Endpoint | Purpose | Access |
| --- | --- | --- | --- |
| GET | `/` | List and filter activities | Authenticated |
| GET | `/{id}` | Get activity details | Authenticated |
| POST | `/` | Create an activity | Authenticated |
| PUT | `/{id}` | Update an activity | Authenticated |
| PATCH | `/{id}/complete` | Mark an activity as completed | Authenticated |
| DELETE | `/{id}` | Delete an activity | Authorized role |
| GET | `/customer/{customerId}` | List activities for a customer | Authenticated |

## Deals

Base path: `/api/deals`

| Method | Endpoint | Purpose | Access |
| --- | --- | --- | --- |
| GET | `/` | List, search, filter, sort, and paginate deals | Authenticated |
| GET | `/{id}` | Get deal details | Authenticated |
| POST | `/` | Create a deal | Authenticated |
| PUT | `/{id}` | Update a deal | Authenticated |
| PATCH | `/{id}/stage` | Change the deal stage | Authenticated |
| DELETE | `/{id}` | Delete or archive a deal | Authorized role |
| GET | `/pipeline` | Return grouped pipeline data | Authenticated |

## Tasks

Base path: `/api/tasks`

| Method | Endpoint | Purpose | Access |
| --- | --- | --- | --- |
| GET | `/` | List and filter tasks | Authenticated |
| GET | `/{id}` | Get task details | Authenticated |
| POST | `/` | Create a task | Authenticated |
| PUT | `/{id}` | Update a task | Authenticated |
| PATCH | `/{id}/status` | Change task status | Authenticated |
| PATCH | `/{id}/assignee` | Assign or reassign a task | Authenticated |
| DELETE | `/{id}` | Delete a task | Authorized role |
| GET | `/my` | List tasks assigned to the current user | Authenticated |

## Dashboard

Base path: `/api/dashboard`

| Method | Endpoint | Purpose | Access |
| --- | --- | --- | --- |
| GET | `/summary` | Return main CRM counts and totals | Authenticated |
| GET | `/customer-growth` | Return customer growth data | Authenticated |
| GET | `/deal-pipeline` | Return deal values grouped by stage | Authenticated |
| GET | `/activities` | Return recent and upcoming activities | Authenticated |
| GET | `/tasks` | Return task status and overdue summaries | Authenticated |

## AuditLogs

Base path: `/api/audit-logs`

| Method | Endpoint | Purpose | Access |
| --- | --- | --- | --- |
| GET | `/` | List and filter audit logs | Admin |
| GET | `/{id}` | Get an audit log by ID | Admin |
| GET | `/entity/{entityName}/{entityId}` | List audit history for a record | Admin |
| GET | `/user/{userId}` | List audit events for a user | Admin |

## Possible Query Parameters

List endpoints may support a consistent subset of these parameters:

- `page`
- `pageSize`
- `search`
- `sortBy`
- `sortDirection`
- `status`
- `ownerId`
- `companyId`
- `customerId`
- `assignedToUserId`
- `fromDate`
- `toDate`

Exact request models and response contracts will be defined during backend implementation.

