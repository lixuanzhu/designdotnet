using System;
using System.Collections.Generic;
using System.Text;

namespace Design.MailBox
{
    class Box
    {
        private int id;
        private BoxSize size;
        private string secrete;

        public Box(int id, BoxSize boxSize)
        {
            Id = id;
            Size = boxSize;
        }

        public string Secrete { get; set; }

        public BoxSize Size { get; private set; }

        public int Id { get; private set; }
    }
}
