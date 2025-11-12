using Horatau_Darius_Cristian_Lab2.Data;
using Horatau_Darius_Cristian_Lab2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horatau_Darius_Cristian_Lab2.Pages.Publishers
{
    
    public class CreateModel : PageModel
    {
        private readonly Horatau_Darius_Cristian_Lab2.Data.Horatau_Darius_Cristian_Lab2Context _context;

        public CreateModel(Horatau_Darius_Cristian_Lab2.Data.Horatau_Darius_Cristian_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Publisher Publisher { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Publisher.Add(Publisher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
