using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace MyProxy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyProxyController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public MyProxyController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("Test")]
        public IActionResult Get()
        {
            return Ok("MyProxy Works!");
        }

        [HttpGet]
        public async Task<IActionResult> Proxy()
        {
            // Retrieve the target URL from a custom header
            if (!Request.Headers.TryGetValue("X-Forward-Url", out var targetUrl))
            {
                return BadRequest("Missing 'X-Forward-Url' header.");
            }

            // Forward the GET request
            var request = new HttpRequestMessage(HttpMethod.Get, targetUrl);
            request.Headers.UserAgent.ParseAdd("Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:133.0) Gecko/20100101 Firefox/133.0");

            var response = await _httpClient.SendAsync(request);

            // Read the response content
            var content = await response.Content.ReadAsStringAsync();

            // Forward the response back to the client
            return Content(content, response.Content.Headers.ContentType?.ToString());
        }

    }
}
