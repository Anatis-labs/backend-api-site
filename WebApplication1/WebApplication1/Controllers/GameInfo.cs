﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameInfo : ControllerBase
    {
        private readonly IMemoryCache _memoryCashe;
        private readonly ILogger<GameInfo> _logger;

        public GameInfo(ILogger<GameInfo> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCashe = memoryCache;
        }


        //// GET: api/<GameInfo>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        // GET api/<GameImportController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            string url = " https://www.freetogame.com/api/game?id=" + id;
            var gameInfoWithID = new GameInfoWithID();   
            


            //check if the call is in the cashe memory, if not it goes to the call bellow
            var casheKey = $"Get_On_Location--{id}";
            if (_memoryCashe.TryGetValue(casheKey, out string cashedValue))
            {
                return Ok(cashedValue);
            }
     
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
                    var gameInfo = JsonConvert.DeserializeObject<GameInfoWithID.RootWithId>(data);

                    //saves the call to the cashe
                    _memoryCashe.Set(casheKey, gameInfo);

                    return Ok(gameInfo);
                }
            }
        }

        //// POST api/<GameInfo>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<GameInfo>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<GameInfo>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
