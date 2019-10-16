using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        static List<Book> books = new List<Book>()
        {
            new Book("1234567891012", "In Search of Lost Time", "Marcel Proust",4215),
            new Book("1234567891013", "Ulysses", "James Joyce",730),
            new Book("1234567891014", "Don Quixote", "Miguel de Cervantes",863),
            new Book("1234567891015", "The Great Gatsby", "F. Scott Fitzgerald",218)
    };
        // GET api/Book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return books;
        }

        // GET api/Book/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(string id)
        {
            return books.Find(e => e.ISBN == id);
        }

        // POST api/Book
        [HttpPost]
        public void Post([FromBody] Book newbook)
        {
            books.Add(newbook);
        }

        // PUT api/Book/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Book newbook)
        {
            Delete(id);
            Post(newbook);
        }

        // DELETE api/Book/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            books.RemoveAll(e => e.ISBN == id);
        }
    }
}