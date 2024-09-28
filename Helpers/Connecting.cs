using mgok2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgok2.Helpers
{
    internal class Connecting
    {
        public static mgokEntities conn { get; set; } = new mgokEntities();
    }
}
