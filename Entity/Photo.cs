using System;

namespace Entity
{
    public class Photo
    {
        public Photo()
        {
            Date = DateTime.Now;
        }
        public int PhotoId { get; set; }

        public byte[] Data { get; set; }

        public string MimeType { get; set; }

        public DateTime Date { get; set; }
        
        public virtual User User { get; set; }
    }
}
