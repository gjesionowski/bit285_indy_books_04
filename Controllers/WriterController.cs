using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndyBooks.Models;
using IndyBooks.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace IndyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private IndyBooksDataContext _db;
        public WriterController(IndyBooksDataContext db) { _db = db; }

        // GET: api/Writer
        [HttpGet]
        public IActionResult Get()
        {
            var writers = _db.Writers;
            return Ok(writers); 
                //new string[] { "value1", "value2" };
        }

        // GET: api/Writer/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var writer = _db.Writers.Select(w => new { id = w.Id, name = w.Name }).Single(w => w.id == id);
            return Ok(writer);
        }

        // POST: api/Writer
        [HttpPost]
        public IActionResult Post(Writer writer)
        {
            _db.Writers.Add(writer);
            _db.SaveChanges();
            Response.StatusCode = 202;
            return Accepted();
        }

        // PUT: api/Writer/5
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
