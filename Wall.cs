using System;

namespace DuAn1
{
    class Wall : GameObject
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Wall(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            // Vẽ cạnh trên và dưới
            for (int x = 0; x < Width; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write('#');
                Console.SetCursorPosition(x, Height - 1);
                Console.Write('#');
            }

            // Vẽ cạnh trái và phải
            for (int y = 0; y < Height; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write('#');
                Console.SetCursorPosition(Width - 1, y);
                Console.Write('#');
            }
        }
    }
}
