# Code Challenge: Microservices E-Commerce Platform

## Overview
You are tasked with building a production-ready microservices-based e-commerce platform using .NET, Angular/React, SQL, caching, and Docker. This is a **3-day full-time** challenge where you must demonstrate your ability to architect, implement, and document a distributed system that could be deployed in a production environment.

## 🚨 Critical Constraints
- **NO AI ASSISTANCE**: The use of AI coding assistants (Copilot, ChatGPT, Cursor AI, etc.) is strictly prohibited. Any detection of AI-generated code will result in immediate disqualification.
- **Production-Ready**: Your solution must demonstrate production-quality code with proper error handling, logging, monitoring, security, and performance considerations.
- **Documentation Required**: You must document your architectural decisions, design patterns, and implementation notes in the README.md file. **Do not generate any design documents or diagrams** - these should be described in text within the README.

## Technical Stack
- **Backend**: .NET 8 (C#) with microservices architecture
- **Frontend**: Angular 17+ OR React 18+ with TypeScript
- **Database**: SQL Server or PostgreSQL with proper schema design
- **Caching**: Redis or similar caching solution
- **Message Queue**: RabbitMQ or Azure Service Bus
- **Container**: Docker & Docker Compose
- **API Gateway**: Ocelot or YARP
- **Authentication**: JWT-based authentication

## Core Requirements

### 1. Microservices Architecture (5 services minimum)

#### Service 1: Product Service
- CRUD operations for products
- Product search and filtering
- Category management
- Product image URLs (mock image service)
- Product availability tracking

#### Service 2: Order Service
- Order creation and management
- Order status tracking
- Order history
- Order validation (check product availability)
- Integration with Product Service for validation

#### Service 3: Inventory Service
- Real-time inventory tracking
- Reserve/Release inventory for orders
- Low stock alerts (in logs)
- Batch inventory updates

#### Service 4: Payment Service (Simulated)
- Payment processing (simulate different payment methods)
- Payment status tracking
- Refund processing
- Fraud detection simulation

#### Service 5: Notification Service
- Email notifications (log only)
- Order confirmation, shipping updates, etc.
- Event-driven communication using message queue

#### Service 6: User Service (Optional but recommended)
- User registration and authentication
- User profiles
- Address management
- Role-based access control (Admin/User)

### 2. Frontend Application

Build a single-page application with the following features:

#### User Features
- Product listing with search/filter
- Product details view
- Shopping cart functionality
- Checkout process
- Order history
- User profile management

#### Admin Features
- Product management (CRUD)
- Inventory management
- Order management (view/update status)
- Basic dashboard with metrics

### 3. Technical Requirements

#### API Gateway
- Implement a single entry point for all services
- Rate limiting
- Request/Response transformation
- Authentication/Authorization enforcement

#### Communication Patterns
- **Synchronous**: REST APIs for direct service communication
- **Asynchronous**: RabbitMQ/Azure Service Bus for event-driven communication
  - Events: OrderCreated, PaymentProcessed, InventoryUpdated, etc.

#### Caching Strategy
- Implement Redis caching for:
  - Product catalog (with cache invalidation strategy)
  - User sessions
  - Frequently accessed data
  - Include TTL strategy and cache-aside pattern

#### Database
- Each microservice should have its own database schema
- Implement proper migrations
- No cross-service direct database access
- Include proper indexes and performance optimization

#### Docker
- Containerize each microservice
- Use Docker Compose for local development
- Include health checks
- Environment separation (dev, staging, prod)

#### Security
- JWT-based authentication
- Role-based authorization
- Input validation and sanitization
- SQL injection prevention
- CORS configuration

### 4. Production-Ready Features

#### Observability
- Structured logging (Serilog or similar)
- Correlation IDs across services
- Performance metrics (Prometheus or similar)
- Health checks for each service

#### Error Handling
- Global exception handling
- Custom error responses
- Retry policies with exponential backoff
- Circuit breaker pattern for external calls

#### Testing
- Unit tests for business logic
- Integration tests for API endpoints
- Basic performance/load testing

#### Performance
- Response times under 200ms for 90% of requests
- Support for concurrent users
- Efficient database queries

## Deliverables

### 1. Source Code
- Complete working solution with all services
- Clean, well-structured code following SOLID principles
- Proper naming conventions and code organization
- Comprehensive documentation in code

### 2. README.md (Critical)
- **Architecture Overview**: Describe your microservices architecture, communication patterns, and data flow
- **Design Decisions**: Explain your choices for technology selection, patterns, and trade-offs
- **Implementation Notes**: Document any interesting implementation details or challenges overcome
- **Setup Instructions**: Step-by-step guide to run the application locally
- **API Documentation**: Brief overview of key endpoints
- **Future Improvements**: What would you add given more time

### 3. Docker Configuration
- `docker-compose.yml` for local development
- Individual Dockerfiles for each service
- Environment configuration examples

### 4. Database Scripts
- Migration scripts
- Seed data for development
- Schema documentation

## Evaluation Criteria

### Code Quality (30%)
- Clean, maintainable, and well-organized code
- Proper use of design patterns
- SOLID principles adherence
- Error handling and logging

### Architecture (25%)
- Proper microservices boundaries
- Communication patterns
- Caching strategy
- Database design and optimization

### Production Readiness (20%)
- Security implementation
- Observability (logging, metrics, tracing)
- Error handling and resilience
- Performance considerations

### Documentation (15%)
- README.md quality and thoroughness
- Architecture explanation clarity
- Implementation notes completeness

### Frontend (10%)
- User experience and functionality
- State management
- API integration

## Getting Started

### Prerequisites
- .NET 8 SDK
- Node.js (v18+)
- Docker Desktop
- Git
- Your preferred IDE (Visual Studio, VS Code, Rider)

### Repository Structure Suggestion
```
├── services/
│   ├── product-service/
│   │   ├── src/
│   │   ├── tests/
│   │   └── Dockerfile
│   ├── order-service/
│   ├── inventory-service/
│   ├── payment-service/
│   ├── notification-service/
│   └── user-service/
├── frontend/
│   └── (Angular or React app)
├── docker-compose.yml
├── .env.example
└── README.md
```

## Time Management Suggestion

### Day 1: Foundation
- Set up project structure
- Create service templates
- Dockerize services
- Set up API Gateway
- Implement authentication

### Day 2: Core Business Logic
- Implement all services functionality
- Set up message queue
- Implement caching
- Database schema and migrations

### Day 3: Frontend and Polish
- Build frontend application
- Integrate with services
- Error handling and logging
- Testing and documentation
- Final review and polish

## Notes
- Focus on **working functionality** over perfection
- Prioritize the most critical features first
- Make conservative decisions and document trade-offs
- Be prepared to explain your choices in the README
- Remember: This should be a **production-ready** application

Good luck! This challenge is designed to push your skills across the full spectrum of modern development. Focus on delivering a working, well-documented solution with clear architectural reasoning.

**Deadline**: 72 hours from start time
**Submission**: GitHub repository with all deliverables

# Code Challenge: Documentation

## Architecture
For this microservices-based project I am using the clean architecture approach to keep the different responsibilities and concepts separated each in its own C# project.

The main services folder contains the different services that will be deployed in the project, each one having its own C# solution file. This decision is based on the fact that each service has its own database schema and can be deployed independently and prevents us from accidentally referencing other projects/services in the solution.

The service projects are separated into the following project layers:

### Service.API (Presentation Layer):
This layer is where the requests are handled and passed to the appropriate service. Here we have all the configuration related to the endpoints and the services used to handle the requests. 

### Service.Application (Domain Layer):
Here we have the business logic of the services. It contains the entities and repositories interfaces that are used by the services to interact with the database and other external services.

### Service.Application (Application Layer):
This project contains the services that orchestrate the business logic and communicate with the infrastructure layer. Here we also have the DTO classes that are used to transfer data between the services and the presentation layer.

### Service.Infrastructure (Infrastructure Layer):
This layer contains the main EntityFramework(EF) DB context and the actual repositories used to retrieve and store data in the database. This is also where we will have the EF migrations and SQL scripts.

### Frontend (Client Layer):
Inside the main project's folder we have the Angular project placeholder. This application comes with a ready to execute a windows script that will install all the required dependencies and run the application. Here we will also have two windows scripts to run the application, one for local development with live updates and one for production.

## Implementation Notes
In the Microservices project I have implemented some helper and reusable code to help create services and other components of the project with less boilerplate.

A few highlights of the implementation:
- The services have a base interface and class with basic CRUD methods to reduce the boilerplate code. This way we can simply extend the base class and interface without extra code and have the service ready to be used.
  - `IBaseService<T>`
  - `BaseService<T>`
- In the API initialization, I have separated some configuration from the main `Program.cs` file and created separate files to keep the main file clean and focused on the startup logic.
  - `ServicesConfiguration.cs`
  - `ProductEndpoints.cs`
- I added docker support for both, the Microservices project and the Frontend project.
  - The frontend project has two scripts for local development which allow to develop the application without even having Node.js installed, this is explained in the [setup section](#setup-instructions).
  
## Setup Instructions
Here you can find the instructions to setup both projects. You are going to need some software installed to run both applications.
- Backend: .NET 8 SDK
- Frontend: Node.js (v18+)
- Docker Desktop
- Git
- Your preferred IDE (Visual Studio, VS Code, Rider)

### Frontend
We use Docker compose to run the frontend application. We need to run the containers with Docker or use one of the two different files that are provided `angular-dev` and `angular-prod`. The development container will run the application in watch mode to detect all the changes made in the code and the production container will run the application in production mode.

To run the frontend application in local development mode, you can have Node.js installed or use the provided windows script to install all the required dependencies and run a container and a PowerShell session with Node.js and npm installed. If you are using the script simply right-click the `node.ps1` file and select "Run with PowerShell".

Having done that, now we can use Docker compose to run the application either in development mode or in production mode. The two different services are `angular-dev` and `angular-prod`. The development container will run the application in watch mode to detect all the changes made in the code and the production container will run the application in production mode.

- Using the docker command for dev: docker compose up --build --watch angular-dev
- Using the docker command for prod: docker compose up --build angular-prod
- Using the Windows script: right-click the `docker-angular-prod.ps1` or `docker-angular-dev.ps1` file and select "Run with PowerShell".

### Backend
To run the backend application, you need to run the compose configuration in your desired IDE or run the Docker command inside the compose file's folder: `docker compose -p productservice up -d --build`.

## Future Improvements
Given more time, I would like or would have liked to:
- Have some more time to deal with local environment setup and configuration.
- Implement the frontend application.
- Use correct mapping for the application services with AutoMapper or a custom solution.
- Implement fluent validation for the request models.
- Add tests for both projects.
- Implement authentication and authorization with Firebase.