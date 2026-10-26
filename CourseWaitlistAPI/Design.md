# Design Document for CourseWaitlistAPI

## Overview

The `CourseWaitlistAPI` is a .NET Web API designed to manage course enrollments, handle waitlists, and promote learners from the waitlist when seats become available. The project is structured to ensure separation of concerns, maintainability, and testability.

---

## Project Structure

- **Controllers**: Contains the `CourseController`, which defines the API endpoints.
- **Services**: Contains the `CourseService`, where the core business logic for enrollment, dropping learners, and waitlist promotion resides.
- **Models**: Defines the data structures used in the application, such as `Course`, `Learner`, and `EnrollmentRequest`.
- **Tests**: Includes unit tests for the `CourseService` to ensure the correctness of the business logic.

---

## APIs in `CourseController`

### 1. Enroll Learner

- **Endpoint**: `POST /api/course/enroll`
- **Input**:

```json
  {
    "LearnerId": 1,
    "PrerequisitesMet": true
  }
```

- **Output**:
  - `200 OK`: Enrollment successful.
  - `400 Bad Request`: Learner already enrolled or prerequisites not met.
  - `202 Accepted`: Learner added to the waitlist (if the course is full).

### 2. Drop Learner

- **Endpoint**: `DELETE /api/course/drop/{learnerId}`
- **Input**: `learnerId` (path parameter)
- **Output**:
  - `200 OK`: Learner dropped successfully, and the next eligible learner from the waitlist is promoted.
  - `404 Not Found`: Learner not found in the enrolled list.

### 3. Get Enrolled Learners

- **Endpoint**: `GET /api/course/enrolled`
- **Input**: None
- **Output**:

```json
  [
    { "Id": 1, "Name": "Learner 1" },
    { "Id": 2, "Name": "Learner 2" }
  ]
```

### 4. Get Waitlist

- **Endpoint**: `GET /api/course/waitlist`
- **Input**: None
- **Output**:

```json
  [
    { "Id": 3, "Name": "Learner 3" },
    { "Id": 4, "Name": "Learner 4" }
  ]
```