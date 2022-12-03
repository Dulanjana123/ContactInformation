using AutoMapper;
using Contact_Information.DTOs;
using Contact_Information.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact_Information.Controllers.Users
{
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        private readonly IConfiguration _configuration;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UsersController> logger, IConfiguration configuration)
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
        public async Task<IActionResult> GetUsers()
        {
            //var users = await _unitOfWork.Contacts.GetAll();
            var users = await _unitOfWork.Users.GetAll(includes: new List<string>() { "Location" });
            var results = _mapper.Map<IList<UserDTO>>(users);
            _logger.LogInformation("Get users", results);
            return Ok(results);

        }
    }
}
