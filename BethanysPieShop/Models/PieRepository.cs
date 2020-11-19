using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class PieRepository:IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies => _appDbContext.Pies.Include(c => c.Category); 
        

        public IEnumerable<Pie> PiesOfTheWeek => _appDbContext
                                                .Pies
                                                .Include(c => c.Category)
                                                .Where(p=>p.IsPieOfTheWeek); 
        
        public Pie GetPieById(int pieId)=>_appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        
    }
}
