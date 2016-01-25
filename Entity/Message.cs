using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Message
    {
        public Message()
        {
            Date = DateTime.Now;
        }
        public int MessageId { get; set; }
        public virtual User UserFrom { get; set; }
        public virtual User UserTo { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

    }
}
