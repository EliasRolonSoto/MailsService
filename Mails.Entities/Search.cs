using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mails.Entities
{
    public class Search
    {
        public string TextToSearch { get; set; }

        [DefaultValue(10)]
        public int PageSize { get; set; }

        [DefaultValue(1)]
        public int PageIndex { get; set; }

        public bool IsValid
        {
            get
            {

                if (PageSize <= 0)
                {
                    return false;
                }

                if (PageIndex <= 0)
                {
                    return false;
                }

                return true;

            }
        }
        public string ResultMessage()
        {
            return $"Mails {PageIndex * PageSize} - {PageIndex * PageSize + PageSize}";
        }

        public Search()
        {
            PageIndex = 1;
            PageSize = 10;
        }

    }
}
