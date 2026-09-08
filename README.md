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
