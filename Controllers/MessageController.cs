using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using survey.Interfaces;
using survey.Model;

namespace survey.Controllers
{
    [Produces("application/json")]
    public class MessageController : Controller
    {
        public IMessageRepository _messageRepository;
        
        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }


        [HttpGet]
        [Route("api/messages")]
        public async Task<IEnumerable<Message>> Get()
        {
            return await _messageRepository.GetMessages();
        }


        [HttpPut]
        [Route("api/messages")]
        public async Task SaveMessageSent([FromBody] IEnumerable<MessageJsonPayload> payload)
        {
            try
            {
                if (payload != null)
                {
                    foreach (var p in payload)
                    {
                        Message msg = new Message();
                        msg.userId = p.userId;
                        msg.userName = p.userName;
                        msg.userPhone = p.userPhone;
                        msg.userEmail = p.userEmail;
                        msg.message = p.message;
                        msg.code = p.code;
                        msg.dateLastTextSent = DateTime.Now;
                        await _messageRepository.SaveMessage(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
    public class MessageJsonPayload
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string userPhone { get; set; }
        public string userEmail { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }
}