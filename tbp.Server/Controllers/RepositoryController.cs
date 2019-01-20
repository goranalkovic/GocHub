using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tbp.Server.Models;
using tbp.Shared.Models;
using Document = tbp.Shared.Models.Document;
using User = tbp.Shared.Models.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tbp.Server.Controllers
{
    [Route("api/[controller]")]
    public class RepositoryController : Controller
    {
        tbpdbContext _context = new tbpdbContext();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Repository> Get()
        {
            return _context.Repository;
        }
        
        [HttpGet("{id}")]
        public Repository Get(int id)
        {
            return _context.Repository.First(u => u.Id == id);
        }

        [HttpGet("by/{id}")]
        public IEnumerable<Repository> GetFromUser(int id)
        {
            return _context.Repository.Where(r => r.UserId == id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] Repository value)
        {
            _context.Repository.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            _context.Update(value);
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var doc = _context.Repository.First(d => d.Id == id);
                _context.Remove(doc);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"ERROR: {e.Message}");
            }
        }
    }
}