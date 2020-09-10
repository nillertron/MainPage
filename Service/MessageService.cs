using DataAcces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MessageService : IMessageService
    {
        private IRepository<MS_Message> messageRepo;
        public MessageService(IRepository<MS_Message> msgRepo)
        {
            messageRepo = msgRepo;
        }
        public async Task CreateMessage(MS_Message msg)
        {
            msg.MessageSent = DateTime.Now;
            await messageRepo.Create(msg);
        }
        public async Task<int> GetUnreadAmount()
        {
            var query = await messageRepo.GetAll();
            var list = query.Where(x => !x.Read).ToList();
            return list.Count;


        }
        public async Task<List<MS_Message>> GetAll()
        {
            var query = await messageRepo.GetAll();
            var list = query.ToList();
            list = await SortMessagesByReadAndDate(list);
            return list;
        }
        private async Task<List<MS_Message>> SortMessagesByReadAndDate(List<MS_Message> list)
        {
            list = list.OrderBy(x => x.Read).ThenByDescending(x => x.MessageSent).ToList();
            return list;
        }
        public async Task MarkAsRead(MS_Message msg)
        {
            msg.Read = true;
            await messageRepo.Update(msg);
        }
        public async Task<MS_Message> GetMessage(int id)
        {
            var query = await messageRepo.Get(id);
            return query.First();
        }
    }
}
