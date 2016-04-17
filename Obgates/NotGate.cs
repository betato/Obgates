using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class NotGate : Component
    {
        public NotGate()
        {
            pins.Add(new Pin());
            pins.Add(new Pin());
        }

        public override void Step()
        {
            pins[1].state = !pins[0].state;
        }
    }
}
