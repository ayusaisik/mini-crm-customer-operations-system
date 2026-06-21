# Database Draft

This document defines the initial database planning draft. It does not contain SQL migrations or Entity Framework Core entity classes. Names, field types, constraints, and relationships may be refined before implementation.

## General Conventions

- Primary keys use `Id`.
- Date and time values should be stored in UTC.
- Main records include `CreatedAt` and `UpdatedAt` where appropriate.
- Optional foreign keys are marked as nullable.
- Status and type fields may later be implemented with enums.
- Sensitive values such as passwords must never be stored as plain text.

## Roles

Stores authorization roles such as `Admin`, `Manager`, and `User`.

| Column | Suggested Type | Required | Notes |
| --- | --- | --- | --- |
| Id | integer or UUID | Yes | Primary key |
| Name | string | Yes | Unique role name |
| Description | string | No | Short role description |
| CreatedAt | datetime | Yes | UTC creation time |
| UpdatedAt | datetime | No | UTC update time |

## Users

Stores application users who can sign in and manage CRM records.

| Column | Suggested Type | Required | Notes |
| --- | --- | --- | --- |
| Id | integer or UUID | Yes | Primary key |
| RoleId | integer or UUID | Yes | Foreign key to Roles |
| FirstName | string | Yes | User first name |
| LastName | string | Yes | User last name |
| Email | string | Yes | Unique login email |
| PasswordHash | string | Yes | Secure password hash |
| IsActive | boolean | Yes | Account status |
| LastLoginAt | datetime | No | Last successful login time |
| CreatedAt | datetime | Yes | UTC creation time |
| UpdatedAt | datetime | No | UTC update time |

Relationship: one Role can have many Users.

## Companies

Stores business organizations associated with customers and contacts.

| Column | Suggested Type | Required | Notes |
| --- | --- | --- | --- |
| Id | integer or UUID | Yes | Primary key |
| Name | string | Yes | Company name |
| Industry | string | No | Industry or business category |
| Website | string | No | Company website |
| Email | string | No | General email address |
| Phone | string | No | General phone number |
| AddressLine | string | No | Street address |
| City | string | No | City |
| StateOrProvince | string | No | State or province |
| PostalCode | string | No | Postal code |
| Country | string | No | Country |
| CreatedAt | datetime | Yes | UTC creation time |
| UpdatedAt | datetime | No | UTC update time |

## Customers

Stores the main CRM customer records. A customer may represent an individual or a contact associated with a company.

| Column | Suggested Type | Required | Notes |
| --- | --- | --- | --- |
| Id | integer or UUID | Yes | Primary key |
| CompanyId | integer or UUID | No | Optional foreign key to Companies |
| OwnerUserId | integer or UUID | No | Optional foreign key to Users |
| FirstName | string | Yes | Customer first name |
| LastName | string | Yes | Customer last name |
| Email | string | No | Customer email |
| Phone | string | No | Customer phone |
| Status | string | Yes | Example: Lead, Active, Inactive |
| Source | string | No | Customer acquisition source |
| JobTitle | string | No | Customer job title |
| AddressLine | string | No | Street address |
| City | string | No | City |
| StateOrProvince | string | No | State or province |
| PostalCode | string | No | Postal code |
| Country | string | No | Country |
| CreatedAt | datetime | Yes | UTC creation time |
| UpdatedAt | datetime | No | UTC update time |

Relationships:

- One Company can have many Customers.
- One User can own many Customers.

## Contacts

Stores additional people connected to a customer or company.

| Column | Suggested Type | Required | Notes |
| --- | --- | --- | --- |
| Id | integer or UUID | Yes | Primary key |
| CustomerId | integer or UUID | No | Optional foreign key to Customers |
| CompanyId | integer or UUID | No | Optional foreign key to Companies |
| FirstName | string | Yes | Contact first name |
| LastName | string | Yes | Contact last name |
| Email | string | No | Contact email |
| Phone | string | No | Contact phone |
| JobTitle | string | No | Contact job title |
| IsPrimary | boolean | Yes | Primary contact indicator |
| CreatedAt | datetime | Yes | UTC creation time |
| UpdatedAt | datetime | No | UTC update time |

Relationships:

- One Customer can have many Contacts.
- One Company can have many Contacts.
- A Contact should be linked to at least one Customer or Company.

## Notes

Stores text notes related to customer operations.

| Column | Suggested Type | Required | Notes |
| --- | --- | --- | --- |
| Id | integer or UUID | Yes | Primary key |
| CustomerId | integer or UUID | Yes | Foreign key to Customers |
| AuthorUserId | integer or UUID | Yes | Foreign key to Users |
| Content | text | Yes | Note content |
| IsPinned | boolean | Yes | Pinned note indicator |
| CreatedAt | datetime | Yes | UTC creation time |
| UpdatedAt | datetime | No | UTC update time |

Relationships:

- One Customer can have many Notes.
- One User can author many Notes.

## Activities

Stores interactions such as calls, emails, meetings, and follow-ups.

