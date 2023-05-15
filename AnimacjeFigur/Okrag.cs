﻿namespace AnimacjeFigur
{
    internal class Okrag : Figura
    {
        public Okrag(int width, int height) : base(width, height) { }

        public Okrag(string[] line) : base(line) { }

        public override void Draw(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(color);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(brush, new RectangleF(posX, posY, size, size));
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

        public override void Save(StreamWriter writer)
        {
            base.Save(writer);
            writer.WriteLine();
        }
    }
}