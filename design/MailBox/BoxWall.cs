using System;
using System.Collections.Generic;
using System.Text;

namespace Design.MailBox
{
    class BoxWall
    {
        private const int TotalBox = 8;
        private List<Box> boxes;

        public BoxWall()
        {
            boxes = new List<Box>();
            for(int i = 0; i < TotalBox; i++)
            {
                int id = i;
                BoxSize size = (BoxSize)(i % TotalBox);
                boxes.Add(new Box(i, size));
            }
        }

        public Box Deposit (BoxSize boxSize)
        {
            foreach(Box box in boxes)
            {
                if(box.Size == boxSize && string.IsNullOrEmpty(box.Secrete))
                {
                    box.Secrete = Guid.NewGuid().ToString();
                    return box;
                }
            }
            return null;
        }

        public Box Pickup(string secrete)
        {
            foreach (Box box in boxes)
            {
                if (!string.IsNullOrEmpty(box.Secrete) && secrete.Equals(box.Secrete))
                {
                    box.Secrete = string.Empty;
                    return box;
                }
            }
            return null;
        }

        public void Run()
        {
            Box box = Deposit(BoxSize.large);
            string secrete = box.Secrete;
            Box box2 = Pickup(secrete);
            if(box2 == box)
            {
                Console.WriteLine("same box with id: " + box.Id);
            }
            else
            {
                Console.WriteLine("wrong box");
            }
        }
    }
}
