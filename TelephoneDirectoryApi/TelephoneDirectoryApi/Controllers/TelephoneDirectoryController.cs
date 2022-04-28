using Microsoft.AspNetCore.Mvc;
using TelephoneDirectoryApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelephoneDirectoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelephoneDirectoryController : ControllerBase
    {
        List<TelephoneDirectoryModel> telephoneDirectories = new List<TelephoneDirectoryModel>()
        {
            new TelephoneDirectoryModel() { Id = Guid.NewGuid(), Name = "Antek", Surname = "Kowalski", City="Warszawa", Street="Wodna", StreetNumber="35b", Number=455433212},
            new TelephoneDirectoryModel() { Id = Guid.NewGuid(), Name = "Marek", Surname = "Nowak", City="Bielsko-Biała", Street="Kryształowa", StreetNumber="34a", Number=123456788},
        };
        // GET: api/<TelephoneDirectoryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TelephoneDirectoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TelephoneDirectoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TelephoneDirectoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TelephoneDirectoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
