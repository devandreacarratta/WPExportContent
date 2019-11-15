using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WPExportContent.WebAPI.DTO;

namespace WPExportContent.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WPToJsonController : ControllerBase
    {
        // GET: api/WPToJson
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WPToJson/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WPToJson
        [HttpPost]
        public HttpResponseMessage Post([FromBody] WPToJsonDTO value)
        {
            WPExportContentEngine engine = new WPExportContentEngine(value);
            var json = engine.DoWork();

            byte[] jsonBytes = Encoding.ASCII.GetBytes(json);

            string exportFileName = $"WPToJson_{DateTime.UtcNow.ToString("yyyyMMddHHmm")}.json";

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(jsonBytes)
            };

            result.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("attachment")
                {
                    FileName = exportFileName
                };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return result;
        }

        // PUT: api/WPToJson/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}