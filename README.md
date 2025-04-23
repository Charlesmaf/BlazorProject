# Project Name: [Your Project Name Here]

## Overview


This project is a full-stack web application built using .NET 7, ASP.NET Core, and Blazor Server. It follows a clean architecture approach, employing the Generic Repository Pattern and Dependency Injection to promote maintainability, testability, and scalability. The application comprises a Blazor UI, a Service Library for client-server communication, and a .NET Web API for the backend. **This application does not use a database.**

## Tech Stack

* **.NET 7:** The latest version of Microsoft's cross-platform, open-source development platform.
* **ASP.NET Core:** A framework for building modern, cloud-based, internet-connected applications.
* **Blazor Server:** A framework for building interactive web UIs using C# instead of JavaScript. The UI runs on the server, with UI updates sent to the browser over a WebSocket connection.
* **Generic Repository Pattern:** A design pattern that provides an abstraction layer over data access, reducing code duplication and improving maintainability.
* **Dependency Injection:** A design pattern that promotes loose coupling between software components, making applications more flexible and easier to test.
* **Web API:** An application programming interface (API) that uses HTTP to serve requests.
* **Serilog:** A logging library for .NET that provides structured logging, making it easier to diagnose issues.

## Project Structure

The project follows a multi-project structure:

* **Client Application:**
    * **Blazor UI:** The user interface of the application, built with Blazor Server. Handles user interaction and displays data.
    * **ServiceLibrary:** A class library that contains services responsible for communicating with the Web API. This promotes a separation of concerns and allows for reusable client-side logic.
* **Service Application:**
    * **.NET Web API:** The backend of the application, responsible for handling requests from the Client Application, processing data, and interacting with the database.

## Setup Instructions

To set up and run the project, follow these steps:

1.  **Prerequisites:**
    * [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0): Install the .NET 7 SDK on your development machine.
    * [An IDE: ](https://dotnet.microsoft.com/en-us/download/windows) (e.g., Visual Studio, Visual Studio Code, Rider): While not strictly required, using an IDE will greatly simplify the development process.

2.  **Clone the Repository:**
    * Use Git to clone the project repository to your local machine:

        ```bash
        git clone <repository_url>
        cd <project_directory>
        ```

3.  **Run the Service Application (Web API):**
    * Open a terminal or command prompt in the `Service Application` directory.
    * Run the Web API project:

        ```bash
        dotnet run
        ```

        This will start the Web API, and it will be accessible at the URL specified in the output (typically `http://localhost:<port>`).

4.  **Run the Client Application (Blazor UI):**
    * Open a new terminal or command prompt.
    * Navigate to the `Client Application` directory (the directory containing the Blazor project).
    * Run the Blazor Server project:

        ```bash
        dotnet run
        ```

        This will start the Blazor Server application, and it will be accessible in your browser at the URL specified in the output (typically `http://localhost:<port>`).

5.  **Access the Application:**
    * Open your web browser and navigate to the URL displayed in the console when you ran the Blazor Server application.

## Description of Your Approach: Clean Architecture

This project follows the principles of Clean Architecture, which aims to create systems that are:

* **Independent of Frameworks:** The core business logic is independent of any specific UI framework, database, or external service.
* **Testable:** Business logic can be easily tested without relying on UI or database dependencies.
* **Independent of the UI:** The UI can be changed without affecting the business logic.
* **Independent of the Database:** The database can be changed without affecting the business logic.
* **Independent of any external agency.**

Key characteristics of the Clean Architecture in this project:

* **Layers:** The application is divided into layers, each with a specific responsibility. Common layers include:
    * **Domain Layer:** Contains the core business entities and logic. This layer is the most independent and does not depend on any other layers.
    * **Application Layer:** Contains use cases or application services that orchestrate the flow of data between the Domain Layer and the outer layers.
    * **Infrastructure Layer:** Contains the implementation details for external systems, such as the Web API.
    * **Presentation Layer:** (Blazor UI) Handles user interaction and displays data.
* **Dependency Inversion Principle (DIP):** Dependencies between layers are inverted. Outer layers depend on abstractions defined in inner layers, rather than depending on concrete implementations. This is achieved through Dependency Injection.
* **Generic Repository Pattern:** Provides an abstraction over data access, allowing the application to work with different data sources without changing the core business logic.
* **Benefits:**
    * Improved maintainability: Changes in one layer have minimal impact on other layers.
    * Increased testability: Components can be easily tested in isolation.
    * Greater flexibility: The application can be easily adapted to new requirements or technologies.

## Any Challenges You Faced and How You Solved Them

* **Challenge: Mobile Friendliness:**
    * **Description:** Initially, the Blazor UI did not render well on small screens, leading to a poor user experience on mobile devices. Elements were not responsive, and the layout was broken on smaller resolutions.
    * **Solution:**
        * **Used Responsive UI Framework:** Leveraged Bootstrap's responsive features to ensure the UI adapts to different screen sizes. This included using grid layouts, responsive components, and CSS media queries.
        * **Tested on Multiple Devices:** Thoroughly tested the UI on various mobile devices and emulators to identify and fix layout issues.
        * **Optimized for Touch:** Ensured that interactive elements were appropriately sized and spaced for touch interaction.
        * **Used CSS Media Queries:** Implemented CSS media queries to apply specific styles based on the device's screen size, ensuring that the layout and appearance are optimized for different resolutions.

## Any Assumptions You Made

* **API Availability:** The Blazor UI assumes that the Web API is running and accessible at the specified URL.
* **Network Connectivity:** The Blazor Server application assumes a stable WebSocket connection between the client and the server.
* **Basic Security:** The application implements basic security measures (e.g., authentication, authorization). However, it might require additional security considerations for production environments.
* **Configuration:** The application relies on the `appsettings.json` file for configuration settings.
