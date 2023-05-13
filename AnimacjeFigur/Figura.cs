namespace AnimacjeFigur
{
    internal class Figura : IFigura
    {
        protected int posX;
        protected int posY;
        protected int vX;
        protected int vY;
        protected int size;
        protected Color color;

        public Figura(int width, int height)
        {
            Random random = new Random();

            size = random.Next(50, 100);
            posX = random.Next(0, width - size);
            posY = random.Next(0, height - size);
            while (vX >= -1 && vX <= 1)
                vX = random.Next(-15, 15);
            while (vY >= -1 && vY <= 1)
                vY = random.Next(-15, 15);
            color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        public Figura(string[] line)
        {
            posX = int.Parse(line[1]);
            posY = int.Parse(line[2]);
            vX = int.Parse(line[3]);
            vY = int.Parse(line[4]);
            size = int.Parse(line[5]);
            color = ColorTranslator.FromHtml("#" + line[6]);
        }

        public virtual void Draw(PaintEventArgs e) { }

        public virtual void Move(int width, int height) { }

        public void checkPosition(int width, int height)
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
        }

        public virtual void Save(StreamWriter writer)
        {
            writer.Write(GetType().FullName + " " + posX + " " + posY + " " + vX + " " + vY + " " + size + " " + color.Name);
        }
    }
}