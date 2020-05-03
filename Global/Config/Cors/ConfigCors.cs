
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;
using ICorsPolicyProvider = System.Web.Http.Cors.ICorsPolicyProvider;

namespace Proyecto_Licitacion.Global.Config.Cors
{
    public class ConfigCors : Attribute, ICorsPolicyProvider
    {
        public async Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var corsRequestContext = request.GetCorsRequestContext();
            var originRequest = corsRequestContext.Origin;
            if (await IsOriginFromCustomer(originRequest))
            {
                var policy = new CorsPolicy
                {
                    AllowAnyHeader = true,
                    AllowAnyMethod = true,
                    AllowAnyOrigin = true
                };

                policy.Origins.Add(originRequest);
                return policy;
            }

            return null;
        }

        public async Task<bool> IsOriginFromCustomer(String originRequested)
        {
            return true;
        }

    }
}
