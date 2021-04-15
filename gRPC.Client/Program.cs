using Grpc.Net.Client;
using GrpcService.Demo;
using System;
using System.Threading.Tasks;

namespace gRPC.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var response = await client.SayHelloAsync(new HelloRequest { Name="anish" });

            Console.WriteLine(response.Message);
            Console.ReadKey();

        }
    }
}
