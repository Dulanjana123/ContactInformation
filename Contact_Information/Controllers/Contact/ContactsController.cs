using AutoMapper;
using AutoMapper.Configuration;
using Contact_Information.DTOs;
using Contact_Information.IRepository;
using Contact_Information.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact_Information.Controllers.Contact
{
    //[Authorize]
    //[Route("api/Book")]
    //[ApiController]
    [Route("api/Contact/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ContactsController> _logger;
        private readonly IConfiguration _configuration;

        public ContactsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ContactsController> logger, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContacts()
        {
            var contatcs = await _unitOfWork.Contacts.GetAll();
            var results = _mapper.Map<IList<ContactsDTO>>(contatcs);
            _logger.LogInformation("Get contacts", results);
            return Ok(results);

        }




    }
}
