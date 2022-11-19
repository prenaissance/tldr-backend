using Microsoft.AspNetCore;
using TLDR.Api;

var app = BuildWebHost(args);
app.Run();

static IHost BuildWebHost(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        })
        .Build();
