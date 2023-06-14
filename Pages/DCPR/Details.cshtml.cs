using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Models;

namespace ProjetFinal.Pages_DCPR
{
    public class DetailsModel : PageModel
    {
        private readonly ProjetFinal.Models.BridgeDBcontext _context;

        public DetailsModel(ProjetFinal.Models.BridgeDBcontext context)
        {
            _context = context;
        }

      public DCPR DCPR { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Tb_DCPR == null)
            {
                return NotFound();
            }

            var dcpr = await _context.Tb_DCPR.FirstOrDefaultAsync(m => m.Code_agent == id);
            if (dcpr == null)
            {
                return NotFound();
            }
            else 
            {
                DCPR = dcpr;
            }
            return Page();
        }
    }
}