| Column | Suggested Type | Required | Notes |
| --- | --- | --- | --- |
| Id | integer or UUID | Yes | Primary key |
| CustomerId | integer or UUID | Yes | Foreign key to Customers |
| ContactId | integer or UUID | No | Optional foreign key to Contacts |
| CreatedByUserId | integer or UUID | Yes | Foreign key to Users |
| Type | string | Yes | Example: Call, Email, Meeting |
| Subject | string | Yes | Activity title |
| Description | text | No | Activity details |
| ScheduledAt | datetime | No | Planned activity time |
| CompletedAt | datetime | No | Completion time |
| Status | string | Yes | Example: Planned, Completed, Cancelled |
| CreatedAt | datetime | Yes | UTC creation time |
| UpdatedAt | datetime | No | UTC update time |

Relationships:

- One Customer can have many Activities.
- One Contact can have many Activities.
- One User can create many Activities.

## Deals

Stores sales opportunities associated with customers and companies.

| Column | Suggested Type | Required | Notes |
| --- | --- | --- | --- |
| Id | integer or UUID | Yes | Primary key |
| CustomerId | integer or UUID | Yes | Foreign key to Customers |
| CompanyId | integer or UUID | No | Optional foreign key to Companies |
| OwnerUserId | integer or UUID | No | Optional foreign key to Users |
| Title | string | Yes | Deal name |
| Description | text | No | Deal details |
| Value | decimal | Yes | Expected monetary value |
| Currency | string | Yes | Currency code such as USD or EUR |
| Stage | string | Yes | Example: New, Qualified, Proposal, Won, Lost |
| Probability | integer | No | Expected closing probability from 0 to 100 |
| ExpectedCloseDate | date | No | Planned closing date |
| ClosedAt | datetime | No | Actual closing time |
| CreatedAt | datetime | Yes | UTC creation time |
| UpdatedAt | datetime | No | UTC update time |

Relationships:

- One Customer can have many Deals.
- One Company can have many Deals.
- One User can own many Deals.

## Tasks

Stores work items assigned to users and related to CRM records.

| Column | Suggested Type | Required | Notes |
| --- | --- | --- | --- |
| Id | integer or UUID | Yes | Primary key |
| CustomerId | integer or UUID | No | Optional foreign key to Customers |
| DealId | integer or UUID | No | Optional foreign key to Deals |
| AssignedToUserId | integer or UUID | No | Optional foreign key to Users |
| CreatedByUserId | integer or UUID | Yes | Foreign key to Users |
| Title | string | Yes | Task title |
| Description | text | No | Task details |
| Status | string | Yes | Example: Open, InProgress, Completed, Cancelled |
| Priority | string | Yes | Example: Low, Medium, High |
| DueAt | datetime | No | Due date and time |
| CompletedAt | datetime | No | Completion time |
| CreatedAt | datetime | Yes | UTC creation time |
| UpdatedAt | datetime | No | UTC update time |

Relationships:

- One Customer can have many Tasks.
- One Deal can have many Tasks.
- One User can be assigned many Tasks.
- One User can create many Tasks.

## Tags

Stores reusable labels used to categorize customers.

| Column | Suggested Type | Required | Notes |
| --- | --- | --- | --- |
| Id | integer or UUID | Yes | Primary key |
| Name | string | Yes | Unique tag name |
| Color | string | No | Optional display color |
| CreatedAt | datetime | Yes | UTC creation time |
| UpdatedAt | datetime | No | UTC update time |

## CustomerTags

Join table for the many-to-many relationship between Customers and Tags.

| Column | Suggested Type | Required | Notes |
| --- | --- | --- | --- |
| CustomerId | integer or UUID | Yes | Foreign key to Customers; composite primary key |
| TagId | integer or UUID | Yes | Foreign key to Tags; composite primary key |
| AssignedAt | datetime | Yes | UTC assignment time |
| AssignedByUserId | integer or UUID | No | Optional foreign key to Users |

Relationships:

- One Customer can have many Tags.
- One Tag can be assigned to many Customers.

## AuditLogs

Stores important application actions for traceability.

| Column | Suggested Type | Required | Notes |
| --- | --- | --- | --- |
| Id | integer or UUID | Yes | Primary key |
| UserId | integer or UUID | No | Optional foreign key to Users |
| Action | string | Yes | Example: Create, Update, Delete, Login |
| EntityName | string | No | Affected entity type |
| EntityId | string | No | Affected record identifier |
| OldValues | text or JSON | No | Previous values when applicable |
| NewValues | text or JSON | No | New values when applicable |
| IpAddress | string | No | Request IP address |
| UserAgent | string | No | Request client information |
| CreatedAt | datetime | Yes | UTC event time |

Relationship: one User can have many AuditLogs.

## Relationship Summary

- Roles have many Users.
- Users may own Customers and Deals, create Activities and Tasks, and author Notes.
- Companies have many Customers, Contacts, and Deals.
- Customers have many Contacts, Notes, Activities, Deals, Tasks, and Tags.
- Deals may have many Tasks.
- Customers and Tags have a many-to-many relationship through CustomerTags.
- AuditLogs may reference a User and describe changes to any tracked record.

## Items to Confirm Before Implementation

- SQL Server or PostgreSQL
- Integer or UUID primary keys
- Final status, stage, priority, and activity type values
- Delete behavior for related records
- Required uniqueness rules for customer and contact emails
- Whether refresh tokens are needed
- Audit value storage format

