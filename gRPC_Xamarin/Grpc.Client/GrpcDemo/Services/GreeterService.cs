using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Xamarin.Forms;

namespace GrpcDemo.Services
{
    public class GreeterService
    {
        private Grpc.Server.Greeter.GreeterClient _greeterClient;
        private GrpcWebHandler _httpHandler;
        private GrpcChannel _channel;
        public GreeterService()
        {
            //this is so you can debug on mac and emulator the server has "EndpointDefaults": { "Protocols": "Http1"
            // Return `true` to allow certificates that are untrusted/invalid
#if DEBUG
             _httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWebText,
             new HttpClientHandler { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator });
#else
            {
             _httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
            }
#endif
            //debug on android emulator
            var serverAddress = (Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:5001" : "https://localhost:5001");
                
            _channel = GrpcChannel.ForAddress($"{serverAddress}", new GrpcChannelOptions
            {
                HttpHandler = _httpHandler
            });

            
            _greeterClient = new Grpc.Server.Greeter.GreeterClient(_channel);
        }
        public async  Task<string> SayHelloAsync(string hello)
        {

           var result = await  _greeterClient.SayHelloAsync(new Grpc.Server.HelloRequest { Name = hello });
            return result.Message;

        }
        
    }
}
