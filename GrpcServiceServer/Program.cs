using GrpcServiceServer.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

namespace GrpcServiceServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
/*
            builder.WebHost.ConfigureKestrel((context, serverOptions) =>
            {
                serverOptions.Listen(IPAddress.Loopback, 7139, listenOptions => 
                {
                    // listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
                    // listenOptions.UseHttps("https.pfx", "testex509");
                    listenOptions.UseHttps();
                });
            });
*/

            // Add services to the container.
            builder.Services.AddGrpc();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}