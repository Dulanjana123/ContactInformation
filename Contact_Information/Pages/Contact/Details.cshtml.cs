using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Contact_Information.Data;
using Contact_Information.Model;

namespace Contact_Information.Pages.Contact
{
    public class DetailsModel : PageModel
    {
        private readonly Contact_Information.Data.ContactContext _context;

        public DetailsModel(Contact_Information.Data.ContactContext context)
        {
            _context = context;
        }

        public Contacts Contacts { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contacts = await _context.Contacts.FirstOrDefaultAsync(m => m.ContactId == id);

            if (Contacts == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
