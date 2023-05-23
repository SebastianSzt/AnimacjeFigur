using System.ComponentModel;

namespace AnimacjeFigur
{
    [Serializable]
    public class Trojkat : Figura
    {
        [Description("Pozycja figury")]
        public int position;

        public Trojkat() : base() { }

        public Trojkat(int width, int height) : base(width, height) 
        {
            Random random = new Random();
            position = random.Next(0, 4);
        }

        public Trojkat(string[] line, int method) : base(line, method)
        {
            if (method == 1)
                position = int.Parse(line[7]);
        }

        public override void Draw(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(color);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            PointF[] points = new PointF[3];
            if (position == 0)
            {
                points[0] = new PointF(posX, posY + size);
                points[1] = new PointF(posX + size, posY + size);
                points[2] = new PointF(posX + (size / 2), posY);
            }
            else if (position == 1)
            {
                points[0] = new PointF(posX, posY);
                points[1] = new PointF(posX, posY + size);
                points[2] = new PointF(posX + size, posY + (size / 2));
            }
            else if (position == 2)
            {
                points[0] = new PointF(posX, posY);
                points[1] = new PointF(posX + size, posY);
                points[2] = new PointF(posX + (size / 2), posY + size);
            }
            else
            {
                points[0] = new PointF(posX + size, posY);
                points[1] = new PointF(posX + size, posY + size);
                points[2] = new PointF(posX, posY + (size / 2));
            }
            e.Graphics.FillPolygon(brush, points);
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
            writer.WriteLine(" " + position);
        }
    }
}