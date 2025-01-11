using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erronka_2mg3_app.eskaria
{
    internal class Eskaera
    {
        public Eskaera()
        {
        }

        public Eskaera(erronka_2mg3_app.mahaia.mahaia mahaiaId, erronka_2mg3_app.langileLogIn langileId, double? totala, bool? ordainduta, string fakturaPath)
        {
            MahaiaId = mahaiaId;
            LangileId = langileId;
            Totala = totala;
            Ordainduta = ordainduta;
            FakturaPath = fakturaPath;
        }

        public virtual int Id { get; set; }
        public virtual erronka_2mg3_app.mahaia.mahaia MahaiaId { get; set; } 
        public virtual erronka_2mg3_app.langileLogIn LangileId { get; set; } 
        public virtual double? Totala { get; set; }
        public virtual bool? Ordainduta { get; set; }
        public virtual string FakturaPath { get; set; }

    }
}
