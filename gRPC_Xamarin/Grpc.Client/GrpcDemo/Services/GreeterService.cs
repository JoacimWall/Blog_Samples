using System;
namespace GrpcDemo.Services
{
    public class GreeterService
    {
        private Grpc.Server.Greeter.GreeterClient _greeterClient;

        public GreeterService()
        {
            _greeterClient = new Grpc.Server.Greeter.GreeterClient();
        }
    }
}
