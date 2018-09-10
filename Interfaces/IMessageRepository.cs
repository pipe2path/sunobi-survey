using survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMessages();
        Task SaveMessage(Message item);
    }
}
