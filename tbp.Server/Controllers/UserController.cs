using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore.Internal;
using tbp.Server.Models;
using User = tbp.Shared.Models.User;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tbp.Server.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        //string connectionString =
        //    "Data Source=DESKTOP-Q791NJ6;Initial Catalog=tbp-db;Persist Security Info=True;User ID=goc;Password=grebe-suggest-fear-bohemia";

        tbpdbContext _context = new tbpdbContext();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.User.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            try
            {
                return _context.User.First(user => user.Id == id);
            }
            catch (Exception ex)
            {
                return new User{Id = -1};
            }
        }

        // GET api/<controller>/5
        [HttpPost("login")]
        public User Login([FromBody] string[] userData)
        {
            try
            {
                return _context.User.First(u => u.Username == userData[0] && u.Password == userData[1]);
            }
            catch (Exception ex)
            {
                return new User{Id = -1};
            }
        }

        [HttpPost("checkusername")]
        public bool CheckUsername([FromBody] string username)
        {
            try
            {
                var user =_context.User.First(u => u.Username == username);
                return user.Username == username;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            _context.User.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            _context.User.Update(value);
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var usr = _context.User.First(u => u.Id == id);
            _context.User.Remove(usr);
            _context.SaveChanges();
        }
    }
}