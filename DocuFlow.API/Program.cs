using DocuFlow.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using DocuFlow.Application.Services;
using Microsoft.OpenApi.Models;
using DocuFlow.Infrastructure.Data;
using DocuFlow.Infrastructure.Services;





var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IDocumentService, DocumentService>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo
//     {
//         Title = "DocuFlow API",
//         Version = "v1"
//     });
// });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DocuFlow API", Version = "v1" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    };

    c.AddSecurityDefinition("Bearer", securitySchema);

    var securityRequirement = new OpenApiSecurityRequirement
    {
        { securitySchema, new[] { "Bearer" } }
    };

    c.AddSecurityRequirement(securityRequirement);
});

// bu dependency injectiondur
//IFolderService, FolderServices
builder.Services.AddScoped<IFolderService, FolderServices>();

//IDocumentService, DocumentService
builder.Services.AddScoped<IDocumentService, DocumentService>();

//UserService Dependenyh Injection
builder.Services.AddScoped<IUserService, UserService>();


//AppDbContext.cs
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("DocuFlowDb")); // veya SQL Server vs.


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DocuFlow API v1");
        c.RoutePrefix = string.Empty;
    });
}


app.UseHttpsRedirection();

app.UseAuthorization(); 

app.MapControllers();  



app.Run();
