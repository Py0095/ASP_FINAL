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
    public class IndexModel : PageModel
    {
        private readonly ProjetFinal.Models.BridgeDBcontext _context;

        public IndexModel(ProjetFinal.Models.BridgeDBcontext context)
        {
            _context = context;
        }

        public IList<Contravention> Contravention { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tb_Contravention != null)
            {
                Contravention = await _context.Tb_Contravention
                .Include(c => c.Conducteur)
                .Include(c => c.DCPR).ToListAsync();
            }
        }
    }
}
