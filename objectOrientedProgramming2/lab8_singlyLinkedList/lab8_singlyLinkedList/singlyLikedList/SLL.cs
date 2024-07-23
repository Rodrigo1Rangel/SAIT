using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace singlyLikedList
{
    public class SLL
    {
        // =========================== INSTANCE FIELDS ===========================
        private Node _head;
        private Node _tail;

        // ============================= PROPERTIES ==============================
        public Node Head { get { return _head; } set { _head = value; } }
        public Node Tail { get { return _tail; } set { _tail = value; } }

        // ============================= CONSTRUCTOR ==============================
        public SLL()
        {
            this._head = null;
            this._tail = null;
        }

        // ============================= CONSTRUCTOR ==============================
        public void InsertFront(string data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
        }
        public void InsertLast(string data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Next = null;
                Tail = newNode;
            }
        }
        public Node GetLastNode()
        {
            return Tail;
        }
        public void InsertAfter(string newData, string searchedData)
        {
            Node current = Head;

            while (current != null)
            {
                if (searchedData == current.Data)
                {
                    Node nodeToInsert = new Node(newData);
                    nodeToInsert.Next = current.Next;
                    current.Next = nodeToInsert;
                    if (nodeToInsert.Next == null)
                    {
                        Tail = nodeToInsert;
                    }
                    return;
                }
                current = current.Next;
            }
        }
        public void DeleteNodeByKey(string searchedData)
        {
            Node current = Head;
            Node previous = null;
            if (current != null && current.Data == searchedData)
            // CASE: searchedData in the Head
            {
                Head = Head.Next;
                return;
            }
            while (current != null && current.Data != searchedData)
            // Traverse until reaching the Tail or finding the searchedData
            {
                previous = current;
                current = current.Next;
            }
            if (current == null)
            // Leave the method if the searchedData is not in the Tail
            {
                return;
            }
            previous.Next = current.Next;
        }
        public void ReverseSLL()
        {
            Node current = Head;
            Node next = null;
            Node previous = null;
            // Why can I not assign a value to a unassigned variable inside
            // the while loop?
            Tail = Head;

            while (current != null) // ends when it reaches the Tail
            {
                next = current.Next; // establish access to the .Next node
                current.Next = previous; // redirect the link
                previous = current; // previous become the node that will be left behind
                current = next; // reposition the current node to the next one
            }
            Head = previous;
        }
        public void TraversePrinting()
        {
            Node current = Head;
            while (current != null)
            {
                Console.WriteLine($"Node: {current.Data}");
                current = current.Next;
            }
        }
    }
}

