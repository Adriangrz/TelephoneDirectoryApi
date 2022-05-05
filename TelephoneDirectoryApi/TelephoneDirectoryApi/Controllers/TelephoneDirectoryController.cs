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
        private readonly ILogger _logger;
        public TelephoneDirectoryController(IGenericRepositoryy<EntryInTelephoneDirectory> repositoryTelephoneDirectory, IMapper mapper, ILogger<TelephoneDirectoryController> logger)
        {
            _repositoryTelephoneDirectory = repositoryTelephoneDirectory;
            _mapper = mapper;
            _logger = logger;
        }
        // GET: api/<TelephoneDirectoryController>
        [HttpGet]
        public async Task<EntryInTelephoneDirectory?> Get()
        {
            _logger.LogInformation("Get last added item method was called");
            return await _repositoryTelephoneDirectory.GetRecenltyAdded();
        }

        // GET api/<TelephoneDirectoryController>/Warszawa
        [HttpGet("{city}")]
        public async Task<IEnumerable<EntryInTelephoneDirectory>> Get(string city)
        {
            _logger.LogInformation($"Get by city method was called with parameter {city}");
            return await _repositoryTelephoneDirectory.Get(x=>x.City.ToLower() == city.ToLower());
        }

        // POST api/<TelephoneDirectoryController>
        [HttpPost]
        public IActionResult Post([FromBody] EntryInTelephoneDirectoryResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            _logger.LogInformation("Save item method was called");
            _logger.LogInformation("Saving item");
            var entryInTelephoneDirectory = _mapper.Map<EntryInTelephoneDirectoryResource, EntryInTelephoneDirectory>(value);

            _repositoryTelephoneDirectory.Insert(entryInTelephoneDirectory);
            _repositoryTelephoneDirectory.Save();

            var entryInTelephoneDirectoryResource = _mapper.Map<EntryInTelephoneDirectory, EntryInTelephoneDirectoryResource>(entryInTelephoneDirectory);
            _logger.LogInformation("Saved item");
            return Ok(entryInTelephoneDirectoryResource);
        }
    }
}
