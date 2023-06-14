using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Models;

namespace ProjetFinal.Pages_DGI
{
    public class EditModel : PageModel
    {
        private readonly ProjetFinal.Models.BridgeDBcontext _context;

        public EditModel(ProjetFinal.Models.BridgeDBcontext context)
        {
            _context = context;
        }

        [BindProperty]
        public DGI DGI { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tb_DGI == null)
            {
                return NotFound();
            }

            var dgi =  await _context.Tb_DGI.FirstOrDefaultAsync(m => m.ID == id);
            if (dgi == null)
            {
                return NotFound();
            }
            DGI = dgi;
           ViewData["No_Fiche"] = new SelectList(_context.Tb_Contravention, "No_Fiche", "No_Fiche");
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

            _context.Attach(DGI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DGIExists(DGI.ID))
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

        private bool DGIExists(int id)
        {
          return (_context.Tb_DGI?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
