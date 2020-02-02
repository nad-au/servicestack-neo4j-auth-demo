using ServiceStack;
using ServiceStack.DataAnnotations;
using vue_spa.ServiceModel;

namespace vue_spa.ServiceInterface
{
    [Exclude(Feature.Metadata)]
    [FallbackRoute("/{PathInfo*}", Matches="AcceptsHtml")]
    public class FallbackForClientRoutes
    {
        public string PathInfo { get; set; }
    }

    public class MyServices : Service
    {
        private readonly ITenant tenant;

        public MyServices(ITenant tenant)
        {
            this.tenant = tenant;
        }
        
        //Return index.html for unmatched requests so routing is handled on client
        public object Any(FallbackForClientRoutes request) => Request.GetPageResult("/");

        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}
