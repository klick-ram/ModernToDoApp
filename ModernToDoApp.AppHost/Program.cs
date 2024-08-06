var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.ModernToDoApp>(name: "Web-App");
builder.AddProject<Projects.TaskService>(name: "Task-Service");
builder.AddProject<Projects.UserService>(name: "User-Service");
builder.AddProject<Projects.NotificationService>(name: "Notification-Service");
builder.Build().Run();
