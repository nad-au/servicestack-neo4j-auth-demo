using ServiceStack;
using ServiceStack.Host;
using ServiceStack.Web;
using vue_spa.ServiceInterface;

namespace vue_spa
{
    class TenantFilter : ITypedFilter<IReturn>
    {
        private readonly ITenant tenant;

        public TenantFilter(ITenant tenant)
        {
            this.tenant = tenant;
        }
        
        //public ITenant Tenant { get; set; }
 
        public void Invoke(IRequest req, IResponse res, IReturn dto)
        {
            var session = req.GetSession();
            tenant.Key = session.UserAuthId;
        }
    }
}