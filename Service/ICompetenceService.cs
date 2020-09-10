using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface ICompetenceService
    {
        Task<List<MS_Competence>> GetAllCompetenceAsync();
    }
}