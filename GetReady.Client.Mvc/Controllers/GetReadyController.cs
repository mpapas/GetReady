using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using GetReady.Domain;

namespace GetReady.Client.Mvc.Controllers
{
    public class GetReadyController : ApiController
    {
        private IGetReadyProcessor _processor;

        public GetReadyController(IGetReadyProcessor processor)
        {
            _processor = processor;
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody]string[] value)
        {
            return await Task.FromResult(Ok(_processor.GetReady(value)));
        }
    }
}