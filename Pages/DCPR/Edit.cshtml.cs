using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Models;

namespace ProjetFinal.Pages_DCPR
{
    public class EditModel : PageModel
    {
        private readonly ProjetFinal.Models.BridgeDBcontext _context;

        public EditModel(ProjetFinal.Models.BridgeDBcontext context)
        {
            _context = context;
        }

        [BindProperty]
        public DCPR DCPR { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Tb_DCPR == null)
            {
                return NotFound();
            }

            var dcpr =  await _context.Tb_DCPR.FirstOrDefaultAsync(m => m.Code_agent == id);
            if (dcpr == null)
            {
                return NotFound();
            }
            DCPR = dcpr;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DCPR).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCPRExists(DCPR.Code_agent))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DCPRExists(string id)
        {
          return (_context.Tb_DCPR?.Any(e => e.Code_agent == id)).GetValueOrDefault();
        }
    }
}
