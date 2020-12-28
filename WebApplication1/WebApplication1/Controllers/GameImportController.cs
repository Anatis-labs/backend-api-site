using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static WebApplication1.Models.JsonImport;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameImportController : ControllerBase
    {
        ////GET: api/<GameImportController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var url = "https://www.freetogame.com/api/games";
        //    string stringResponse;

        //    using (var client = new HttpClient())
        //    {
        //        using (var response = await client.GetAsync(url))
        //        {
        //            var responceContent = response.Content;
        //            stringResponse = await responceContent.ReadAsStringAsync();
        //            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(stringResponse);

        //            return Ok(stringResponse);
        //        }
        //    }

        //}

        //public async Task<IActionResult> Get()
        //{
        //    var url = "https://www.freetogame.com/api/games";
        //    //string stringResponse;         
        //    var gameImport = new GameImport();
        //    using (var client = new HttpClient())
        //    {
        //        using (var response = await client.GetAsync(url))
        //        {

        //            var stringResponse = await response.Content.ReadAsStringAsync();                   
        //            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content.ToString());
        //            return Ok(myDeserializedClass);
        //        }               
        //    }
        //}
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string url = "https://www.freetogame.com/api/games";
            //string stringResponse;         
            var gameImport = new GameImport();
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
                    List<Root> games = JsonConvert.DeserializeObject<List<Root>>(data);

                    return Ok(games);

                }
            }
        }





        // GET api/<GameImportController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
