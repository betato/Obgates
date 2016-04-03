using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class Connection
    {
        public Connection(int component, int pin)
        {
            this.component = component;
            this.pin = pin;
        }

        public int component;
        public int pin;
    }
}
