using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Paging;

namespace Common
{
    public class PagedCollection<T> : IEnumerable<T>
    {

        public PagedCollection()
        {
            Settings = new PagingSettings();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)Entities.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return Entities.GetEnumerator();
        }
        
        //Сущности для страницы
        public IEnumerable<T> Entities { get; set; }

        public PagingSettings Settings { get; set; }
    }
}
