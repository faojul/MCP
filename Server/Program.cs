using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrderMcpServer.Service;

var builder = Host.CreateApplicationBuilder(args);

// stdio is the protocol transport.
// Keep ordinary logs off stdout.
builder.Logging.AddConsole(options =>
{
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

// Singleton is sufficient for this in-memory demo.
// In production, choose the lifetime based on the service's dependencies
// and state. If OrderService injects a scoped DbContext, register it as
// scoped and ensure each tool invocation uses an appropriate DI scope.
// Alternatively, use IDbContextFactory<AppDbContext> to keep
// OrderService singleton while creating and disposing a fresh DbContext
// for each database operation.
builder.Services.AddSingleton<OrderService>();

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

await builder.Build().RunAsync();