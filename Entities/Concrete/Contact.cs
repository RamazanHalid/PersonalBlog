using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        public int ContactId { get; set; }
        public string Fullname { get; set; }
        public string Email{ get; set; }
        public string CellPhone{ get; set; }
        public string Message{ get; set; }


    }
}
