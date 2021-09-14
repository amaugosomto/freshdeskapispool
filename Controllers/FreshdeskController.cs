using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FreshdeskAPISpool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FreshdeskController : ControllerBase
    {
        private string url = "https://s3.amazonaws.com/cdn.freshdesk.com/data/helpdesk/scheduled_exports/tickets/3171471631177020/tickets-daily-September-13-2021.csv?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAS6FNSMY2XLZULJPI%2F20210913%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20210913T135111Z&X-Amz-Expires=900&X-Amz-SignedHeaders=host&X-Amz-Signature=0275cd1bbb93925c95dceea06f9abf358d1a9ca7017aef3eee086f41a889e285";

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var data = await client.GetAsync(url);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex);
            }
        }
    }
}
