using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Models;

namespace ProjetFinal.Pages_Conducteurs
{
    public class DetailsModel : PageModel
    {
        private readonly ProjetFinal.Models.BridgeDBcontext _context;

        public DetailsModel(ProjetFinal.Models.BridgeDBcontext context)
        {
            _context = context;
        }

      public Conducteur Conducteur { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tb_Conducteur == null)
            {
                return NotFound();
            }

            var conducteur = await _context.Tb_Conducteur.FirstOrDefaultAsync(m => m.No_Dossier == id);
            if (conducteur == null)
            {
                return NotFound();
            }
            else 
            {
                Conducteur = conducteur;
            }
            return Page();
        }
    }
}
