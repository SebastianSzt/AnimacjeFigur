namespace AnimacjeFigur
{
    public interface IFigura
    {
        void Draw(PaintEventArgs e);
        void Move(int width, int height);
        void CheckPosition(int width, int height);
    }
}