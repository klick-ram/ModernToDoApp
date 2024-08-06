var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.ModernToDoApp>(name: "webapp");
builder.AddProject<Projects.TaskService>(name: "taskservice");
builder.Build().Run();
