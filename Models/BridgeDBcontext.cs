#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    public class BridgeDBcontext : DbContext
    {
       public DbSet<Conducteur> Tb_Conducteur {get; set;} //list to take information and manipulate information  from a specific class
       public DbSet<Contravention> Tb_Contravention {get; set;}
       public DbSet<DCPR> Tb_DCPR {get; set;}
       public DbSet<DGI> Tb_DGI {get; set;}
       
       public BridgeDBcontext(DbContextOptions options) : base(options)
        {
        }
    }
}