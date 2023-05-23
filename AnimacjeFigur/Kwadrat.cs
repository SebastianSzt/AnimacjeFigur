namespace AnimacjeFigur
{
    [Serializable]
    public class Kwadrat : Figura
    {
        public Kwadrat() : base() { }

        public Kwadrat(int width, int height) : base(width, height) { }

        public Kwadrat(string[] line, int method) : base(line, method) { }

        public override void Draw(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(color);
            e.Graphics.FillRectangle(brush, posX, posY, size, size);
        }

        public override void Move(int width, int height)
        {
            if (posX + vX < 0)
            {
                posX = 0;
                vX = -vX;
            }
            else if (posX + size + vX > width)
            {
                posX = width - size;
                vX = -vX;
            }
            else
            {
                posX += vX;
            }

            if (posY + vY < 0)
            {
                posY = 0;
                vY = -vY;
            }
            else if (posY + size + vY > height)
            {
                posY = height - size;
                vY = -vY;
            }
            else
            {
                posY += vY;
            }
        }

        public override void ParametersSave(StreamWriter writer)
        {
            base.ParametersSave(writer);
            writer.WriteLine();
        }
    }
}