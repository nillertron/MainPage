using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IPortfolioService
    {
        Task Create(MS_Portfolio model);
        Task<MS_Portfolio> Get(int id);
        Task<List<MS_Portfolio>> GetAllPortfolioWtihFrontFoto();
    }
}