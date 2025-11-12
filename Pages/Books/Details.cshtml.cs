using Horatau_Darius_Cristian_Lab2.Data;
using Horatau_Darius_Cristian_Lab2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horatau_Darius_Cristian_Lab2.Pages.Books
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly Horatau_Darius_Cristian_Lab2.Data.Horatau_Darius_Cristian_Lab2Context _context;

        public DetailsModel(Horatau_Darius_Cristian_Lab2.Data.Horatau_Darius_Cristian_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index"); ;
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}
