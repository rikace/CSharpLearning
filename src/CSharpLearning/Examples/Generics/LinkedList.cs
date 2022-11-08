namespace Generic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next;

        public Node(T item)
        {
            Item = item;
        }
    }

    public class LinkedList<T> : IList<T>
    {
        Node<T> head;
        Node<T> tail;

        public T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            var node = new Node<T>(item);

            if (head == null)
                head = node;
            else
                tail.Next = node;

            tail = node;
        }

        // other IList members...

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        // more IList<T> members
    }

    public class LinkedListTest
    {
        public static void Run()
        {
            var llist = new LinkedList<string>();
            llist.Add("Jamie");
            llist.Add("Ron");
            //...


            var llist2 = new LinkedList<int>();
            var llist3 = new LinkedList<Customer>();


            Node<string> name = new Node<string>("May");
        }
    }
}
