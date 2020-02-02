using ServiceStack;
using System;

namespace vue_spa.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var authClient = new JsonServiceClient("https://localhost:5001/");

            var authResponse = authClient.Post(new Authenticate {
                provider = "credentials",
                UserName = "new@user.com",
                Password = "p@55wOrd",
                RememberMe = true,
            });

            var client = new JsonServiceClient("https://localhost:5001") {
                BearerToken = authResponse.BearerToken //Send JWT in HTTP Authorization Request Header
            };
        }
    }
}
