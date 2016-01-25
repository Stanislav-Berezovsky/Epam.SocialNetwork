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
        public string Link { get; set; }
        public virtual User user { get; set; }

        public DateTime Date { get; set; }
    }
}
