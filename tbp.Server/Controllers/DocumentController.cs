using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using tbp.Server.Models;
using tbp.Shared.Models;
using Document = tbp.Shared.Models.Document;
using User = tbp.Shared.Models.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tbp.Server.Controllers
{
    [Route("api/[controller]")]
    public class DocumentController : Controller
    {
        tbpdbContext _context = new tbpdbContext();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Document> Get()
        {
            return _context.Document;
        }

        [HttpPost("inrepo/{id}")]
        public IEnumerable<Document> GetFromRepo(int id, [FromBody] string path)
        {
            return _context.Document.Where(d => d.RepoId == id && d.Path == path);
        }

        [HttpGet("nameof/{id}")]
        public string GetName(int id)
        {
            try
            {
                return "/" + _context.Document.First(d => d.Id == id).FileName;
            }
            catch (Exception e)
            {
                return "/";
            }
        }

        // GET: api/<controller>
        [HttpGet("info")]
        public IEnumerable<Document> GetInfo()
        {
            return _context.Document
                .FromSql("SELECT id, repoId, fileName, fileType, path, SysStartTime, SysEndTime FROM document").Select(
                    doc =>
                        new Document
                        {
                            FileType = doc.FileType,
                            Id = doc.Id,
                            FileName = doc.FileName,
                            SysStartTime = doc.SysStartTime,
                            Path = doc.Path,
                            RepoId = doc.RepoId,
                            SysEndTime = doc.SysEndTime
                        }).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Document Get(int id)
        {
            try
            {
                return _context.Document.First(u => u.Id == id);
            }
            catch (Exception ex)
            {
                return new Document{Id = -1};
            }
        }

        // GET api/<controller>/5
        [HttpGet("history/{id}")]
        public List<Document> GetHistory(int id)
        {
            return _context.Document
                .FromSql($"SELECT * FROM document_history WHERE id = {id}").Select(
                    doc =>
                        new Document
                        {
                            FileType = doc.FileType,
                            Id = doc.Id,
                            FileName = doc.FileName,
                            SysStartTime = doc.SysStartTime,
                            Path = doc.Path,
                            RepoId = doc.RepoId,
                            SysEndTime = doc.SysEndTime,
                            Contents = doc.Contents
                        }).ToList();
            
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] Document value)
        {
            _context.Document.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Document value)
        {
            _context.Document.Update(value);
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var doc = _context.Document.First(d => d.Id == id);
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