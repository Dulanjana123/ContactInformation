using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Contact_Information.Data;
using Contact_Information.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Contact_Information.Pages.Contact
{
    public class CreateModel : PageModel
    {
        private readonly Contact_Information.Data.ContactContext _context;

        public CreateModel(Contact_Information.Data.ContactContext context)
        {
            _context = context;
        }

        //public IActionResult OnGet()
        //{
        //    return Page();
        //}

        [BindProperty]
        public Contacts Contacts { get; set; }
        public IList<Countries> Countries { get; set; }

        public SelectList CountryList { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

        public async Task OnGetAsync()
        {
            //return Page();

            var countriesList = await _context.Countries.ToListAsync();
            TempData["IfsUsersList"] = JsonConvert.SerializeObject(countriesList);
            CountryList = new SelectList(countriesList, "CountryId", "Country");

            //CountryList = await _context.Countries.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contacts.Add(Contacts);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
