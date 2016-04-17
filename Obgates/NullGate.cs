using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class NullGate : Component
    {
        public NullGate()
        {
            pins.Add(new Pin(0, 1));
            pins.Add(new Pin(2, 1));

            width = 2;
            height = 2;
        }

        public override void Step()
        {
            pins[1].state = pins[0].state;
        }
    }
}
