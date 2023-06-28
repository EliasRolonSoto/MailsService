using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mails.Entities
{
    public class Response<T>
    {
        public int Total { get; set; }
        public List<T> Items { get; set; }

        //public string MensajeResultado
        //{
        //    get { return ""; }
        //}

        public Response()
        {

        }
    }
}
