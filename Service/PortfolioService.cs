using DataAcces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PortfolioService : IPortfolioService
    {
        private IRepository<MS_Portfolio> service;
        public PortfolioService(IRepository<MS_Portfolio> service)
        {
            this.service = service;
        }
        public async Task<List<MS_Portfolio>> GetAllPortfolioWtihFrontFoto()
        {
            var query = await service.GetAll(o => o.PhotoLinks);
            var list = query.ToList();
            var rnd = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                var obj = list[i];
                list.Remove(obj);
                list.Insert(rnd.Next(0, list.Count), obj);
            }



            return list;
        }
        public async Task<MS_Portfolio> Get(int id)
        {
            var obj = await service.Get(id, (e => e.PhotoLinks));
            var returnObj = obj.First();

            return returnObj;
        }
        public async Task Create(MS_Portfolio model)
        {
            await service.Create(model);
        }
    }
}
