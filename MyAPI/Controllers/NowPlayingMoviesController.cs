﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAPI
{
    [Route("api/[controller]")]
    public class NowPlayingMoviesController : Controller
    {
        public IHostingEnvironment _env;
        public NowPlayingMoviesController(IHostingEnvironment env) {
            _env = env;
        }
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {

            return System.IO.File.ReadAllText(System.IO.Path.Combine(_env.ContentRootPath, "jsondata\\movie.json"));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
