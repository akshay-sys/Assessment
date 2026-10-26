# CourseWaitlist API

## Overview
The CourseWaitlist API is a .NET Web API designed to manage course enrollment, waitlisting, and learner promotion for a single course offering. This API allows learners to enroll in a course, drop their enrollment, and manage a waitlist for when the course reaches capacity.

## Features
- **Enroll Learner**: Allows learners to enroll in the course if they meet the prerequisites and if there is available capacity.
- **Drop Learner**: Enables learners to drop their enrollment, which opens a seat for the next eligible learner on the waitlist.
- **Get Waitlist**: Retrieves the current list of learners waiting for enrollment in the course.
- **Promote Learner**: Automatically promotes the earliest eligible learner from the waitlist when a seat becomes available.

## Project Structure
```
CourseWaitlistAPI
├── CourseWaitlistAPI
│   ├── Controllers
│   │   └── CourseController.cs
│   ├── Models
│   │   ├── Course.cs
│   │   ├── EnrollmentRequest.cs
│   │   └── Learner.cs
│   ├── Services
│   │   └── CourseService.cs
│   ├── Program.cs
│   ├── Startup.cs
│   └── appsettings.json
├── CourseWaitlistAPI.Tests
│   ├── Services
│   │   └── CourseServiceTests.cs
│   └── CourseControllerTests.cs
├── CourseWaitlistAPI.sln
└── README.md
```

## Setup Instructions
1. Clone the repository to your local machine.
2. Navigate to the `CourseWaitlistAPI` directory.
3. Restore the project dependencies using the command:
   ```
   dotnet restore
   ```
4. Run the application using the command:
   ```
   dotnet run
   ```
5. Access the API documentation via Swagger at `http://localhost:5000/swagger`.

## API Endpoints
- `POST /api/course/enroll`: Enroll a learner in the course.
- `DELETE /api/course/drop/{learnerId}`: Drop a learner from the course.
- `GET /api/course/waitlist`: Retrieve the current waitlist.
- `POST /api/course/promote`: Promote the earliest eligible learner from the waitlist.

## Testing
Unit tests are included in the `CourseWaitlistAPI.Tests` project. To run the tests, navigate to the `CourseWaitlistAPI.Tests` directory and execute:
```
dotnet test
```

## Limitations
- The API currently supports only a single course offering.
- Additional features such as user authentication and multi-course management are not implemented.

## Future Enhancements
- Expand the API to support multiple courses.
- Implement user authentication and authorization.
- Add a frontend interface for better user interaction.