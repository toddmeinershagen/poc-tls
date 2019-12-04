using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Tls.Engine;

namespace Tls.Web.Controllers
{
    public class TlsController : ApiController
    {
        [HttpGet]
        public async Task<Dictionary<string,string>> Whatever()
        {
            var tlsChecker = new TlsChecker();
            var result = await tlsChecker.GetSupportedProtocols();
            return result;
        }
    }
}
