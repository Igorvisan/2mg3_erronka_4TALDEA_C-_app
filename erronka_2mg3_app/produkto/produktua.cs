using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erronka_2mg3_app.produkto
{
    internal class produktua
    {
        public virtual int Id { get; set; }
        public virtual string Izena { get; set; }
        public virtual string Egoera { get; set; }
        public virtual int GutxienezkoKantitatea { get; set; }
        public virtual int OraingoKantitatea { get; set; }
        public virtual int GehienezkoKantitatea { get; set; } 
    }
}
