using DuAn1.Models;
using System;

namespace DuAn1.Views
{
    public class GameView
    {
        public void DrawWall(Wall wall)
        {
            for (int x = 0; x < wall.Width; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write('#');
                Console.SetCursorPosition(x, wall.Height - 1);
                Console.Write('#');
            }

            for (int y = 0; y < wall.Height; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write('#');
                Console.SetCursorPosition(wall.Width - 1, y);
                Console.Write('#');
            }
        }

        public void DrawSnake(Snake snake)
        {
            foreach (var point in snake.GetBody())
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write('*');
            }
        }

        public void DrawFood(Food food)
        {
            Console.SetCursorPosition(food.Position.X, food.Position.Y);
            Console.Write('O');
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void ShowGameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
        }
    }
}
