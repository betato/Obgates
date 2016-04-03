using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class NullGate : Component
    {
        public override void step()
        {
            output = input;
        }
    }
}
