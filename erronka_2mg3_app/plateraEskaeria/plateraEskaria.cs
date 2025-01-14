using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erronka_2mg3_app.plateraEskaeria
{
    internal class plateraEskaria
    {
        public virtual int Id { get; set; }
        public virtual erronka_2mg3_app.eskaria.Eskaera EskaeraId { get; set; }
        public virtual erronka_2mg3_app.platera.platera PlateraId { get; set; }
        public virtual double Prezioa { get; set; }

        public virtual int Kantitatea { get; set; }

        public virtual DateTime EskaeraOrdua { get; set; }

        public virtual DateTime ZerbitzatzekoOrdua { get; set; }

    }
}
