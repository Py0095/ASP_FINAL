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
    public class DetailsModel : PageModel
    {
        private readonly ProjetFinal.Models.BridgeDBcontext _context;

        public DetailsModel(ProjetFinal.Models.BridgeDBcontext context)
        {
            _context = context;
        }

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
    }
}
