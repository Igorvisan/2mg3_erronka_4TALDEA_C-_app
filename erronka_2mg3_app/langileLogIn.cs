﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erronka_2mg3_app
{
    internal class langileLogIn
    {
        public virtual int Id { get; set; }
        public virtual string Izena { get; set; }

        public virtual string Email { get; set; }

        public virtual string Pasahitza { get; set; }

        public virtual string LanPostua { get; set; }
    }
}
