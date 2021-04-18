using Grpc.Core;
using GrpcService.Demo.Protos;
using System.Threading.Tasks;

namespace GrpcService.Demo.Services
{
    public class ServerStreamService : SampleStreamingService.SampleStreamingServiceBase
    {

        public override async Task SayHello(StreamRequest request, IServerStreamWriter<StreamReply> responseStream, ServerCallContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                //check for cancellation
                if (context.CancellationToken.IsCancellationRequested) break;

                await responseStream.WriteAsync(new StreamReply { Message = $"{request.Name} - iteration :  {i}" });
                await Task.Delay(1500);
            }
        }
    }
}
