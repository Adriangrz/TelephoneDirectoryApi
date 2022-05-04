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
        public TelephoneDirectoryModel Get()
        {
            return telephoneDirectories.Last();
        }

        // GET api/<TelephoneDirectoryController>/5
        [HttpGet("{town}")]
        public string Get(string town)
        {
            return "value";
        }

        // POST api/<TelephoneDirectoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
