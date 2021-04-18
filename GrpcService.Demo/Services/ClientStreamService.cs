using Grpc.Core;
using GrpcService.Demo.client.Protos;
using System.Threading.Tasks;

namespace GrpcService.Demo.Services
{
    public class ClientStreamService : ClientStreamerDemoService.ClientStreamerDemoServiceBase
    {

        public override async Task<ClientStreamReply> SendMultiple(IAsyncStreamReader<ClientStreamRequest> requestStream, ServerCallContext context)
        {
            var response = new ClientStreamReply();
            await foreach (var item in requestStream.ReadAllAsync())
            {
                response.Message.Add($"{item.Name} has age {item.Age} ");
               
            }
            return response;

        }
    }
}
