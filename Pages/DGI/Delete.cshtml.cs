using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Models;

namespace ProjetFinal.Pages_DGI
{
    public class DeleteModel : PageModel
    {
        private readonly ProjetFinal.Models.BridgeDBcontext _context;

        public DeleteModel(ProjetFinal.Models.BridgeDBcontext context)
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

            var dgi = await _context.Tb_DGI.FirstOrDefaultAsync(m => m.ID == id);

            if (dgi == null)
            {
                return NotFound();
            }
            else 
            {
                DGI = dgi;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tb_DGI == null)
            {
                return NotFound();
            }
            var dgi = await _context.Tb_DGI.FindAsync(id);

            if (dgi != null)
            {
                DGI = dgi;
                _context.Tb_DGI.Remove(DGI);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
