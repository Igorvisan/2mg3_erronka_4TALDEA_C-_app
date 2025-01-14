using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erronka_2mg3_app.platera
{
    internal class platera
    {
        public virtual int Id { get; set; }
        public virtual string Izena { get; set; }
        public virtual int PrestaketaDenbora { get; set; }
        public virtual string PlaterMota { get; set; }

        public virtual double Prezioa { get; set; }
    }
}
