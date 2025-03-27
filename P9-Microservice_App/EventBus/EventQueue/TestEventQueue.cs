using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventBus.EventQueue
{
    public class TestEventQueue : EventBase.EventBase
    {
        public string? Mensaje { get; set; }

        public TestEventQueue(string? mensaje)
        {
            Mensaje = mensaje;
        }
    }
}
