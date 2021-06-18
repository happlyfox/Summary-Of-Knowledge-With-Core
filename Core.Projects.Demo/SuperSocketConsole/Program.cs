using SuperSocket.WebSocket.Server;
using System;

namespace SuperSocketConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = WebSocketHostBuilder.Create().UseWebSocketMessageHandler(
        async (session, message) =>
        {
            await session.SendAsync(message.Message);
        }
    )
    .ConfigureAppConfiguration((hostCtx, configApp) =>
    {
        configApp.AddInMemoryCollection(new Dictionary<string, string>
        {
            { "serverOptions:name", "TestServer" },
            { "serverOptions:listeners:0:ip", "Any" },
            { "serverOptions:listeners:0:port", "4040" }
        });
    })
    .ConfigureLogging((hostCtx, loggingBuilder) =>
    {
        loggingBuilder.AddConsole();
    })
    .Build();

            //await host.RunAsync();


        }
    }
}
