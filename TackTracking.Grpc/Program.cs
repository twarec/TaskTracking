using Calzolari.Grpc.AspNetCore.Validation;
using TackTracking.Grpc.Services;
using TackTracking.Grpc.Services.Grpc;
using TaskTracking.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc(_ =>
{
    _.EnableDetailedErrors = true;
});

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

app.MapGrpcService<UserService>();
app.MapGrpcService<TaskCommentService>();
app.MapGrpcService<TaskService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
