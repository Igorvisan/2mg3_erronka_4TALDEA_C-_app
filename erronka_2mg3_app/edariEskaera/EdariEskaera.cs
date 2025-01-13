using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erronka_2mg3_app.edariEskaera
{
    internal class EskaeraEdaria
    {
        public virtual int Id { get; set; }

        public virtual erronka_2mg3_app.edaria.Edaria EdariaId { get; set; }

        public virtual erronka_2mg3_app.eskaria.Eskaera EskaeraId { get; set; }
        public virtual double Prezioa { get; set; }

        public virtual int Kantitatea { get; set; }
    }
}
