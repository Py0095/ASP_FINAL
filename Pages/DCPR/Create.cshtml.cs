using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetFinal.Models;

namespace ProjetFinal.Pages_DCPR
{
    public class CreateModel : PageModel
    {
        private readonly ProjetFinal.Models.BridgeDBcontext _context;

        public CreateModel(ProjetFinal.Models.BridgeDBcontext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DCPR DCPR { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tb_DCPR == null || DCPR == null)
            {
                return Page();
            }

            _context.Tb_DCPR.Add(DCPR);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
