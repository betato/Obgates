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
            pinStates.Add(false);
            pinStates.Add(false);
        }

        public override void Step()
        {
            pinStates[1] = !pinStates[0];
        }
    }
}
