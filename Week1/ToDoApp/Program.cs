using System;
using Serilog;

namespace ToDOApp
{
    class Program
    {
        static void Main(string[] args)
        {
         var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        builder.Host.UseSerilog();    

var app = builder.Build();
app.MapGet("/", (ILogger) =>
{
    logger.LogInformation("Hello, World! endpoint was called");
    return "Hello World!";
}); 
        }
    }
}

  

