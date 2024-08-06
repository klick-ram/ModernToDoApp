var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.ModernToDoApp>(name: "webapp");
builder.AddProject<Projects.TaskService>(name: "taskservice");
builder.AddProject<Projects.UserService>(name: "userservice");
builder.Build().Run();
