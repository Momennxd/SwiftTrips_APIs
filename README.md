# Swift Trips

Swift Trips is a comprehensive platform designed to streamline the booking of services such as hotels, flights, cars, and more. The system integrates three core components:

1. **Booking Engine**: Facilitates the booking process for various services.
2. **Channel Manager**: Manages and synchronizes bookings across multiple platforms.
3. **Hotel Management System (HMS)**: Emulates hotel booking processes to streamline operations.

## Technologies Used

- **Backend Framework**: [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)
- **Object-Relational Mapping (ORM)**: [Entity Framework Core (EF Core)](https://docs.microsoft.com/en-us/ef/core/)
- **Database**: [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/)

## Architecture

Swift Trips is built using a three-tier architecture, which separates the application into three distinct layers:

1. **Presentation Tier**: The user interface that interacts with users.
2. **Application Tier (Business Logic)**: Processes data and handles business rules.
3. **Data Tier**: Manages data storage and retrieval.

This architectural approach enhances scalability, maintainability, and allows for independent development and deployment of each tier. :contentReference[oaicite:0]{index=0}

## Project Structure

The Swift Trips environment is organized into the following projects:

- **Booking Engine**: Handles user interactions and booking workflows.
- **Channel Manager**: Manages booking channels and synchronizes data.
- **Hotel Management System (HMS)**: Simulates hotel operations and booking management.

## Documentation
For detailed information on each component, refer to the following documentation:

-  ***Channel Manager***: [Channel Manager Documentation](https://github.com/Momennxd/Channel-Manager)
-  ***Hotel Management System (HMS)***: [Hotel Management System Documentation](https://github.com/AhmedMohammed204/HotelManagmentSystem/tree/master)
