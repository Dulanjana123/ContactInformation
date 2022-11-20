using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Contact_Information.Data;
using Contact_Information.Model;
using Contact_Information.IRepository;

using Microsoft.Extensions.Logging;

using Contact_Information.DTOs;
using AutoMapper;

namespace Contact_Information.Pages.Contact
{
    public class IndexModel : PageModel
    {
        //private readonly Contact_Information.Data.ContactContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<IndexModel> _logger;


        public IList<ContactsDTO> ContactsDTO { get; set; }
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
            var ContactsList = await _unitOfWork.Contacts.GetAll(includes: new List<string>() {"Countries"} );
            var results = _mapper.Map<IList<ContactsDTO>>(ContactsList);
            ContactsDTO = results;


        }
    }
}
