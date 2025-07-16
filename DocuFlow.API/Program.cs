using DocuFlow.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using DocuFlow.Application.Services;
using Microsoft.OpenApi.Models;
using DocuFlow.Infrastructure.Data;





var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IDocumentService, DocumentService>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DocuFlow API",
        Version = "v1"
    });
});
// bu dependency injectiondur
//IFolderService, FolderServices
builder.Services.AddScoped<IFolderService, FolderServices>();

//IDocumentService, DocumentService
builder.Services.AddScoped<IDocumentService, DocumentService>();


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
