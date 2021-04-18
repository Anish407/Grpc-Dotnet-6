using Grpc.Net.Client;
using GrpcService.Demo.client.Protos;
using GrpcService.Demo.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPC.Client
{
    public class ClientStreamingProgram
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ClientStreamerDemoService.ClientStreamerDemoServiceClient(channel);
            var call = client.SendMultiple();

            for (int i = 0; i < 10; i++)
            {

                await call.RequestStream.WriteAsync(new ClientStreamRequest
                {
                    Name = "Anish",
                    Age = i
                });


            }

            await call.RequestStream.CompleteAsync();
            var response = await call.ResponseAsync;
            Console.WriteLine(response.Message);

            Console.ReadKey();
        }
    }
}
