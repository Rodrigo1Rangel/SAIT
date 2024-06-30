using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization_and_RAF
{
    [Serializable]
    internal class Event
    {
        // ----------------- INSTANCE FIELDS -----------------
        private int _eventNumber;
        private string _location;

        // -------------------- PROPERTIES -------------------
        public int EventNumber { get { return _eventNumber; } set { _eventNumber = value; } }
        public string Location { get { return _location; } set { _location = value; } }

        // -------------------- CONSTRUCTORS -----------------
       public Event(int eventNumber, string location)
        {
            EventNumber = eventNumber;
            Location = location;
        }

    }
}
