using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Models;
using static WebApplication1.Models.GameInfoWithID;
using static WebApplication1.Models.GameImport;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("CORSPolicy")]
    [ApiController]
    public class GameImportController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string url = "https://www.freetogame.com/api/games";


            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    Stream responseStream = res.GetResponseStream();
                    StreamReader readerStream = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    string data = readerStream.ReadToEnd();
                    readerStream.Close();

                    //converts all items to object
                    List<GameInfo> games = JsonConvert.DeserializeObject<List<GameInfo>>(data);

                    return Ok(games);
                }
            }
        }


        // GET api/<GameImportController>/5
        [HttpGet("{type}")]
        public async Task<IActionResult> Get(string type)
        {
            string url = "https://www.freetogame.com/api/games?category=" + type;

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    Stream responseStream = res.GetResponseStream();
                    StreamReader readerStream = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    string data = readerStream.ReadToEnd();
                    readerStream.Close();

                    //converts all items to object
                    List<GameInfo> games = JsonConvert.DeserializeObject<List<GameInfo>>(data);

                    return Ok(games);
                }
            }
        }

        // POST api/<GameImportController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GameImportController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GameImportController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}