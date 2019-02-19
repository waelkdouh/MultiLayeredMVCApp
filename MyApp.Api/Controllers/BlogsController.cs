using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.DAL.Models;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {

        private readonly BloggingContext _context;

        public BlogsController(BloggingContext context)
        {
            _context = context;
        }

        // GET api/blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> Get()
        {
            return await _context.Blog.ToListAsync();
        }

        // GET api/blogs/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/blogs
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/blogs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/blogs/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
