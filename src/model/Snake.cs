using System;
using System.Collections.Generic;

namespace DuAn1.Models
{
    public class Snake
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
            direction = new Point(1, 0);
        }

        public void Move()
        {
            Point head = body[0];
            Point newHead = new Point(head.X + direction.X, head.Y + direction.Y);

            if (newHead.X < 0) newHead.X = 41;
            if (newHead.X > 41) newHead.X = 0;
            if (newHead.Y < 0) newHead.Y = 41;
            if (newHead.Y > 41) newHead.Y = 0;

            body.Insert(0, newHead);
            body.RemoveAt(body.Count - 1);
        }

        public void Grow()
        {
            Point tail = body[body.Count - 1];
            body.Add(tail);
        }

        public void ChangeDirection(ConsoleKey key) // nhần phím để di chuyển rắn
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (direction.X != 1) direction = new Point(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    if (direction.X != -1) direction = new Point(1, 0);
                    break;
                case ConsoleKey.DownArrow:
                    if (direction.Y != -1) direction = new Point(0, 1);
                    break;
                case ConsoleKey.UpArrow:
                    if (direction.Y != 1) direction = new Point(0, -1);
                    break;
            }
        }

        public bool IsCollisionWithSelf() // rắn tư c
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

        public List<Point> GetBody() => body;
    }
}
