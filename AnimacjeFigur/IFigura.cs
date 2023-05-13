namespace AnimacjeFigur
{
    internal interface IFigura
    {
        void Draw(PaintEventArgs e);

        void Move(int width, int height);
    }
}