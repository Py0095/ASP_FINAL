using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Models;

namespace ProjetFinal.Pages_Contravention
{
    public class DetailsModel : PageModel
    {
        private readonly ProjetFinal.Models.BridgeDBcontext _context;

        public DetailsModel(ProjetFinal.Models.BridgeDBcontext context)
        {
            _context = context;
        }

      public Contravention Contravention { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tb_Contravention == null)
            {
                return NotFound();
            }

            var contravention = await _context.Tb_Contravention.FirstOrDefaultAsync(m => m.No_Fiche == id);
            if (contravention == null)
            {
                return NotFound();
            }
            else 
            {
                Contravention = contravention;
            }
            return Page();
        }
    }
}
