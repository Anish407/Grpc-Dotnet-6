using Grpc.Core;
using Grpc.Net.Client;
using GrpcService.Demo.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPC.Client
{
    public class ServerStreamProgram
    {
         static  async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new SampleStreamingService.SampleStreamingServiceClient(channel);

            var call =  client.SayHello(new StreamRequest { Name = "anish" });

            await foreach (var message in call.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine(message.Message);
            }
           
           
            Console.ReadKey();
        }
    }
}
