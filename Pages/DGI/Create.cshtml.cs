using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetFinal.Models;

namespace ProjetFinal.Pages_DGI
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
        ViewData["No_Fiche"] = new SelectList(_context.Tb_Contravention, "No_Fiche", "No_Fiche");
            return Page();
        }

        [BindProperty]
        public DGI DGI { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tb_DGI == null || DGI == null)
            {
                return Page();
            }

            _context.Tb_DGI.Add(DGI);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
