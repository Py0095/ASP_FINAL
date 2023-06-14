using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetFinal.Models;

namespace ProjetFinal.Pages_Contravention
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
        ViewData["No_Dossier"] = new SelectList(_context.Tb_Conducteur, "No_Dossier", "No_Dossier");
        ViewData["Code_agent"] = new SelectList(_context.Tb_DCPR, "Code_agent", "Code_agent");
            return Page();
        }

        [BindProperty]
        public Contravention Contravention { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tb_Contravention == null || Contravention == null)
            {
                return Page();
            }

            _context.Tb_Contravention.Add(Contravention);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
