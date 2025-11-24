var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.TestTask_API>("api");

var frontend = builder.AddExecutable("frontend", "npm", "../TestTask_Client", "run", "dev")
    .WithReference(api)
    .WithHttpEndpoint(name: "http", port: 5173, scheme: "http")
    .WithEnvironment("VITE_API_URL", () => $"{api.GetEndpoint("http").Url}/api")
    .WithEnvironment("PORT", "5173"); 


builder.Build().Run();