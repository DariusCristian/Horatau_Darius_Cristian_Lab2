using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Horatau_Darius_Cristian_Lab2.Data;
using Horatau_Darius_Cristian_Lab2.Models;

namespace Horatau_Darius_Cristian_Lab2.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly Horatau_Darius_Cristian_Lab2.Data.Horatau_Darius_Cristian_Lab2Context _context;

        public DeleteModel(Horatau_Darius_Cristian_Lab2.Data.Horatau_Darius_Cristian_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            if (category != null)
            {
                Category = category;
                _context.Category.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
