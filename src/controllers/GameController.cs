using DuAn1.Models;
using DuAn1.Views;
using System;
using System.Threading;

namespace DuAn1.Controllers
{
    public class GameController
{
    private Snake snake;
    private Wall wall;
    private Food food;
    private bool gameOver;
    private GameView view;

    public GameController()
    {
        Console.SetWindowSize(42, 42); // xét cửa sổ console cho hiển thị đầy đủ rắn
        Console.SetBufferSize(42, 42);
        InitializeGame(); // Gọi phương thức khởi tạo
    }

    private void InitializeGame()
    {
        snake = new Snake();
        wall = new Wall(40, 40);
        food = new Food(); // Đảm bảo food được khởi tạo
        view = new GameView(); // Đảm bảo view được khởi tạo
        gameOver = false;
        DrawInitial();
    }

    public void Start()
    {
        Console.CursorVisible = false;
        while (!gameOver)
        {
            Input();
            Update();
            Thread.Sleep(300);
        }

        view.ShowGameOver(); // Hiển thị thông báo Game Over
        AskForRestart(); // Hỏi người dùng có muốn chơi lại không
    }

    private void DrawInitial()
    {
        if (view != null && wall != null && food != null && snake != null)
        {
            view.DrawWall(wall);
            view.DrawFood(food);
            view.DrawSnake(snake);
        }
        else
        {
            Console.WriteLine("Error: One or more game components are not initialized.");
        }
    }

    private void Update()
    {
        if (snake == null || food == null) // Kiểm tra nếu snake hoặc food là null
        {
            Console.WriteLine("Error: Snake or Food is not initialized.");
            return;
        }

        snake.Move();

        if (snake.IsCollisionWithSelf())
        {
            gameOver = true;
            return;
        }

        if (snake.IsEating(food))
        {
            snake.Grow();
            food = new Food(); // Tạo thức ăn mới
        }

        view.ClearScreen();
        DrawInitial();
    }

    private void Input()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            snake.ChangeDirection(key);
        }
    }

    private void AskForRestart()
    {
        Console.WriteLine("Do you want to restart the game? (Y/N)");
        ConsoleKey response = Console.ReadKey(true).Key;
        if (response == ConsoleKey.Y)
        {
            Console.Clear();
            InitializeGame();
            Start(); // Khởi động lại trò chơi
        }
    }
}
}