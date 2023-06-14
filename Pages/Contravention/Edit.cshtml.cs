using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Models;

namespace ProjetFinal.Pages_Contravention
{
    public class EditModel : PageModel
    {
        private readonly ProjetFinal.Models.BridgeDBcontext _context;

        public EditModel(ProjetFinal.Models.BridgeDBcontext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contravention Contravention { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tb_Contravention == null)
            {
                return NotFound();
            }

            var contravention =  await _context.Tb_Contravention.FirstOrDefaultAsync(m => m.No_Fiche == id);
            if (contravention == null)
            {
                return NotFound();
            }
            Contravention = contravention;
           ViewData["No_Dossier"] = new SelectList(_context.Tb_Conducteur, "No_Dossier", "No_Dossier");
           ViewData["Code_agent"] = new SelectList(_context.Tb_DCPR, "Code_agent", "Code_agent");
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

            _context.Attach(Contravention).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContraventionExists(Contravention.No_Fiche))
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

        private bool ContraventionExists(int id)
        {
          return (_context.Tb_Contravention?.Any(e => e.No_Fiche == id)).GetValueOrDefault();
        }
    }
}
