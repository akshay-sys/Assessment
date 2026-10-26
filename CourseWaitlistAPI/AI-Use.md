# AI Use Record for CourseWaitlistAPI

## Overview
This document records the use of AI assistance during the development of the `CourseWaitlistAPI` project. It includes the prompts used, relevant AI responses or summaries, how the suggestions were accepted, edited, or rejected, and the files or decisions they informed. Verification evidence is also provided for AI-assisted changes.

---

## Prompts and Responses

### Prompt 1: Project Setup
**Prompt**:  
_"Help me create a .NET Web API project with the following structure:  
- A solution file  
- A Web API project for the main application  
- An xUnit test project for unit tests  
- Add references between the projects and include the Swashbuckle package for Swagger support."_  

**AI Response Summary**:  
The AI provided a step-by-step guide to set up the project using the `dotnet` CLI commands. It included creating the solution, adding the Web API and test projects, linking them, and adding the Swagger package.

**Action Taken**:  
The suggested commands were followed exactly, and the project structure was successfully created. No edits were needed.

**Verification**:  
The solution built successfully, and Swagger UI was accessible at runtime.

---

### Prompt 2: API Design
**Prompt**:  
_"Design APIs for course enrollment, dropping learners, and managing a waitlist. Include endpoints for enrolling learners, dropping learners, viewing enrolled learners, and viewing the waitlist. Keep it simple."_  

**AI Response Summary**:  
The AI suggested four endpoints:
1. `POST /api/course/enroll` for enrolling learners.
2. `DELETE /api/course/drop/{learnerId}` for dropping learners.
3. `GET /api/course/enrolled` for retrieving enrolled learners.
4. `GET /api/course/waitlist` for retrieving the waitlist.

It also provided input/output examples for each endpoint.

**Action Taken**:  
The API design was implemented as suggested, with minor edits to align with the project requirements.

**Verification**:  
The APIs were tested using Swagger and Postman to ensure they worked as expected.

---

### Prompt 3: Service Layer Logic
**Prompt**:  
_"Write the logic for enrolling learners, dropping learners, and promoting learners from the waitlist. Use an in-memory data store and ensure FIFO behavior for the waitlist."_  

**AI Response Summary**:  
The AI provided a `CourseService` class with methods for:
- Enrolling learners (`EnrollLearner`).
- Dropping learners (`DropLearner`).
- Promoting learners from the waitlist (`PromoteLearner`).

The logic included checks for course capacity, duplicate enrollments, and prerequisite validation.

**Action Taken**:  
The provided logic was implemented with slight modifications to handle edge cases (e.g., skipping ineligible learners during promotion).

**Verification**:  
Unit tests were written to validate the service methods, and all tests passed successfully.

---

### Prompt 4: Unit Tests
**Prompt**:  
_"Generate xUnit tests for the `CourseService` methods. Cover scenarios like enrolling when capacity is available, adding to the waitlist when full, dropping learners, and promoting learners from the waitlist."_  

**AI Response Summary**:  
The AI suggested test cases for:
1. Successful enrollment when capacity is available.
2. Adding learners to the waitlist when the course is full.
3. Dropping learners and promoting the next eligible learner from the waitlist.
4. Handling duplicate enrollments and invalid drops.

**Action Taken**:  
The test cases were implemented as suggested, with additional edge cases added (e.g., handling ineligible learners).

**Verification**:  
All tests were executed, and the results confirmed the correctness of the service logic.

---

### Prompt 5: Design Documentation
**Prompt**:  
_"Write a simple design document for the CourseWaitlistAPI. Include an overview, project structure, API descriptions, key design decisions, assumptions, limitations, and future enhancements."_  

**AI Response Summary**:  
The AI provided a well-structured design document covering all requested sections. It included concise descriptions of the APIs, the rationale behind design decisions, and suggestions for future improvements.

**Action Taken**:  
The design document was used with minor edits to better reflect the implemented functionality.

**Verification**:  
The document was reviewed for accuracy and completeness.

---