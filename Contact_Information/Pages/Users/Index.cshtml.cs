using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contact_Information.DTOs;
using Contact_Information.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Contact_Information.Pages.Users
{
    public class IndexModel : PageModel
    {
        //private readonly Contact_Information.Data.ContactContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<IndexModel> _logger;


        public IList<UserDTO> UserDTO { get; set; }
        //public IList<Contacts> Contacts { get; set; }

        public IndexModel(IUnitOfWork unitOfWork, IMapper mapper, ILogger<IndexModel> logger)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;


        }



        //public IndexModel(Contact_Information.Data.ContactContext context)
        //{
        //    _context = context;
        //}


        //public IList<Contacts> Contacts { get;set; }

        public async Task OnGetAsync()
        {
            //var contactList = await _context.Contacts.ToList(includes: new List<string>() { "Countries"} );

            //Contacts = await _context.Contacts.ToListAsync();
            //Contacts = await _ContactController.
            var UserList = await _unitOfWork.Users.GetAll(includes: new List<string>() { "Location" });
            var results = _mapper.Map<IList<UserDTO>>(UserList);
            UserDTO = results;


        }
    }
}
