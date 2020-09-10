using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IMessageService
    {
        Task CreateMessage(MS_Message msg);
        Task<List<MS_Message>> GetAll();
        Task<MS_Message> GetMessage(int id);
        Task<int> GetUnreadAmount();
        Task MarkAsRead(MS_Message msg);
    }
}