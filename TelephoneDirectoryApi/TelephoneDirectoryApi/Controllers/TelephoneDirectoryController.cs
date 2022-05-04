using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelephoneDirectoryApi.Database.Repository.Interfaces;
using TelephoneDirectoryApi.Extensions;
using TelephoneDirectoryApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelephoneDirectoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelephoneDirectoryController : ControllerBase
    {
        private readonly IGenericRepositoryy<EntryInTelephoneDirectory> _repositoryTelephoneDirectory;
        private readonly IMapper _mapper;
        public TelephoneDirectoryController(IGenericRepositoryy<EntryInTelephoneDirectory> repositoryTelephoneDirectory, IMapper mapper)
        {
            _repositoryTelephoneDirectory = repositoryTelephoneDirectory;
            _mapper = mapper;
        }
        // GET: api/<TelephoneDirectoryController>
        [HttpGet]
        public async Task<EntryInTelephoneDirectory?> Get()
        {
            return await _repositoryTelephoneDirectory.GetRecenltyAdded();
        }

        // GET api/<TelephoneDirectoryController>/Warszawa
        [HttpGet("{city}")]
        public async Task<IEnumerable<EntryInTelephoneDirectory>> Get(string city)
        {
            return await _repositoryTelephoneDirectory.Get(x=>x.City.ToLower() == city.ToLower());
        }

        // POST api/<TelephoneDirectoryController>
        [HttpPost]
        public IActionResult Post([FromBody] EntryInTelephoneDirectoryResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var entryInTelephoneDirectory = _mapper.Map<EntryInTelephoneDirectoryResource, EntryInTelephoneDirectory>(value);

            _repositoryTelephoneDirectory.Insert(entryInTelephoneDirectory);
            _repositoryTelephoneDirectory.Save();

            var entryInTelephoneDirectoryResource = _mapper.Map<EntryInTelephoneDirectory, EntryInTelephoneDirectoryResource>(entryInTelephoneDirectory);
            return Ok(entryInTelephoneDirectoryResource);
        }
    }
}
