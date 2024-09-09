using System;
using System.Threading;

namespace DuAn1
{
    class Game
    {
        private Snake snake;
        private Wall wall;
        private Food food;
        private bool gameOver;

        public Game()
        {
            Console.SetWindowSize(42, 42);
            Console.SetBufferSize(42, 42);
            snake = new Snake();
            wall = new Wall(40, 40); // Tường 40x40
            food = new Food();
            gameOver = false;
            DrawInitial(); // Vẽ các phần tử ban đầu
        }

        public void Start()
        {
            Console.CursorVisible = false;
            while (!gameOver)
            {
                Input();
                Update();
                Thread.Sleep(500); // Tốc độ rắn chậm lại 0.5 giây
            }

            Console.Clear();
            Console.WriteLine("Game Over!");
        }

        private void DrawInitial()
        {
            wall.Draw(); // Vẽ tường chỉ một lần
            food.Draw(); // Vẽ mồi chỉ một lần
        }

        private void Update()
        {
            snake.Move();

            if (snake.IsCollisionWithWall(wall) || snake.IsCollisionWithSelf())
            {
                Thread.Sleep(500); // Tốc độ chậm lại trước khi kết thúc
                gameOver = true;
                return;
            }

            if (snake.IsEating(food))
            {
                snake.Grow();
                food = new Food(); // Tạo mồi mới
            }

            Console.Clear(); // Xóa phần rắn cũ
            DrawInitial(); // Vẽ lại các phần tử ban đầu
            snake.Draw(); // Vẽ rắn
            food.Draw(); // Vẽ mồi
        }

        private void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                snake.ChangeDirection(key);
            }
        }
    }
}
