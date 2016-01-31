using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Paging
{
    public class PagingSettings
    {

        public PagingSettings()
        {
            this.EntitiesPerPage = Constants.ItemsPerPage;
            this.DisplayedRange = Constants.PageRange;
            this.CurrentPage = 1;
        }

        //Количество юзеров на странице
        public int EntitiesPerPage { get; set; }

        //Текущая страница
        public int CurrentPage { get; set; }

        //Всего сущностей
        public int TotalCount { get; set; }
        
        //Отображать страниц
        public int DisplayedRange { get; set; }
    }
}
