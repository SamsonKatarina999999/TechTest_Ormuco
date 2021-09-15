using System;
using System.Collections.Generic;

namespace Q3
{
    public class Q3
    {
    }

    public class LRUCache
    {
        private int capacity;
        private int count;
        private int head;
        private int tail;
        public TimeSpan expiration;
        private readonly Dictionary<int, Node> myDictionary;

        public int Head { get => head; set => head = value; }
        public int Tail { get => tail; set => tail = value; }
        public int Count { get => count; set => count = value; }
        public int Capacity { get => capacity; set => capacity = value; }

        private LRUCache()
        { }

        private static LRUCache instance = null;
        private static readonly Object padlock = new Object();

        public static LRUCache GetInstance(int capacity, TimeSpan expiration)
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new LRUCache(capacity, expiration);
                    }
                }
            }
            return instance;
        }



        private LRUCache(int capacity, TimeSpan expiration)
        {
            Head = -1;
            Tail = -1;
            this.Capacity = capacity;
            myDictionary = new Dictionary<int, Node>();
            this.expiration = expiration;
            this.Count = 0;
        }

        private void RemoveCurrentNode(Node node)
        {
            if (this.Head == node.keyValue.Key && this.Tail == node.keyValue.Key)
            {
                this.Head = -1;
                this.tail = -1;
                myDictionary.Remove(node.keyValue.Key);
                this.Count--;
            }
            else if (this.Head == node.keyValue.Key)
            {
                this.Head = node.Next.keyValue.Key;
                myDictionary.Remove(node.keyValue.Key);
                myDictionary[this.Head].Previous = null;
                this.Count--;
            }
            else if (this.Tail == node.keyValue.Key)
            {
                this.Tail = node.Previous.keyValue.Key;
                myDictionary.Remove(node.keyValue.Key);
                myDictionary[this.Tail].Next = null;
                this.Count--;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
                myDictionary.Remove(node.keyValue.Key);
                this.Count--;
            }
        }

        public string Get(int key)
        {
            if (myDictionary.ContainsKey(key))
            {
                Node node = myDictionary[key];
                RemoveCurrentNode(node);
                InsertNode(node);
                return node.keyValue.Value;
            }
            else
            {
                return null;
            }
        }

        public string GetHead()
        {
            if (this.Head != -1)
            {
                return myDictionary[this.Head].keyValue.Value;
            }
            return null;
        }

        public string GetTail()
        {
            if (this.Tail != -1)
            {
                return myDictionary[this.Tail].keyValue.Value;
            }
            return null;
        }

        public void Put(int key, string value)
        {
            if (myDictionary.ContainsKey(key))
            {
                Node node = new Node(key, value);
                RemoveCurrentNode(myDictionary[key]);
                InsertNode(node);
            }
            else
            {
                Node node = new Node(key, value);
                InsertNode(node);
            }
        }

        public void InsertNode(Node node)
        {
            if (this.Count == 0)
            {
                this.Head = node.keyValue.Key;
                this.Tail = node.keyValue.Key;
                this.Count++;
            }
            else
            {
                myDictionary[Head].Previous = node;
                node.Next = myDictionary[this.Head];
                this.Head = node.keyValue.Key;
                this.Count++;
            }
            if (this.Count > this.Capacity)
            {
                var tmp = this.tail;
                myDictionary[this.tail].Previous.Next = null;
                this.tail = myDictionary[this.tail].Previous.keyValue.Key;
                myDictionary.Remove(tmp);
                this.Count--;
            }
            myDictionary.Add(node.keyValue.Key, node);
        }

        public void RemoveExpiredNodes()
        {
            foreach (KeyValuePair<int, Node> keyValuePair in myDictionary)
            {
                if (Node.IsExpired(keyValuePair.Value, expiration))
                {
                    this.RemoveCurrentNode(keyValuePair.Value);
                }
            }
        }

        public static void Clean()
        {
            instance = null;
        }

    }

    public class Node
    {
        public KeyValuePair<int, string> keyValue { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        private long createdTime;

        public Node(int key, string value)
        {
            this.keyValue = new KeyValuePair<int, string>(key, value);
            Next = null;
            Previous = null;
            createdTime = DateTime.Now.Ticks;
        }

        public static bool IsExpired(Node node, TimeSpan expiration)
        {
            if (TimeSpan.FromTicks(DateTime.Now.Ticks - node.createdTime) > expiration)
            {
                return true;
            }
            return false;
        }
    }
}
