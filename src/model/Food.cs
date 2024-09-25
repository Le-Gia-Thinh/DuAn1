using System;

namespace DuAn1.Models
{
    public class Food
    {
        public Point Position { get; private set; }

        public Food()
        {
            Random random = new Random();
            Position = new Point(random.Next(1, 39), random.Next(1, 39));
        }
    }
}
