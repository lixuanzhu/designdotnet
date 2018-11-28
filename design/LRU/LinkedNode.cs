using System;
using System.Collections.Generic;
using System.Text;

namespace Design.LRU
{
    class LinkedNode
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public LinkedNode Next { get; set; }
        public LinkedNode Pre { get; set; }
        public LinkedNode(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }

}
