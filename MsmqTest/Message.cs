using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsmqTest
{
    public class Message
    {
        public Guid MessageId = Guid.NewGuid();
        public Guid FlowId { get; set; }
        public DateTime SentDate { get; set; }
        public int FlowDuration { get; set; } // In Seconds 
        public string Body { get; set; }
        public bool IsFailure { get; set; }

        public int Action { get; set; } // 1: Started  , 2 : In progress , 3: Finished ( for success or not use IsFailure) 
        public Message()
        {
        }

        public Message(Guid messageId, Guid flowId, DateTime sentDate, int flowDuration, string msgBody, bool IsFailure  )
        {
            Guid MessageId = Guid.NewGuid();
            Guid FlowId = Guid.NewGuid();
            DateTime SentDate = DateTime.Now;
            //   int FlowDuration = SentDate - DateTime.Now;
            //Body = this.msgBody;
            IsFailure = this.IsFailure;
        }

    }

}
