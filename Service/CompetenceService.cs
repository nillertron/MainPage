using DataAcces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CompetenceService : ICompetenceService
    {
        private IRepository<MS_Competence> context;
        public CompetenceService(IRepository<MS_Competence> context)
        {
            this.context = context;
        }
        public async Task<List<MS_Competence>> GetAllCompetenceAsync()
        {
            var list1 = await context.GetAll();
            var list = list1.ToList();
            list = list.OrderByDescending(x => x.Stars).ToList();
            return list;
        }
    }
}
