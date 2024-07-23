using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singlyLikedList
{
    public class Node
    {
        // =========================== INSTANCE FIELDS ===========================
        private string _data;
        private Node _next;

        // ============================= PROPERTIES ==============================
        public string Data { get { return _data; } set { _data = value; } }
        public Node Next { get { return _next; } set { _next = value; } }

        // ============================= CONSTRUCTOR ==============================
        public Node(string data)
        {
            Data = data;
            Next = null;
        }
    }
}
