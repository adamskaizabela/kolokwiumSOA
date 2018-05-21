using Newbay.DTOIZAADA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newbay.DTOIZAADA
{
    public class WingDB : IObjWithId
    {
        public int Id { get; set; }
        public int Power { get; set; }
        public int Shield { get; set; }
        public string Name { get; set; }
    }
}
