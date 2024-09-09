using System;
using System.Collections.Generic;

namespace DuAn1
{
    class Snake : GameObject
    {
        private List<Point> body;
        private Point direction;

        public Snake()
        {
            body = new List<Point>
            {
                new Point(20, 20),
                new Point(19, 20),
                new Point(18, 20)
            };
            direction = new Point(1, 0); // Ban đầu di chuyển sang phải
        }

        public void Move()
        {
            Point head = body[0];
            Point newHead = new Point(head.X + direction.X, head.Y + direction.Y);

            // Nếu rắn chạm tường, di chuyển từ phía bên kia
            if (newHead.X < 0) newHead.X = 41;
            if (newHead.X > 41) newHead.X = 0;
            if (newHead.Y < 0) newHead.Y = 41;
            if (newHead.Y > 41) newHead.Y = 0;

            body.Insert(0, newHead);
            body.RemoveAt(body.Count - 1); // Di chuyển: thêm đầu, bỏ đuôi
        }

        public void Grow()
        {
            Point tail = body[body.Count - 1];
            body.Add(tail); // Thêm vào cuối thân
        }

        public void ChangeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow: // Trái
                    if (direction.X != 1) direction = new Point(-1, 0);
                    break;
                case ConsoleKey.RightArrow: // Phải
                    if (direction.X != -1) direction = new Point(1, 0);
                    break;
                case ConsoleKey.DownArrow: // Xuống
                    if (direction.Y != -1) direction = new Point(0, 1);
                    break;
                case ConsoleKey.UpArrow: // Lên
                    if (direction.Y != 1) direction = new Point(0, -1);
                    break;
            }
        }

        public bool IsCollisionWithSelf()
        {
            Point head = body[0];
            for (int i = 1; i < body.Count; i++)
            {
                if (body[i].X == head.X && body[i].Y == head.Y)
                    return true;
            }
            return false;
        }

        public bool IsEating(Food food)
        {
            Point head = body[0];
            return (head.X == food.Position.X && head.Y == food.Position.Y);
        }

        public override void Draw()
        {
            foreach (var point in body)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write('*');
            }
        }
    }
}
