using Grpc.Net.Client;
using static System.Console;
using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace DndL.Client
{
    public class Program
    {
        static string[] names = { "bob", "jeff", "alan", "boris" };
        
        
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            Greeter.GreeterClient client = new(channel);

            var reply = await client.SayHelloAsync(
                new HelloRequest() { Name = "fooo" });

            WriteLine($"recv {reply.Message}");



            using var call = client.FullDuplexHello();            
            

            var bitask = Task.Run(async () =>
            {
                while (await call.ResponseStream.MoveNext())
                {
                    var note = call.ResponseStream.Current;

                    WriteLine("recv " + note);
                }
            });

            await Task.Run(async () =>
            {
                foreach (var name in names)
                {
                    await call.RequestStream.WriteAsync(
                        new HelloRequest { Name = name });
                    await Task.Delay(1000);
                }
            });

            ReadKey();
        }
    }
}
