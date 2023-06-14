using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Models;

namespace ProjetFinal.Pages_Conducteurs
{
    public class EditModel : PageModel
    {
        private readonly ProjetFinal.Models.BridgeDBcontext _context;

        public EditModel(ProjetFinal.Models.BridgeDBcontext context)
        {
            _context = context;
        }

        [BindProperty]
        public Conducteur Conducteur { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tb_Conducteur == null)
            {
                return NotFound();
            }

            var conducteur =  await _context.Tb_Conducteur.FirstOrDefaultAsync(m => m.No_Dossier == id);
            if (conducteur == null)
            {
                return NotFound();
            }
            Conducteur = conducteur;
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

            _context.Attach(Conducteur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConducteurExists(Conducteur.No_Dossier))
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

        private bool ConducteurExists(int id)
        {
          return (_context.Tb_Conducteur?.Any(e => e.No_Dossier == id)).GetValueOrDefault();
        }
    }
}
