using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebApiFromEmpty.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        [Produces("application/json")] // restricts the response to JSON format only
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET api/<controller>/5
        //[HttpGet("{id}")] //standard
        ////[HttpGet("{id?}")] //optional
        ////[HttpGet("{id=42}")] //optional with a default value
        ////[HttpGet("{id:int}")] //constrain to int
        ////public string Get(int id)
        ////{
        ////    return $"value {id}";
        ////}
        ////public string Get(int id, string qp)
        ////{
        ////    return $"id: {id}, query parameter: {qp}";
        ////}
        //public string Get(int id)
        //{
        //    return $"value {id}";
        //}

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new Value { Id = id, Text = "okeyvalue" + id });
        }





        //// POST api/<controller>
        //[HttpPost]
        ////public void Post([FromBody]string value)
        ////{
        ////}
        //public void Post([FromBody]Value value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        throw new InvalidOperationException("Model state is invalid!");
        //    }
        //}

        // POST api/<controller>
        [HttpPost]        
        public IActionResult Post([FromBody]Value value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // save the value to db etc...

            return CreatedAtAction("Get", new { id = value.Id }, value);
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

    public class Value
    {
        public int Id { get; set; }

        [MinLength(3)]
        public string Text { get; set; }
    }
}
