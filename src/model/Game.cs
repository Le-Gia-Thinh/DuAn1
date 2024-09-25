namespace DuAn1.Models
{
    public class Game
    {
        private Snake snake;
        private Food food;
        private Wall wall;

        public Game()
        {
            // Khởi tạo các đối tượng trong game
            snake = new Snake();
            food = new Food();
            wall = new Wall(40, 40);
        }

        public void Start()
        {
            // Logic bắt đầu trò chơi
        }

        private void Update()
        {
            // Logic cập nhật trò chơi
        }

        private void Input()
        {
            // Xử lý nhập từ bàn phím
        }
    }
}
