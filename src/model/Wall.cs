namespace DuAn1.Models
{
    public class Wall
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Wall(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
