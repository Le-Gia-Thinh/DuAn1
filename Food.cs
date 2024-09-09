using System;

namespace DuAn1
{
    class Food : GameObject
    {
        public Point Position { get; private set; }

        public Food()
        {
            Random random = new Random();
            Position = new Point(random.Next(1, 39), random.Next(1, 39)); // Tránh các cạnh tường
        }

        public override void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write('O'); // Vẽ mồi
        }
    }
}
