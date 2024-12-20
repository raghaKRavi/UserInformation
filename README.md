# User Information API Application

A .NET Web API application for managing user informatio

## Overview

This application provides REST APIs to:
- Create user information
- Update user information
- Retrieve user information with id

## Prerequisites

Before running the application, ensure you have the following installed:

- [.NET SDK (required - version 8)](https://dotnet.microsoft.com/download/dotnet)
- [PostgreSQL](https://www.postgresql.org/download/) (if running without Docker)
- [Docker](https://www.docker.com/get-started) (if running with Docker)


### 1. Clone the Repository
Start by cloning the repository:

```bash
 git clone https://github.com/raghaKRavi/UserInformation.git
```

### 2. Configure Postgres Database

For both running with and without Docker, ensure that you have PostgreSQL configured properly.

###  Running with Docker:

Docker Compose will be used to set up both the Web API application and PostgreSQL container.

Build and run the Docker containers using the following command:

```bash
 docker-compose up --build
```

Docker will build both the Web API and the PostgreSQL containers, then run them. The API will be available on port 5000.

- API URL: http://localhost:8080
- Swagger URL: http://localhost:8080/swagger/index.html

---

###  Running without Docker:

To run the application without Docker, follow these steps:

Step 1: Restore Dependencies

```bash
 dotnet restore
```

Step 2: Update Database (if not done yet)
If you haven't already, run migrations to set up the PostgreSQL database schema:
```bash
 dotnet ef database update
```
Step 3: Run the Application
Once the database is set up, run the application with:
```bash
 dotnet run
```

This will start the Web API locally, and you can access it at:

- API URL: http://localhost:5269
- Swagger URL: http://localhost:5269/swagger/index.html

---
### Note:

If you're facing issue with database connection with application, after running `docker-compose up`,

shut down the container and do a build,
```bash
 docker-compose build
```

then run the `docker-compose up` again.

## Request and Response Objects

### Create User Info

RequestBody:
- `email` : Email
- `firstName` : First Name
- `lastName` : Last Name
- `dob` : Date of Birth
- `phoneNumber` (optional): Phone Number
- `address` : (optional): Address

``` c#
http: POST /api/userinfo
Content-Type: application/json
status: 201Created
response: {
"message": "created"
}
```

### Update User Info

RequestBody:
- `email` : Email
- `firstName` : First Name
- `lastName` : Last Name
- `dob` : Date of Birth
- `phoneNumber` (optional): Phone Number
- `address` : (optional): Address

``` c#
http: PUT /api/userinfo
Content-Type: application/json
status: 200OK
response: {
"message": "updated"
}
```

### Get User Info by Id

Request Parameters:
- `id`: user id

``` c#
http: GET /api/userinfo/{id}
status: 200Ok
response: {
"id": 1,
"name": "John Doe",
"email": "John@gmail.com",
"age": 24,
"dob": "2000-12-19",
"address": "Ireland",
"phoneNumber": "000-000-000",
"updatedAt": "2025-01-01T04:28:19.363408Z"
}
```

### Get All Users

``` c#
http: GET /api/userinfo
status: 200Ok
response: [{
"id": 1,
"name": "John Doe",
"email": "John@gmail.com",
"age": 24,
"dob": "2000-12-19",
"address": "Ireland",
"phoneNumber": "000-000-000",
"updatedAt": "2025-01-01T04:28:19.363408Z"
},

{
"id": 2,
"name": "Marie Mark",
"email": "m.mark@gmail.com",
"age": 30,
"dob": "1994-12-19",
"address": "Ireland",
"phoneNumber": "000-085-050",
"updatedAt": "2025-01-01T04:28:19.363408Z"
}
]
```

---

## Future Enhancements

The following features and improvements are planned to enhance the maintainability, and scalability of the application.

### 1. Extensive Test Coverage
- **Current Status**: Only a limited number of test cases have been implemented.
- **Future Goal**: Implement comprehensive test coverage, ensuring that every method has corresponding test cases. Tests will cover all code branches and edge cases to ensure the reliability and stability of the application.
- **Objective**: Guarantee code quality and catch regressions early in the development process by achieving close to 100% test coverage.

### 2. CI/CD Pipeline and Deployment on AWS
- **CI/CD Setup**: Implement a Continuous Integration and Continuous Deployment (CI/CD) pipeline to automate testing, building, and deploying code.
- **Azure/AWS Deployment**: Deploy the application to AWS services, utilizing services like **ECS, or Lambda** depending on the architecture.
- **Objective**: Enable rapid, reliable, and automated deployments, reducing manual intervention and accelerating the release process.

### 3. Enhanced API Documentation
- **Current Status**: Basic API documentation is provided.
- **Future Goal**: Expand the API documentation to cover all endpoints in detail. This will include:
    - **Error handling**
    - **Detailed parameter explanations**
- **Objective**: Improve developer experience by making it easy for users to understand and integrate with the API.

### 4. Caching Layer for Query Optimization
- **Caching Solution**: Introduce an caching layer (e.g., **Redis**) to improve query performance for frequently accessed data in APIs.
- **Objective**: Reduce database load and improve response times for high-traffic endpoints, enhancing overall application performance and scalability.

---

Each of these features is intended to contribute to a more scalable, maintainable, and robust application architecture, aligning with industry best practices for modern application development.