var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.ModernToDoApp>(name: "webapp");
builder.Build().Run();
