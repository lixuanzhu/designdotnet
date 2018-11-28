using System;
using System.Collections.Generic;
using System.Text;

namespace Design.LRU
{
    class LeastRecentUsedCache
    {
        private int cap;
        private Dictionary<int, LinkedNode> map;
        private LinkedNode first;
        private LinkedNode last;

        public LeastRecentUsedCache(int capacity)
        {
            cap = capacity;
            map = new Dictionary<int, LinkedNode>();
        }

        public int Get(int key)
        {
            if (!map.ContainsKey(key))
            {
                return -1;
            }
            LinkedNode node = map[key];
            MoveToFirst(node);
            return node.Value;
        }

        private void MoveToFirst(LinkedNode node)
        {
            if (node == first)
            {
                return;
            }

            node.Pre.Next = node.Next;
            if (node != last)
            {
                node.Next.Pre = node.Pre;
            }
            else
            {
                last = node.Pre;
                last.Next = null;
            }

            node.Next = first;
            first.Pre = node;
            first = node;
        }
        public void Set(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                LinkedNode node = map[key];
                MoveToFirst(node);
                node.Value = value;
                return;
            }

            LinkedNode newNode = new LinkedNode(key, value);
            if (map.Count == 0)
            {
                last = newNode;
                first = newNode;
            }

            newNode.Next = first;
            first.Pre = newNode;
            first = newNode;
            map.Add(key, newNode);

            if (map.Count > cap)
            {
                map.Remove(last.Key);
                last = last.Pre;
                last.Next = null;
            }
        }

        public static void Test()
        {
            LeastRecentUsedCache test = new LeastRecentUsedCache(2);
            TestUtil.Verify(-1, test.Get(3));
            test.Set(2, 2);
            TestUtil.Verify(2, test.Get(2));
            test.Set(1, 1);
            test.Set(3, 3);
            TestUtil.Verify(-1, test.Get(2));
            test.Set(1, 1);
            test.Set(2, 2);
            TestUtil.Verify(-1, test.Get(3));
        }
    }
}
