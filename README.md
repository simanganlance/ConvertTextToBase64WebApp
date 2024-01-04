# ConvertTextWebApp

ConvertTextWebApp is a straightforward Single Page Application (SPA) featuring a .NET 6 .NET Core API Application on the backend and an Angular frontend. It facilitates text-to-base64 conversion using SignalR for real-time communication.

## Description

This application serves as a bridge between a .NET Core API backend and an Angular frontend. Its primary purpose is to convert user-input text to its base64 representation, enabling seamless communication between the backend and frontend using SignalR technology.

## Changing API URL

To modify the API URL used by the application, follow these steps:

### Step 1
Locate the `environment.ts` file in the following directory:
.\ConvertTextWebApp\ConvertTextWebApp\ClientApp\src\app\environments\environment.ts

### Step 2
Edit the file and update the `apiUrl` property with the desired API URL for your IIS or Docker Ports. Below is an example of the code snippet within the `environment.ts` file:

```typescript
export const environment = {
  production: false,
  apiUrl: 'http://localhost:32774' // Replace this URL with your desired API endpoint
};
```
Ensure to replace 'http://localhost:32774' with the appropriate URL where your API is hosted.

## Getting Started
To get the ConvertTextWebApp running locally:

1. Navigate to the root directory of the project.
2. Start the backend API.
3. Navigate to the ClientApp directory.
4. Initiate the Angular frontend using ng serve.
5. Access the application in your preferred web browser.
6. Make sure both the backend API and the Angular frontend are operational simultaneously to utilize the text-to-base64 conversion functionality seamlessly.