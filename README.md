**DocuFlow is a multi-layered .NET Web API application designed to manage documents and folders securely, with support for JWT-based authentication and Swagger testing interface. Features Adding, deleting, listing Folders, Upload documents, Providing JWT Authentication, API Testing via Swagger UI, Layered Architecture(Domain, Application, Infrastructres, API), Built with Microsoft.EntityFrameworkCore, Connected Database(MSSQL)

LAYERS Domain -> Entites, Application -> DTO, Interfaces, Services, Infrastructure -> EF Core DbContext and service Implementations, API -> Controllers, program.cs, Swagger, JWT configurations

You should use this commands to run the project. git clone https://github.com/AhmetCigilogluDev/DocuFlow.git cd DocuFlow dotnet build dotnet run

Then you should go to the swagger interface.**
